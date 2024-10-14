using Microsoft.AspNetCore.Mvc;
using TIC.DomainAPI;
using TIC.WebAPI.Mappers;
using TIC.WebAPI.Models;
using TIC.WebAPI.Models.Requests;
using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InsuranceController : ControllerBase
    {
        private readonly ILogger<InsuranceController> _logger;
        private readonly IInsuranceDomain _insuranceDomain;
        private readonly IGetInsurancesRequestMapper _getInsurancesRequestMapper;
        private readonly IGetInsurancesResponseMapper _getInsurancesResponseMapper;
        private readonly IAddInsuranceRequestMapper _addInsuranceRequestMapper;
        private readonly IGetDutchInsurancesResponseMapper _getDutchInsurancesResponseMapper;

        public InsuranceController(ILogger<InsuranceController> logger,
            IInsuranceDomain insuranceDomain,
            IGetInsurancesRequestMapper getInsurancesRequestMapper,
            IGetInsurancesResponseMapper getInsurancesResponseMapper,
            IAddInsuranceRequestMapper addInsuranceRequestMapper,
            IGetDutchInsurancesResponseMapper getDutchInsurancesResponseMapper)
        {
            _logger = logger;
            _insuranceDomain = insuranceDomain;
            _getInsurancesRequestMapper = getInsurancesRequestMapper;
            _getInsurancesResponseMapper = getInsurancesResponseMapper;
            _addInsuranceRequestMapper = addInsuranceRequestMapper;
            _getDutchInsurancesResponseMapper = getDutchInsurancesResponseMapper;
        }

        [HttpPost(Name = "GetInsurances")]
        public GetInsurancesResponse GetInsurances(GetInsurancesRequest request)
        {
            try
            {
                var domainRequest = _getInsurancesRequestMapper.Map(request);
                var insurances = _insuranceDomain.GetInsurances(domainRequest);
                var mappedResponse = _getInsurancesResponseMapper.Map(insurances);
                return mappedResponse;
            }
            catch (Exception exception)
            {
                _logger.Log(LogLevel.Error, exception, exception.Message);
                throw;
            }
        }

        [HttpPost(Name = "AddInsurance")]
        public void AddInsurance(AddInsuranceRequest request)
        {
            try
            {
                var domainRequest = _addInsuranceRequestMapper.Map(request);
                _insuranceDomain.AddInsurance(domainRequest);
            }
            catch (Exception exception)
            {
                _logger.Log(LogLevel.Error, exception, exception.Message);
                throw;
            }
        }
        // <summary>
        //We can achieve this GetDutchTravelInsurances by 2 ways , 1 by reusing GetInsurances from domain and use the conditions
        // but  If GetAllInsurances retrieves a large dataset and we only need a small subset,
        // it may lead to unnecessary data being processed.
        //</summary>
        [HttpPost(Name = "GetDutchTravelInsurances")]
        public GetDutchTravelInsuranceResponse GetDutchTravelInsurances()
        {
            try
            {
                //        var insurances = _insuranceDomain.GetInsurances(domainRequest).OfType<TravelInsurance>()
                //.Where(x => x.Coverage.Any(c => c.Code.Equals("NL", StringComparison.OrdinalIgnoreCase)))
                //.ToList();
                var insurances = _insuranceDomain.GetDutchTravelInsurances();
                var mappedResponse = _getDutchInsurancesResponseMapper.Map(insurances);


                return mappedResponse;
            }
            catch (Exception exception)
            {
                _logger.Log(LogLevel.Error, exception, exception.Message);
                throw;
            }
        }
    }
}