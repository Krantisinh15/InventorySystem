using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblVenderRepository
    {
        List<VenderModel> getallvender(int id);
        //VenderModel getvenderbyid(int vender_id);
        void Addvender(Tblvender vender);
        void Updatevender(Tblvender vender);
        void Deletevender(int vender_Id);
    }
}
