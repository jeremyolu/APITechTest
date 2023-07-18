using APITechTest.Models;

namespace APITechTest.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        public List<Claim> GetClaimsList()
        {
            return new List<Claim>()
            {
                new Claim { Id = 25412, CompanyId = 1001, ClaimDate = DateTime.Now.AddMonths(-3).AddDays(13), LossDate = DateTime.Now.AddMonths(-3).AddDays(8), 
                    AssuredName = "Ana Rodiguez", Closed = false, IncurredLoss = 1789.29m, UCR = "22001" },
                new Claim { Id = 37652, CompanyId = 1001, ClaimDate = DateTime.Now.AddMonths(-6).AddDays(27), LossDate = DateTime.Now.AddMonths(-6).AddDays(25),
                    AssuredName = "Tim Webb", Closed = false, IncurredLoss = 1789.29m, UCR = "22002" },
                new Claim { Id = 96527, CompanyId = 1002, ClaimDate = DateTime.Now.AddMonths(-2).AddDays(14), LossDate = DateTime.Now.AddMonths(-2).AddDays(5),
                    AssuredName = "Roman Pandev", Closed = false, IncurredLoss = 1789.29m, UCR = "22003" },
                new Claim { Id = 42630, CompanyId = 1003, ClaimDate = DateTime.Now.AddMonths(-2), LossDate = DateTime.Now.AddMonths(-1).AddDays(2),
                    AssuredName = "Mary Sweather", Closed = false, IncurredLoss = 1789.29m, UCR = "22004" }
            };
        }

        public Claim? GetClaimById(int id)
        {
            var claim = GetClaimsList().FirstOrDefault(c => c.Id == id);

            if (claim == null)
            {
                return null;
            }

            return claim;
        }

        public List<ClaimType> GetClaimsTypeList()
        {
            return new List<ClaimType>()
            {
                new ClaimType { Id = 1101, Name = "Burglary and Theft" },
                new ClaimType { Id = 1102, Name = "Property Damage" },
                new ClaimType { Id = 1103, Name = "Fire" },
                new ClaimType { Id = 1104, Name = "Customer Injury" },
                new ClaimType { Id = 1105, Name = "Product Liability" },
                new ClaimType { Id = 1106, Name = "Auto Accident" }
            };
        }
    }

    public interface IClaimRepository
    {
        List<Claim> GetClaimsList();
        List<ClaimType> GetClaimsTypeList();
        Claim? GetClaimById(int id);
    }
}
