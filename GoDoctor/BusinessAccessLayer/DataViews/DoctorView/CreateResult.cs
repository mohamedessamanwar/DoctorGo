namespace BusinessAccessLayer.DataViews.DoctorView
{
    public class CreateResult
    {
        public bool IsAdded { get; set; } = true;
        public string Errors { get; set; } = string.Empty;
    }
}