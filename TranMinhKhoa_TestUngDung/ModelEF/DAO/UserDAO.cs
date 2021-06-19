using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.EF;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDAO
    {
        private TranMinhKhoaContext db = null;
        public UserDAO()
        {
            db = new TranMinhKhoaContext();
        }
        //kiểm tra đăng nhập có thành công hay không
        public int login(string user, string pass)
        {
            var kq = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
            if (kq == null)
            {
                return 0;
            }
            else
            {
                if (kq.UserName == "Admin")
                {
                    return 1;
                }
                return 0;
            }
        }
        //xóa user
        public bool Delete(int Id)
        {
            try
            {
                UserAccount ID = db.UserAccounts.Find(Id);
                if (ID.Status == "activate")
                {
                    return false;
                }
                db.UserAccounts.Remove(ID);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //tìm kiếm người dùng
        public UserAccount Find(int Id)
        {
            return db.UserAccounts.Find(Id);
        }
        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }
        //phân trang dùng IEnum thay cho list
        public IEnumerable<UserAccount> ListWhereAll(string searchKey, int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(searchKey))
            {
                model = model.Where(x => x.UserName.Contains(searchKey));
            }
            return model.OrderBy(x => x.UserName);
        }
    }
}
