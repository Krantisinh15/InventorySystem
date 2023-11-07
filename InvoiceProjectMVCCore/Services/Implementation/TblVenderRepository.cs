using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace InvoiceProjectMVCCore.Services.Implementation
{
    public class TblVenderRepository : ITblVenderRepository
    {
        InvoiceProjectContext db;
        public TblVenderRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void Addvender(Tblvender vender)
        {
           db.Tblvenders.Add(vender);
            db.SaveChanges();
        }

        public void Deletevender(int vender_Id)
        {
           Tblvender vender=db.Tblvenders.Find(vender_Id);
            db.Tblvenders.Remove(vender);
                db.SaveChanges();
        }

        public List<VenderModel> getallvender(int id)
        {
            List<VenderModel>lst=new List<VenderModel>();
            foreach (Tblvender v in db.Tblvenders.ToList())
            {
                if(v.UserId== id)
                {
                    VenderModel ven = new VenderModel()
                    {
                        Vender_id = v.VenderId,
                        Vender_name = v.VenderName,
                        Email_address = v.EmailAddress,
                        Mobile_no = v.MobileNo,
                        User_id = (int)v.UserId,
                    };
                    lst.Add(ven);
                }
              
            }
            return lst;
        }

        //public VenderModel getvenderbyid(int vender_id)
        //{
        //    VenderModel Model=getallvender().FirstOrDefault(e=>e.Vender_id.Equals(vender_id));
        //    return Model;
        //}

        public void Updatevender(Tblvender vender)
        {
            db.Tblvenders.Update(vender);
            db.SaveChanges();
        }
    }
}
