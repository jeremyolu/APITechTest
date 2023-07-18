namespace APITechTest.Models.API
{
    public class CompanyClaimsResponse
    {
        public int ClaimsTotal { get; set; }
        public Company? Company { get; set; }
        public IEnumerable<Claim>? Claims { get; set; }
    }
}
