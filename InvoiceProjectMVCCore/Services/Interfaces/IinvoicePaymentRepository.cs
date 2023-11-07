using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface IinvoicePaymentRepository
    {
        public List<InvoicePaymentModel> GetAllPaymentDetails();
        public InvoicePaymentModel Getpaymentdetailbyid(int payment_id);

        void AddPayment(InvoicePayment payment);
        void UpdatePayment(InvoicePayment payment);
        void DeletePayment(int payment_id);

    }
}
