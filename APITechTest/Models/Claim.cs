namespace APITechTest.Models
{
    public class Claim
    {
        public int? Id { get; set; }
        public string? UCR { get; set; }
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string? AssuredName { get; set; }
        public decimal? IncurredLoss { get; set; }
        public bool Closed { get; set; }
        public int ClaimInDays
        {
            get 
            {
                var duration = DateTime.Now - ClaimDate;

                return duration.Days;
            }
        }
    }
}
