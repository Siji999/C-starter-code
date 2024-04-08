namespace soft20181_starter.Models
{
    public class MyAppUserEvent
    {
        public string MyAppUserId { get; set; }
        public MyAppUser MyAppUser { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
