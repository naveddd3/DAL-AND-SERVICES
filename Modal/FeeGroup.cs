namespace St.ColumbusERP.Models
{
    public class FeeGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public string Description { get; set; }

        public string FromClass { get; set; }
        public string ToClass { get; set; }
    }
}
