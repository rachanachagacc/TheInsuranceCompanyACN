
using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers;

public interface IGetDutchInsurancesResponseMapper
{
    GetDutchTravelInsuranceResponse Map(IEnumerable<DomainModel.TravelInsurance> insurances);
}

