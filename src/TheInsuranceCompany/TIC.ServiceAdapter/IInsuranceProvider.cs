namespace TIC.ServiceAdapter;

public interface IInsuranceProvider
{
    void AddInsurance(DomainModel.Insurance insurance);
    IEnumerable<DomainModel.Insurance> GetInsurances();
    IEnumerable<DomainModel.TravelInsurance> GetDutchInsurances();

}