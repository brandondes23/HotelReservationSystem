using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public DateTime ExpDate { get; set; }
        public string CVV { get; set; }

        public Payment(double amount, string method, string cardNumber, string cardName, DateTime expDate, string cvv)
        {
            this.Amount = amount;
            this.PaymentMethod = method;
            this.CardNumber = cardNumber;
            this.CardName = cardName;
            this.ExpDate = expDate;
            this.CVV = cvv;
            this.PaymentDate = DateTime.Now;
        }

        public bool ProcessPayment() // Process payment if credit card is used
        {
            if (this.PaymentMethod == "Credit Card" && this.Amount > 0)
            {
                Console.WriteLine("Payment processed successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Payment processing failed.");
                return false;
            }
        }

        public bool PaymentValidation() // Validate credit card number if over 16 digits
        {
            if (this.CardNumber.Length == 16)
            {
                Console.WriteLine("Card number is valid.");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid card number.");
                return false;
            }
        }

        public bool RefundPayment() // For refunding payment
        {
            if (this.Amount > 0)
            {
                Console.WriteLine($"Refund of {this.Amount} processed successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Refund failed. Invalid amount.");
                return false;
            }
        }
    }
}
