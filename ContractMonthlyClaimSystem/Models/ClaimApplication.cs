namespace ContractMonthlyClaimSystem.Models
{
    public class ClaimApplication: ApprovalActivity
    {
        public int Id { get; set; }

        public int LectureId { get; set; }

        public Lecturers Lecture { get; set; }

        public int NumOfDays { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DurationId { get; set; }

        public SystemCodeDetail Duration {  get; set; }

        public int ClaimTypeId { get; set; }

        public ClaimType ClaimType { get; set; }

        public string? Attachment { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        public SystemCodeDetail Status { get; set; }
    }
}
