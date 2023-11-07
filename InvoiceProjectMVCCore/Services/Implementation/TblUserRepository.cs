using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace InvoiceProjectMVCCore.Services.Implementation
{
    public class TblUserRepository : ITblUserRepository
    {
        InvoiceProjectContext db;
        public TblUserRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddUser(Tbluser user)
        {
           db.Tblusers.Add(user);
            db.SaveChanges();
        }

        public void DeleteUser(int user_id)
        {
            Tbluser user=db.Tblusers.Find(user_id);
            db.Tblusers.Remove(user);
            db.SaveChanges();
        }

        public List<UserModel> Getallusers()
        {
           List<UserModel>lst=new List<UserModel>();
            foreach(Tbluser u in db.Tblusers.ToList())
            {
                Tbllocation l = db.Tbllocations.Find(u.LocationId);
                UserModel model = new UserModel()
                {
                    User_id=u.UserId,
                    User_name=u.UserName,
                    User_photo=u.UserPhoto,
                    Email_Address=u.EmailAddress,
                    MobileNumber=u.MobileNumber,
                    password=u.Password,
                    Unique_code=u.UniqueCode,
                    location_id=l.LocationId,
                    location_name=l.Location,
                    flag=(int)u.Flag,
                    
                };
                lst.Add(model);
            }
            return lst;
        }

        public UserModel getuserbyid(int user_id)
        {
            UserModel user=Getallusers().FirstOrDefault(e=>e.User_id.Equals(user_id));
            return user;
        }

        public void Update(Tbluser user)
        {
            db.Tblusers.Update(user);
            db.SaveChanges();
        }
    }
}
