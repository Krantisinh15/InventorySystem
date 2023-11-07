using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface IinvoiceProductRepository
    {
        List<InvoiceProductModel> GetAllInvoiceProduct();
        List<customerpurchasehistory> GetAllInvoiceProductbycustomerid(int id);

        InvoiceProductModel GetInvoiceProductbyid(int Invoiceproduct_id);
        void AddInvoiceProduct(TblinvoiceProduct product);
        void DeleteInvoiceProduct(int Invoiceproduct_Id);
        void UpdateInvoiceProduct(TblinvoiceProduct product);
    }
}
