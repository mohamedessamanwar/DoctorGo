using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class Booking : BaseEntity
    {

        //public int DoctorId { get; set; }
        //public Docktor Doctor { get; set; }
        public  TimeSlot TimeSlot { get; set; }
        public int TimeSlotId { get; set; }
        public string BookingState { get; set; }
        public decimal FinalPrice { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }



    }
}
