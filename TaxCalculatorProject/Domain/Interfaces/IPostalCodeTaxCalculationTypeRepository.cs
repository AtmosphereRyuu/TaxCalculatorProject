using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPostalCodeTaxCalculationTypeRepository: IGenericRepository<PostalCodeTaxCalculationType>
    {
        PostalCodeTaxCalculationType GetByPostalCode(string postalCode);
    }
}
