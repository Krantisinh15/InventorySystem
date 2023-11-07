using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace InvoiceProjectMVCCore.Services.Implementation
{
    public class TblUnitRepository : ItblUnitsRepository
    {
        InvoiceProjectContext db;
        public TblUnitRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddUnit(Tblunit unit)
        {
           db.Tblunits.Add(unit);
            db.SaveChanges();
        }

        public void DeleteUnit(int unit_id)
        {
           Tblunit t=db.Tblunits.Find(unit_id);
            db.Tblunits.Remove(t);
            db.SaveChanges();
        }

        public List<UnitModel> GetallUnit()
        {
            List<UnitModel> lst=new List<UnitModel>();

            foreach(Tblunit u in db.Tblunits.ToList())
            {
                UnitModel model = new UnitModel()
                {
                    Unit_id=u.UnitId,
                    Unit_name=u.UnitName,

                };
                lst.Add(model);
            }
            return lst;
        }

        public UnitModel getunitbyid(int unit_id)
        {
           UnitModel model = GetallUnit().FirstOrDefault(e=>e.Unit_id.Equals(unit_id));
            return model;
        }

        public void UpdateUnit(Tblunit unit)
        {
           db.Tblunits.Update(unit);
            db.SaveChanges();
        }
    }
}
