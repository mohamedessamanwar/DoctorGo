using BusinessAccessLayer.Sevices.PaymentService;
using DataAccessLayer.Data.Models;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.PaymentService
{
    public interface IPayment
    {
        Task<PaymentResult> Payment(Booking booking);
        Session PaymentSession(string sessionId);
        string PaymentStatus(string sessionId);
       // Task<int> UpdateStripePaymentId(int BookId, string id, string paymentIntentId);

        Task<PaymentResult> CancelPayment(string paymentIntentId);
    }
}
