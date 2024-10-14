using TIC.DomainModel;
using TIC.WebAPI.Models.Responses;
using System.Collections.Generic;
using System.Linq;

namespace TIC.WebAPI.Mappers.Impl
{
    public class GetDutchInsurancesResponseMapper : IGetDutchInsurancesResponseMapper
    {
        public GetDutchTravelInsuranceResponse Map(IEnumerable<DomainModel.TravelInsurance> insurances)
        {
            return new GetDutchTravelInsuranceResponse
            {
                DutchTravelInsurances = insurances?.Select(insurance => new TravelInsuranceDto 
                {
                    Name = insurance.Name,
                    Description = insurance.Description,
                    InsurancePremium = insurance.InsurancePremium,
                    InsuredAmount = insurance.InsuredAmount,
                }).ToList() ?? new List<TravelInsuranceDto>() 
            };
        }
    }
}
