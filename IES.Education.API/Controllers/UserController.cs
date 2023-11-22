using IES.Domain.Interfaces.UnitOfWork;
using IES.Education.API.Models;
using IES.Services.DTO.DTO;
using IES.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMapper;
using IES.Services.Services;
using IES.Domain.Entities.Models;

namespace IES.Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("SignUp")]
        [HttpPost]
        public async Task<object> SignUp(SignUpModel userViewModel)
        {
            return await userService.SignUp(TypeAdapter.Adapt<UserDTO>(userViewModel));
        }

        [Route("SignIn")]
        [HttpPost]
        public async Task<object> SignIn(SignInModel userViewModel)
        {
            return await userService.SignIn(TypeAdapter.Adapt<UserDTO>(userViewModel));
        }

        [Route("ChangePassword")]
        [HttpPost]
        public async Task<object> ChangePassword(string email, string oldPassword, string newPassword)
        {
            return await userService.ChangePassword(email, oldPassword, newPassword);
        }

        [Route("All")]
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return TypeAdapter.Adapt<IEnumerable<UserViewModel>>(await userService.GetAllAsync());
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<string> Delete(string roleId)
        {
            return await userService.DeleteUser(roleId);
        }

        //[Route("PaymentProcedure")]
        //[HttpPost]
        //public IActionResult Processing(string stripeToken, string stripeEmail)
        //{
        //    var optionsCust = new CustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        Name = "Robert",
        //        Phone = "04-234567"

        //    };
        //    var serviceCust = new CustomerService();
        //    Customer customer = serviceCust.Create(optionsCust);
        //    var optionsCharge = new ChargeCreateOptions
        //    {
        //        /*Amount = HttpContext.Session.GetLong("Amount")*/
        //        Amount = Convert.ToInt64(TempData["TotalAmount"]),
        //        Currency = "USD",
        //        Description = "Buying Flowers",
        //        Source = stripeToken,
        //        ReceiptEmail = stripeEmail,

        //    };
        //    var service = new ChargeService();
        //    Charge charge = service.Create(optionsCharge);
        //    if (charge.Status == "succeeded")
        //    {
        //        string BalanceTransactionId = charge.BalanceTransactionId;
        //        ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
        //        ViewBag.BalanceTxId = BalanceTransactionId;
        //        ViewBag.Customer = customer.Name;
        //        //return View();
        //    }

        //    return View();
        //}
    }
}