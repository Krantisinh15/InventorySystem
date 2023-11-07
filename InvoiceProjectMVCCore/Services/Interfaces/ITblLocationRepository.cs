using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblLocationRepository
    {
        List<LocationModel> getalllocationss();
        LocationModel getlocationbyid(int location_id);
        void Addlocation(Tbllocation location);
        void Updatelocation(Tbllocation location);
        void Deletelocation(int location_id);

    }
}
