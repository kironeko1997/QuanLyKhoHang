using Microsoft.AspNetCore.Mvc;
using QuanLyKhoHang.AccountService.Application;
using QuanLyKhoHang.AccountService.Domain;
using QuanLyKhoHang.AccountService.Models;

namespace QuanLyKhoHang.AccountService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult GetAll(AccountSearchModel searchModel)
        {
            var accounts = _accountService.GetAll(searchModel);

            if (accounts.Count > 0)
            {
                return Ok(accounts);
            }
            else
            {
                return Ok("Account list empty or search not matches!");
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var account = _accountService.Get(id);

            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return BadRequest("Account not available or has been deleted!");
            }
        }

        [HttpPost]
        public IActionResult LogIn(string username, string password)
        {
            var account = _accountService.Get(username, password);

            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return BadRequest("Username or Password is incorrect!");
            }
        }

        [HttpPost]
        public IActionResult ChangePassword(int id, string newPassword, string confirmPassword)
        {
            var account = _accountService.Get(id);

            if (account != null)
            {
                if (newPassword == confirmPassword)
                {
                    account.Password = newPassword;

                    _accountService.Update(account);

                    return Ok("Password has been updated successfully!");
                }
                else
                {
                    return BadRequest("Your confirm password not match new password!");
                }
            }
            else
            {
                return BadRequest("Account not available or has been deleted!");
            }
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            _accountService.Create(account);

            if (account.Id != 0)
            {
                return Ok("Account has been created successfully! Account id is: " + account.Id);
            }
            else
            {
                return BadRequest("Something wrong!");
            }
        }

        [HttpPost]
        public IActionResult Update(Account account)
        {
            _accountService.Update(account);

            return Ok("Account has been updated successfully!");
        }

        [HttpDelete]
        public IActionResult Delete(Account account)
        {
            _accountService.Delete(account);

            return Ok("Account has been deleted successfully!");
        }
    }
}
