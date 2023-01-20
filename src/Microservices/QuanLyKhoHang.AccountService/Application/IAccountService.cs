using QuanLyKhoHang.AccountService.Domain;
using QuanLyKhoHang.AccountService.Models;

namespace QuanLyKhoHang.AccountService.Application
{
    public interface IAccountService
    {
        List<Account> GetAll(AccountSearchModel? searchModel);

        Account? Get(int id);

        Account? Get(string username, string password);

        Account Create(Account account);

        Account Update(Account account);

        void Delete(Account account);
    }
}
