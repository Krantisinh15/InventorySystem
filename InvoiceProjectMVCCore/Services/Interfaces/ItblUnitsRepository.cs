using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ItblUnitsRepository
    {
        List<UnitModel> GetallUnit();
        UnitModel getunitbyid(int unit_id);
        void AddUnit(Tblunit unit);
        void UpdateUnit(Tblunit unit);  
        void DeleteUnit(int unit_id);
    }
}
