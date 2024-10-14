using TIC.DomainModel;
using TIC.DomainModel.Request;
using TIC.ServiceAdapter;

namespace TIC.DomainAPI.Impl
{
    public class InsuranceDomain : IInsuranceDomain
    {
        private readonly IInsuranceProvider _insuranceProvider;

        public InsuranceDomain(IInsuranceProvider insuranceProvider)
        {
            _insuranceProvider = insuranceProvider;
        }

        public IEnumerable<Insurance> GetInsurances(GetInsurancesRequest getInsurancesRequest)
        {
            return _insuranceProvider.GetInsurances();
        }

        public void AddInsurance(Insurance insurance)
        {
            _insuranceProvider.AddInsurance(insurance);
        }

        public IEnumerable<TravelInsurance> GetDutchTravelInsurances()
        {
            return _insuranceProvider.GetDutchInsurances();
        }
    }
}