 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe.Checkout;
using Stripe;
namespace BusinessAccessLayer.Sevices.PaymentService 
{
    public class PaymentResult
    {
        public Session? session {  get; set; }
        public string Massage { get; set; }
        public bool status { get; set; }
    }
}
