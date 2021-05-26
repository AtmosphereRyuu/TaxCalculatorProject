using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repositories
{
    public class PostalCodeTaxCalculationTypeRepository: GenericRepository<PostalCodeTaxCalculationType>, IPostalCodeTaxCalculationTypeRepository
    {
        public PostalCodeTaxCalculationTypeRepository(ApplicationContext context) : base(context)
        {
        }

        public PostalCodeTaxCalculationType GetByPostalCode(string postalCode)
        {
            return Context.PostalCodeTaxCalculationTypes.FirstOrDefault(x => x.PostalCode.Equals(postalCode));
        }
    }
}
