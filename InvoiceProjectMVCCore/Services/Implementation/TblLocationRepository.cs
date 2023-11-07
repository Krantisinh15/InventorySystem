using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblLocationRepository : ITblLocationRepository
    {
        InvoiceProjectContext db;
        public TblLocationRepository(InvoiceProjectContext db) 
        {
        this.db = db;
        }
        public void Addlocation(Tbllocation location)
        {
           db.Tbllocations.Add(location);
            db.SaveChanges();
        }

        public void Deletelocation(int location_id)
        {
           Tbllocation l=db.Tbllocations.Find(location_id);
            db.Tbllocations.Remove(l);
            db.SaveChanges();
        }

        public List<LocationModel> getalllocationss()
        {
            List<LocationModel>lst= new List<LocationModel>();

            foreach (Tbllocation l in db.Tbllocations.ToList())
            {
                Tblcity c = db.Tblcities.Find(l.CityId);
                LocationModel locations= new LocationModel()
                {
                    Location_id = l.LocationId,
                    Location_name=l.Location,
                    City_id=c.CityId,
                    City_name=c.CityName,
                    
                };
                lst.Add(locations);
            }
            return lst;
        }

        public LocationModel getlocationbyid(int location_id)
        {
            LocationModel location = getalllocationss().FirstOrDefault(e => e.Location_id.Equals(location_id));
            return location;
        }

        public void Updatelocation(Tbllocation location)
        {
            db.Tbllocations.Update(location);
            db.SaveChanges();
        }
    }
}
