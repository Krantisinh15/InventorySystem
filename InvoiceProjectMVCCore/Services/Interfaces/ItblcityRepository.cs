using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ItblcityRepository
    {
        List<CityModel> Getallcity();
        CityModel Getcity(int id);
        void Addcity(Tblcity city);
        void Deletecity(int id);
        void Updatecity(Tblcity city);

    }
}
