namespace BusinessAccessLayer.Sevices.BookingService
{
    public class BookingResult
    {
        public string Errors { get; set; }
        public bool IsBook {  get; set; }
        public string SessionId { get; set; }
    }
}