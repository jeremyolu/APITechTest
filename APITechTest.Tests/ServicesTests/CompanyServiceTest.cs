using APITechTest.Models;
using APITechTest.Repositories;
using APITechTest.Services;

namespace APITechTest.Tests.ServicesTests
{
    [TestFixture]
    public class CompanyServiceTest
    {
        private ICompanyService _companyService;

        [SetUp]
        public void SetUp()
        {
            _companyService = new CompanyService(new CompanyRepository());
        }

        [Test]
        public void SetActiveInsurancePolicy_WhenCalled_ShouldSetActivePropertyBasedOnInsuranceEndDate()
        {
            var companies = TestCompanies();

            var setActiveInsurancePolicyCompanies = _companyService.SetActiveInsurancePolicy(companies);

            Assert.That(setActiveInsurancePolicyCompanies[0].Active, Is.EqualTo(false));
            Assert.That(setActiveInsurancePolicyCompanies[1].Active, Is.EqualTo(true));
            Assert.That(setActiveInsurancePolicyCompanies[2].Active, Is.EqualTo(true));
        }

        private List<Company> TestCompanies()
        {
            return new List<Company>()
            {
                new Company { Id = 1, Name = "Test Ltd", Address1 = "130 Test Building", InsuranceEndDate = DateTime.Now.AddDays(-2) },
                new Company { Id = 2, Name = "Testflix Healthcare", Address1 = "22 Test Street", InsuranceEndDate = DateTime.Now.AddDays(2) },
                new Company { Id = 3, Name = "Testloom Digital", Address1 = "25A Test Bridge", InsuranceEndDate = DateTime.Now.AddMonths(8) }
            };
        }
    }

}
