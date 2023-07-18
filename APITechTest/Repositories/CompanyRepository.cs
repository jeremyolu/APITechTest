using APITechTest.Models;

namespace APITechTest.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public List<Company> GetCompaniesList()
        {
            return new List<Company>
            {
                new Company { Id = 1001, Name = "Jezza Limited", Address1 = "Floor 2, Tamwell Building", Address2 = "Clancey Street",
                    Address3 = "London", Postcode = "EC21 9NA", Country = "United Kingdom", InsuranceEndDate = DateTime.Now.AddDays(-10) },
                new Company { Id = 1002, Name = "CarPlus Insurance", Address1 = "20 Hinding Square", Address2 = "Hinds Street",
                    Address3 = "Birmingham", Postcode = "B1 2DF", Country = "United Kingdom", InsuranceEndDate = DateTime.Now.AddDays(18) },
                new Company { Id = 1003, Name = "Jezza Limited", Address1 = "Floor 12, St Joseph Plaza", Address2 = "Rys Lane",
                    Address3 = "London", Postcode = "N3 8SP", Country = "United Kingdom", InsuranceEndDate = DateTime.Now.AddMonths(5) },
                new Company { Id = 1004, Name = "Blue Balloon Ltd", Address1 = "Floor 5, Scue Plaza", Address2 = "Clarion Street",
                    Address3 = "Liverpool", Postcode = "LV1 5SB", Country = "United Kingdom", InsuranceEndDate = DateTime.Now.AddDays(22) },
                new Company { Id = 1005, Name = "Jezza Limited", Address1 = "Floor 28, St. Michaels", Address2 = "Myles Street",
                    Address3 = "London", Postcode = "EN3 6SA", Country = "United Kingdom", InsuranceEndDate = DateTime.Now.AddDays(-4) },
                new Company { Id = 1006, Name = "Aixis International", Address1 = "Floor 18, IG Building", Address2 = "Lower Parliment Street",
                    Address3 = "Nottingham", Postcode = "NG1 1RR", Country = "United Kingdom", InsuranceEndDate = DateTime.Now.AddDays(7) },
                new Company { Id = 1007, Name = "J", Address1 = "Floor 13, Metro Square", Address2 = "Blues Lane",
                    Address3 = "Nottingham", Postcode = "EN8 6SC", Country = "United Kingdom", InsuranceEndDate = DateTime.Now.AddDays(-15) },
                new Company { Id = 1009, Name = "FlexiHeath", Address1 = "Floor 1A", Address2 = "Lax Way",
                    Address3 = "Manchester", Postcode = "MN3 8DO", Country = "United Kingdom", InsuranceEndDate = DateTime.Now.AddMonths(2) },

            };
        }

        public Company? GetCompanyById(int id)
        {
            var company = GetCompaniesList().FirstOrDefault(c => c.Id == id);

            if (company == null)
            {
                return null;
            }

            return company;
        }
    }

    public interface ICompanyRepository
    {
        List<Company> GetCompaniesList();
        Company? GetCompanyById(int id);
    }
}
