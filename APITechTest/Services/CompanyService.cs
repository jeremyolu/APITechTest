using APITechTest.Models;
using APITechTest.Repositories;

namespace APITechTest.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public List<Company> GetCompanies()
        {
            var companies = _companyRepository.GetCompaniesList();

            SetActiveInsurancePolicy(companies);

            return companies;
        }

        public Company? GetCompanyById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var company = _companyRepository.GetCompaniesList().FirstOrDefault(c => c.Id == id);

            if (company == null)
            {
                return null;
            }

            return company;
        }

        public List<Company> SetActiveInsurancePolicy(List<Company> companies)
        {
            foreach (var company in companies)
            {
                if (company.InsuranceEndDate > DateTime.Now)
                {
                    company.Active = true;
                }
            }

            return companies;
        }
    }

    public interface ICompanyService
    {
        List<Company> GetCompanies();
        Company? GetCompanyById(int? id);
        List<Company> SetActiveInsurancePolicy(List<Company> companies);
    }
}
