using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblstateRepository : ITblstateRepository
    {
        InvoiceProjectContext db;
        public TblstateRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddState(Tblstate state)
        {
            db.Tblstates.Add(state);
            db.SaveChanges();
        }

        public void Deletestate(int state_id)
        {
           Tblstate t=db.Tblstates.Find(state_id);
            db.Tblstates.Remove(t);
            db.SaveChanges();
        }

        public List<StateModel> getallstates()
        {
            List<StateModel>lst=new List<StateModel> ();

            foreach(Tblstate t in db.Tblstates.ToList())
            {
                StateModel s=new StateModel()
                {
                    state_id=t.StateId,
                    state_name=t.StateName
                };
                lst.Add(s);
            }
            return lst; 
        }

        public StateModel GetState(int state_id)
        {
            StateModel s = getallstates().FirstOrDefault(e => e.state_id.Equals(state_id));
            return s;
        }

        public void Updatestate(Tblstate state)
        {
            db.Tblstates.Update(state);
            db.SaveChanges();
        }
    }
}
