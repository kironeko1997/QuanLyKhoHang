using QuanLyKhoHang.AccountService.Domain;
using QuanLyKhoHang.AccountService.Models;

namespace QuanLyKhoHang.AccountService.Application
{
    public class AccountService : IAccountService
    {
        private readonly AccountDbContext _accountDbContext;

        public AccountService(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public List<Account> GetAll(AccountSearchModel? searchModel)
        {
            var accounts = _accountDbContext.Accounts.ToList();

            if (searchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Filter))
                {
                    accounts = accounts.Where(x => x.Username.Trim().ToLower().Contains(searchModel.Filter.Trim().ToLower()) || 
                    x.FullName.Trim().ToLower().Contains(searchModel.Filter.Trim().ToLower()) || 
                    x.Phone.Trim().ToLower().Contains(searchModel.Filter.Trim().ToLower())).ToList();
                }

                if (searchModel.Active.HasValue)
                {
                    accounts = accounts.Where(x => x.Active == searchModel.Active.Value).ToList();
                }
            }

            return accounts;
        }

        public Account? Get(int id)
        {
            return _accountDbContext.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public Account? Get(string username, string password)
        {
            return _accountDbContext.Accounts.FirstOrDefault(x => x.Username == username && x.Password == password);
        }


        public Account Create(Account account)
        {
            _accountDbContext.Accounts.Add(account);
            _accountDbContext.SaveChanges();

            return account;
        }

        public Account Update(Account account)
        {
            _accountDbContext.Accounts.Update(account);
            _accountDbContext.SaveChanges();
            return account;
        }

        public void Delete(Account account)
        {
            _accountDbContext.Accounts.Remove(account);
            _accountDbContext.SaveChanges();
        }
    }
}
