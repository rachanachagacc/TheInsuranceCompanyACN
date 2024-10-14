using Microsoft.VisualStudio.TestTools.UnitTesting;
using TIC.ServiceAdapter.Models; // Update with your actual namespace
using TIC.ServiceAdapter.Stubs; // Update with your actual namespace
using System.Collections.Generic;

namespace TIC.ServiceAdapter.Tests
{
    [TestClass]
    public class InsuranceProviderTests
    {
        private InsuranceProvider _insuranceProvider;

        [TestInitialize]
        public void Setup()
        {
            _insuranceProvider = new InsuranceProvider();
        }

       

        [TestMethod]
        public void GetDutchInsurances_ShouldReturnOnlyDutchInsurances()
        {
            // Arrange
          

            // Act
            var result = _insuranceProvider.GetDutchInsurances();

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(result.First().Name.Equals("Best Travel Insurance"));
        }
    }
}
