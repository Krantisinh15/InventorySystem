using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class TblCustomerRepository : ITblCustomerRepository
    {
        InvoiceProjectContext db;
        public TblCustomerRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddCustomer(Tblcustomer customer)
        {
           db.Tblcustomers.Add(customer);
            db.SaveChanges();
        }

        public void DeleteCustomer(int customer_id)
        {
            Tblcustomer model = db.Tblcustomers.Find(customer_id);
            db.Tblcustomers.Remove(model);
            db.SaveChanges();
        }

        public List<CustomerModel> GetAllCustomer()
        {
           List<CustomerModel>lst=new List<CustomerModel>();
            foreach(Tblcustomer c in db.Tblcustomers.ToList())
            {
               
                Tbllocation l = db.Tbllocations.Find(c.LocationId);
                CustomerModel model = new CustomerModel()
                {
                    Customer_id = c.CustomerId,
                    Customer_name = c.CustomerName,
                    Email_address = c.EmailAddress,
                    Mobile_No = c.MobileNo,
                    location_id =(int) c.LocationId,
                    location_name = l.Location,
                    User_id = (int)c.UserId,
                    flag=(int)c.Flag    
                };
                lst.Add(model);
            }
            return lst;
        }

        public CustomerModel GetCustomerById(int id)
        {
            CustomerModel model = GetAllCustomer().FirstOrDefault(e => e.Customer_id.Equals(id));
            return model;
        }

        public void UpdateCustomer(Tblcustomer customer)
        {
           db.Tblcustomers.Update(customer);
            db.SaveChanges();
           
        }
    }
}
