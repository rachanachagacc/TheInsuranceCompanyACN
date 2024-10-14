
using TIC.ServiceAdapter.Mappers;
using TIC.ServiceAdapter.Models;
using TIC.ServiceAdapter.Stubs;

namespace TIC.ServiceAdapter
{
    /// <summary>
    /// DO NOT MODIFY. The Provieder simply mimics a database for the porpuse of this test.
    /// </summary>
    public class InsuranceProvider : IInsuranceProvider
    {
        public void AddInsurance(DomainModel.Insurance insurance)
        {
            DatabaseStub.Add(new LiabilityInsurance());
        }

        public IEnumerable<DomainModel.Insurance> GetInsurances()
        {
            var insurances = DatabaseStub.GetAllInsurances();
            return insurances.Map();
        }
        public IEnumerable<DomainModel.TravelInsurance> GetDutchInsurances()
        {
            var travelInsurance = DatabaseStub.GetAllDutchInsurances();
            return travelInsurance.Map().OfType<DomainModel.TravelInsurance>();
        }

    }
}