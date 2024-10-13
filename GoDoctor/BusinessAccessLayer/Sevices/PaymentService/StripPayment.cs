using DataAccessLayer.Data.Models;
using DataAccessLayer.UnitOfWorkRepo;
using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BusinessAccessLayer.Sevices.PaymentService;

namespace BusinessAccessLayer.Services.PaymentService
{
    public class StripPayment : IPayment 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        public StripPayment(IUnitOfWork unitOfWork , IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public async Task<PaymentResult> Payment(Booking booking)
        {
            // Set the Stripe secret API key
            StripeConfiguration.ApiKey = configuration["Stripe:PublishableKey"];
            var domain = "https://localhost:44326";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"/Booking/BookingConfirmation?bookId={booking.Id}",
                CancelUrl = domain + $"/Booking/BookingConfirmation?bookId={booking.Id}",
            };
            var sessionLineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)booking.FinalPrice*100,
                    Currency = "egp",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Booking for " + booking.Id,  // Product name
                        Description = "Description of the booking.",  // Optional description
                    }
                },
                Quantity = 1,
            };
            options.LineItems.Add(sessionLineItem);
            var service = new SessionService();
            Session session = service.Create(options);
            if (session == null)
            {
                return new PaymentResult()
                {
                    status = false,
                    Massage = "wrong in complete payment"
                };
            }
            return new PaymentResult()
            {
                status = true,
                Massage = "complete payment",
                session = session
            };
        }


        public string PaymentStatus(string sessionId)
        {
            var service = new SessionService();
            Session session = service.Get(sessionId);
            return session.PaymentStatus.ToLower();
        }
        public Session PaymentSession(string sessionId)
        {
            var service = new SessionService();
            Session session = service.Get(sessionId);
            return session;
        }
        public async Task<PaymentResult> CancelPayment(string paymentIntentId)
        {
            // Set the Stripe API key
            StripeConfiguration.ApiKey = configuration["Stripe:PublishableKey"];

            var service = new PaymentIntentService();
            try
            {
                PaymentIntent paymentIntent = await service.CancelAsync(paymentIntentId);
                if (paymentIntent.Status == "canceled")
                {
                    return new PaymentResult()
                    {
                        status = true,
                        Massage = "Payment successfully canceled"
                    };
                }
                else
                {
                    return new PaymentResult()
                    {
                        status = false,
                        Massage = "Failed to cancel the payment"
                    };
                }
            }
            catch (System.Exception ex)
            {
                return new PaymentResult()
                {
                    status = false,
                    Massage = $"Error in canceling payment: {ex.Message}"
                };
            }
        }
    }
}
