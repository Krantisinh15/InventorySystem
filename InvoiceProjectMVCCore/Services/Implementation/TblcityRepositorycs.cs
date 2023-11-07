using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblcityRepositorycs : ItblcityRepository
    {
        InvoiceProjectContext db;
        public TblcityRepositorycs(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void Addcity(Tblcity city)
        {
            db.Tblcities.Add(city);
            db.SaveChanges();
        }

        public void Deletecity(int id)
        {
            Tblcity city = db.Tblcities.Find(id);
            db.Tblcities.Remove(city);
            db.SaveChanges();
        }

        public List<CityModel> Getallcity()
        {
           List<CityModel>lst=new List<CityModel> ();
            foreach(Tblcity c in db.Tblcities.ToList())
            {
                Tblstate s = db.Tblstates.Find(c.StateId);
                CityModel m = new CityModel()
                {
                    City_id = c.CityId,
                     City_name=c.CityName,
                     State_id=s.StateId,
                     State_name=s.StateName,
                

                };
                lst.Add(m);
            }
            return lst;
        }

        public CityModel Getcity(int id)
        {
           CityModel model=Getallcity().FirstOrDefault(e=>e.City_id.Equals(id));
            return model;
        }

        public void Updatecity(Tblcity city)
        {
            db.Tblcities.Update(city);
            db.SaveChanges();
        }
    }
}
