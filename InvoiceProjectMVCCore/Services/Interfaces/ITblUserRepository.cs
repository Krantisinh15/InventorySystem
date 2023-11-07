using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblUserRepository
    {
        List<UserModel> Getallusers();
        UserModel getuserbyid(int user_id);

        void AddUser(Tbluser user);
        void Update(Tbluser user);
        void DeleteUser(int user_id);
    }
}
