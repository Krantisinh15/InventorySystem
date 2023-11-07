using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblCustomerInvoiceRepository
    {
        List<CustomerInvoiceModel> GetAllCustomerInvoice();
        List<CustomerInvoiceModel> GetCustomerInvoicebycustid(int customerid);
        CustomerInvoiceModel GetCustomerInvoice(int CustomerInvoice_id);
        void AddCustomerInvoice(TblcustomerInvoice customerInvoice);
       // void UpdateCustomerInvoice(TblcustomerInvoice customerInvoice);
        void DeleteCustomerInvoice(int CustomerInvoice_id);
    }
}
