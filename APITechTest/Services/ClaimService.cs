using APITechTest.Models;
using APITechTest.Models.API;
using APITechTest.Repositories;

namespace APITechTest.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly ICompanyRepository _companyRepository;

        public ClaimService(IClaimRepository claimRepository, ICompanyRepository companyRepository)
        {
            _claimRepository = claimRepository;
            _companyRepository = companyRepository;
        }

        public List<Claim> GetClaims()
        {
            var claims = _claimRepository.GetClaimsList();

            return claims;
        }

        public Claim? GetClaimById(int id)
        {
            var claim = _claimRepository.GetClaimById(id);

            if (claim == null)
            {
                return null;
            }

            return claim;
        }

        public CompanyClaimsResponse GetCompanyClaims(int id)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
            {
                return new CompanyClaimsResponse();
            }

            var companyClaims = GetClaims().Where(c => c.CompanyId == id);

            return new CompanyClaimsResponse
            {
                Company = company,
                ClaimsTotal = companyClaims.Count(),
                Claims = companyClaims
            };
        }

        public bool UpdateClaim(int? id, Claim updatedClaim)
        {
            if (id == null)
            {
                return false;
            }

            var claim = _claimRepository.GetClaimById(id.Value);

            if (claim == null)
            {
                return false;
            }

            claim.UCR = updatedClaim.UCR;
            claim.ClaimDate = updatedClaim.ClaimDate;
            claim.LossDate = updatedClaim.LossDate;
            claim.AssuredName = updatedClaim.AssuredName;
            claim.IncurredLoss = updatedClaim.IncurredLoss;
            claim.Closed = updatedClaim.Closed;

            return true;
        }
    }

    public interface IClaimService
    {
        List<Claim> GetClaims();
        Claim? GetClaimById(int id);
        CompanyClaimsResponse GetCompanyClaims(int id);
        bool UpdateClaim(int? id, Claim updatedClaim);
    }
}
