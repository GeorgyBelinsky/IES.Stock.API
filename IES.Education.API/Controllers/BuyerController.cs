using IES.Services.DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Stock.API.Controllers
{
    public class BuyerController : Controller
    {
        [Route("PaymentProcedure")]
        [HttpPost]
        public IActionResult Processing(string stripeToken, UserDTO user, int total)
        {
            var optionsCust = new CustomerCreateOptions
            {
                Email = user.Email,
                Name = user.FirstName + " " + user.LastName
            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionsCust);
            var optionsCharge = new ChargeCreateOptions
            {
                /*Amount = HttpContext.Session.GetLong("Amount")*/
                Amount = total,
                Currency = "USD",
                Description = "Stock market",
                Source = stripeToken,
                ReceiptEmail = user.Email,

            };
            var service = new ChargeService();
            Charge charge = service.Create(optionsCharge);
            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                ViewBag.BalanceTxId = BalanceTransactionId;
                ViewBag.Customer = customer.Name;
                //return View();
            }

            return View();
        }
    }
}
