using InvoiceProjectMVCCore.Models;
using InvoiceProjectMVCCore.Services.Interfaces;

namespace Invoice_Project_MVCCore.Services.Implementation
{
    public class InvoicePaymentRepository : IinvoicePaymentRepository
    {
        InvoiceProjectContext db;
        public InvoicePaymentRepository(InvoiceProjectContext db)
        {
            this.db = db;
        }
        public void AddPayment(InvoicePayment payment)
        {
            db.InvoicePayments.Add(payment);
            db.SaveChanges();
        }

        public void DeletePayment(int payment_id)
        {
            InvoicePayment payment = db.InvoicePayments.Find(payment_id);
            db.InvoicePayments.Remove(payment);
            db.SaveChanges();
        }

        public List<InvoicePaymentModel> GetPaymentDetails()
        {
            List<InvoicePaymentModel> lst=new List<InvoicePaymentModel>();
            foreach(InvoicePayment i in db.InvoicePayments.ToList())
            {
                TblcustomerInvoice ci = db.TblcustomerInvoices.Find(i.InvoiceId);
                Tbluser u = db.Tblusers.Find(ci.UserId);


                InvoicePaymentModel im = new InvoicePaymentModel()
                {
                    Payment_id = i.PaymentId,
                    Payment_date = i.PaymentDate,
                    Invoice_id = ci.InvoiceId,
                    Invoice_Date = ci.InvoiceDate,
                    Total_Amount=(float)ci.TotalAmount,
                    Payment_Amount = (float)i.PaymentAmount,
                    Payment_description=i.PaymentDescription,
                    Payment_mode=i.PaymentMode,
                    User_id=u.UserId,
                    User_name=u.UserName,
                    User_email=u.EmailAddress,



                };
                lst.Add(im);
            }
            return lst;
        }
        public List<InvoicePaymentModel> GetAllPaymentDetails()
        {
            return GetPaymentDetails();
        }

        public InvoicePaymentModel Getpaymentdetailbyid(int payment_id)
        {
           InvoicePaymentModel invoice=GetPaymentDetails().FirstOrDefault(e=>e.Payment_id.Equals(payment_id));
            return invoice;
        }

        public void UpdatePayment(InvoicePayment payment)
        {
           db.InvoicePayments.Update(payment);
            db.SaveChanges();
        }
    }
}
