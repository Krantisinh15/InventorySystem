using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblstateRepository
    {
        List<StateModel> getallstates();
        StateModel GetState(int state_id);
        void AddState(Tblstate state);
        void Updatestate(Tblstate state);
        void Deletestate(int state_id);
    }
}
