using TIC.ServiceAdapter.Models;

namespace TIC.ServiceAdapter.Stubs
{
    public static class DatabaseStub
    {
        private static readonly IList<Insurance> Insurances;

        static DatabaseStub()
        {
            Insurances = new List<Insurance>
            {
                new CarInsurance
                {
                    Name = "Best Car Insurance",
                    Description = "Covers anything and everything",
                    DateOfBirth = new DateTime(1993, 10, 13),
                    InsurancePremium = 50m,
                    LicensePlate = "HF-430-V",
                    WeightInKg = 1100
                },
                new TravelInsurance
                {
                    Name = "Best Travel Insurance",
                    Coverage = new List<Country>
                    {
                        new()
                        {
                            Code = "NL",
                            Name = "Netherlands"
                        }
                    },
                    Description = "Insured whilst on the move",
                    InsurancePremium = 20,
                    InsuredAmount = 7000
                },
                new TravelInsurance
                {
                    Name = "Das Travel Insurance",
                    Coverage = new List<Country>
                    {
                        new()
                        {
                            Code = "DE",
                            Name = "Germany"
                        },
                        new()
                        {
                            Code = "ES",
                            Name = "Spain"
                        }
                    },
                    Description = "Insured whilst on the move but within Europe",
                    InsurancePremium = 20,
                    InsuredAmount = 7000
                },
                new TravelInsurance
                {
                    Name = "Cheap Travel Insurance",
                    Coverage = new List<Country>
                    {
                        new()
                        {
                            Code = "US",
                            Name = "United States of America"
                        }
                    },
                    Description = "Murica is expensive",
                    InsurancePremium = 50,
                    InsuredAmount = 25000
                },
                new LiabilityInsurance
                {
                    Name = "A* LiabilityInsurance",
                    Description = "Covers most incidents < 2.5m",
                    Excess = true,
                    ExcessAmount = 500,
                    InsurancePremium = 8,
                    InsuredAmount = 2500000
                }
            };
        }

        public static void Add(Insurance insurance)
        {
            Insurances.Add(insurance);
        }

        public static IEnumerable<Insurance> GetAllInsurances()
        {
            return Insurances;
        }
        public static IEnumerable<Insurance> GetAllDutchInsurances()
        {
            return Insurances
        .OfType<TravelInsurance>()
        .Where(x => x.Coverage.Any(c => c.Code.Equals("NL", StringComparison.OrdinalIgnoreCase)))
        .ToList();

        }
    }
}