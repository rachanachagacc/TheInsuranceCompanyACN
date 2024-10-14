using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TIC.WebAPI.Controllers;
using TIC.DomainAPI;
using TIC.WebAPI.Models.Responses;
using Microsoft.Extensions.Logging;
using TIC.DomainModel;
using TIC.WebAPI.Mappers;
using TIC.WebAPI.Mappers.Impl;

[TestClass]
public class InsuranceControllerTests
{
    private Mock<ILogger<InsuranceController>> _loggerMock;
    private Mock<IInsuranceDomain> _insuranceDomainMock;
    private InsuranceController _controller;
    private Mock<IGetDutchInsurancesResponseMapper> _mapper;

    [TestInitialize]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<InsuranceController>>();
        _insuranceDomainMock = new Mock<IInsuranceDomain>();
        _mapper = new Mock<IGetDutchInsurancesResponseMapper>();
        _controller = new InsuranceController(_loggerMock.Object, _insuranceDomainMock.Object, null, null, null, _mapper.Object);
    }

    [TestMethod]
    public void GetDutchTravelInsurances_ReturnsExpectedResponse_WhenInsurancesExist()
    {
        // Arrange
        var travelInsurances = new List<TravelInsurance>
        {
            new TravelInsurance
            {
                Name = "Best Travel Insurance",
                Description = "Covers travel in the Netherlands",
                InsurancePremium = 20m,
                InsuredAmount = 7000
            }
        };
        var res =
          new GetDutchTravelInsuranceResponse
          {
              DutchTravelInsurances = new List<TravelInsuranceDto>
              {
                  new TravelInsuranceDto
                { Name = "Adventure Travel", Description = "Adventure coverage", InsurancePremium = 150m, InsuredAmount = 75000m }
              }
          };
      

        _insuranceDomainMock.Setup(x => x.GetDutchTravelInsurances()).Returns(travelInsurances);
        _mapper.Setup(x => x.Map(travelInsurances)).Returns(res);
        // Act
        var response = _controller.GetDutchTravelInsurances();

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType(response, typeof(GetDutchTravelInsuranceResponse));
        var travelInsuranceList = response.DutchTravelInsurances.ToList(); 
        Assert.AreEqual(1, travelInsuranceList.Count);
        Assert.AreEqual("Adventure Travel", travelInsuranceList[0].Name); 
    }

    [TestMethod]
    public void GetDutchTravelInsurances_ReturnsEmptyResponse_WhenNoInsurancesExist()
    {
        // Arrange
        var travelInsurances = new List<TravelInsurance>();
        _insuranceDomainMock.Setup(x => x.GetDutchTravelInsurances()).Returns(travelInsurances);

        // Act
        var response = _controller.GetDutchTravelInsurances();

        // Assert
        Assert.IsNull(response); 
    }


    [TestMethod]
    public void GetDutchTravelInsurances_ThrowsException_WhenUnhandledExceptionOccurs()
    {
        // Arrange
        _insuranceDomainMock.Setup(x => x.GetDutchTravelInsurances()).Throws(new InvalidOperationException("Unhandled exception"));

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() => _controller.GetDutchTravelInsurances());
    }
}
