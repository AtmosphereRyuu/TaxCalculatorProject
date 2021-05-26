using AutoMapper;
using Common.WebApiModels.TaxCalculation;

namespace WebApi.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Domain.Entities.TaxCalculation, TaxCalculationGetModel>();
        }
    }
}
