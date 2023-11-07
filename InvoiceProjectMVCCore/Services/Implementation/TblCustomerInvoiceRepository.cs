using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Invoice_Project_MVCCore.Services.Implementation
{
     
    public class TblCustomerInvoiceRepository : ITblCustomerInvoiceRepository
    {
        InvoiceProjectContext db;
        public TblCustomerInvoiceRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddCustomerInvoice(TblcustomerInvoice customerInvoice)
        {
           db.TblcustomerInvoices.Add(customerInvoice);
            db.SaveChanges();
        }

        public void DeleteCustomerInvoice(int CustomerInvoice_id)
        {
            TblcustomerInvoice tblinvoice = db.TblcustomerInvoices.Find(CustomerInvoice_id);
            db.Remove(tblinvoice);
            db.SaveChanges();
        }

        public List<CustomerInvoiceModel> GetAllCustomerInvoice()
        {
            List<CustomerInvoiceModel> lst = new List<CustomerInvoiceModel>();

            foreach (TblcustomerInvoice c in db.TblcustomerInvoices.ToList())
            {
                Tblcustomer t = db.Tblcustomers.Find(c.CustomerId);

                CustomerInvoiceModel model = new CustomerInvoiceModel()
                {
                    Invoice_id = c.InvoiceId,
                    Invoice_date = c.InvoiceDate,
                    Total_Amount = (float)c.TotalAmount,
                    Customer_id = t.CustomerId,
                    Customer_name = t.CustomerName,
                    customer_mail = t.EmailAddress,
                    customer_mobile_no = t.MobileNo,
                };
                lst.Add(model);
            }
            return lst;
        }

        public CustomerInvoiceModel GetCustomerInvoice(int customer_id)
        {
            CustomerInvoiceModel cust = GetAllCustomerInvoice().FirstOrDefault(e => e.Invoice_id.Equals(customer_id));
            return cust;

        }

        public List<CustomerInvoiceModel> GetCustomerInvoicebycustid(int customerid)
        {
            List<CustomerInvoiceModel> lst = new List<CustomerInvoiceModel>();

            foreach (TblcustomerInvoice c in db.TblcustomerInvoices.ToList())
            {
                Tblcustomer t = db.Tblcustomers.Find(c.CustomerId);
                if(c.CustomerId== customerid)
                {
                    CustomerInvoiceModel model = new CustomerInvoiceModel()
                    {
                        Invoice_id = c.InvoiceId,
                        Invoice_date = c.InvoiceDate,
                        Total_Amount = (float)c.TotalAmount,
                        Customer_id = t.CustomerId,
                        Customer_name = t.CustomerName,
                        customer_mail = t.EmailAddress,
                        customer_mobile_no = t.MobileNo,
                    };
                    lst.Add(model);
                } 
            }
            return lst;
        }

        //public void UpdateCustomerInvoice(TblcustomerInvoice customerInvoice)
        //{
        //    db.TblcustomerInvoices.Update(customerInvoice);
        //    db.SaveChanges();
        //}
    }
}
