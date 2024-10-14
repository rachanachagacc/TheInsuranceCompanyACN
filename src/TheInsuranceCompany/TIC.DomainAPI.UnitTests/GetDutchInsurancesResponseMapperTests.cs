using Microsoft.VisualStudio.TestTools.UnitTesting;
using TIC.DomainModel;
using TIC.WebAPI.Models.Responses;
using TIC.WebAPI.Mappers.Impl;
using System.Collections.Generic;
using System.Linq;

namespace TIC.WebAPI.Tests.Mappers
{
    [TestClass]
    public class GetDutchInsurancesResponseMapperTests
    {
        private GetDutchInsurancesResponseMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _mapper = new GetDutchInsurancesResponseMapper();
        }

        [TestMethod]
        public void Map_ReturnsMappedTravelInsurances_WhenInsurancesExist()
        {
            // Arrange
            var insurances = new List<TravelInsurance>
            {
                new TravelInsurance { Name = "Adventure Travel", Description = "Adventure coverage", InsurancePremium = 150m, InsuredAmount = 75000m },
                new TravelInsurance { Name = "Business Travel", Description = "Business coverage", InsurancePremium = 250m, InsuredAmount = 150000m }
            };

            // Act
            var response = _mapper.Map(insurances);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.DutchTravelInsurances);
            Assert.AreEqual(2, response.DutchTravelInsurances.Count());
            Assert.AreEqual("Adventure Travel", response.DutchTravelInsurances.First().Name);
        }

        [TestMethod]
        public void Map_ReturnsEmptyList_WhenNoInsurancesExist()
        {
            // Arrange
            var insurances = new List<TravelInsurance>(); 

            // Act
            var response = _mapper.Map(insurances);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.DutchTravelInsurances);
            Assert.AreEqual(0, response.DutchTravelInsurances.Count());
        }

        [TestMethod]
        public void Map_ReturnsEmptyList_WhenInputIsNull()
        {
            // Arrange
            IEnumerable<TravelInsurance> insurances = null; 

            // Act
            var response = _mapper.Map(insurances);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.DutchTravelInsurances);
            Assert.AreEqual(0, response.DutchTravelInsurances.Count());
        }
    }
}
