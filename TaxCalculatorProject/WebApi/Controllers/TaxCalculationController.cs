using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.WebApiModels.TaxCalculation;
using Domain.Interfaces;
using WebApi.Interfaces.TaxCalculation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculationController: WebApiControllerBase
    {
        private readonly IPostalCodeTaxCalculationTypeRepository _postalCodeTaxCalculationTypeRepository;
        private readonly ITaxCalculatorFactory _taxCalculatorFactory;
        private readonly ITaxCalculationRepository _taxCalculationRepository;
        private readonly IMapper _mapper;

        public TaxCalculationController(IPostalCodeTaxCalculationTypeRepository postalCodeTaxCalculationTypeRepository,
            ITaxCalculatorFactory taxCalculatorFactory,
            ITaxCalculationRepository taxCalculationRepository,
            IMapper mapper)
        {
            _postalCodeTaxCalculationTypeRepository = postalCodeTaxCalculationTypeRepository;
            _taxCalculatorFactory = taxCalculatorFactory;
            _taxCalculationRepository = taxCalculationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxCalculationGetModel>>> GetTaxCalculation()
        {
            var taxCalculations = _taxCalculationRepository.GetAll();

            var taxCalculationGetModels = _mapper.Map<IEnumerable<Domain.Entities.TaxCalculation>, IEnumerable<TaxCalculationGetModel>>(taxCalculations);

            return taxCalculationGetModels.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaxCalculationGetModel>> GetTaxCalculation(Guid id)
        {
            var taxCalculation = _taxCalculationRepository.GetById(id);

            if (taxCalculation == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Domain.Entities.TaxCalculation, TaxCalculationGetModel>(taxCalculation);

            return model;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaxCalculation(Guid id, TaxCalculationPutModel taxCalculationPutModel)
        {
            if (id != taxCalculationPutModel.Id)
            {
                return BadRequest(BuildControllerErrorModel($"Id in URL does not match Id in model."));
            }

            var taxCalculation = _taxCalculationRepository.GetById(id);
            if (taxCalculation == null)
            {
                return NotFound();
            }

            taxCalculation.PostalCode = taxCalculationPutModel.PostalCode;
            taxCalculation.AnnualIncome = taxCalculationPutModel.AnnualIncome;
            taxCalculation.CalculatedTax = taxCalculationPutModel.CalculatedTax;

            _taxCalculationRepository.Complete();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostTaxCalculation(TaxCalculationPostModel taxCalculationPostModel)
        {
            // Get tax calculation type
            var postalCodeTaxCalculationType = _postalCodeTaxCalculationTypeRepository.GetByPostalCode(taxCalculationPostModel.PostalCode);
            if (postalCodeTaxCalculationType == null)
            {
                return BadRequest(BuildControllerErrorModel($"Could not find PostalCodeTaxCalculationType for PostalCode {taxCalculationPostModel.PostalCode}"));
            }

            // Get Tax Calculator
            var taxCalculator = _taxCalculatorFactory.Get(postalCodeTaxCalculationType.TaxCalculationType);

            // Calculate tax
            var calculatedTax = taxCalculator.Calculate(taxCalculationPostModel.AnnualIncome);

            // Save values to db
            var newTaxCalculation = new Domain.Entities.TaxCalculation()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                PostalCode = taxCalculationPostModel.PostalCode,
                AnnualIncome = taxCalculationPostModel.AnnualIncome,
                CalculatedTax = calculatedTax
            };
            _taxCalculationRepository.Add(newTaxCalculation);
            _taxCalculationRepository.Complete();

            var model = _mapper.Map<Domain.Entities.TaxCalculation, TaxCalculationGetModel>(newTaxCalculation);

            return CreatedAtAction(
                nameof(GetTaxCalculation),
                new { id = model.Id },
                model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxCalculation(Guid id)
        {
            var taxCalculation = _taxCalculationRepository.GetById(id);

            if (taxCalculation == null)
            {
                return NotFound();
            }

            _taxCalculationRepository.Remove(taxCalculation);
            _taxCalculationRepository.Complete();

            return NoContent();
        }
    }
}
