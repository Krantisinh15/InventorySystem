using InvoiceProjectMVCCore.Models;

namespace InvoiceProjectMVCCore.Services.Interfaces
{
    public interface ITblCustomerRepository
    {
        List<CustomerModel> GetAllCustomer();
        CustomerModel GetCustomerById(int id);
        void AddCustomer(Tblcustomer customer);
        void UpdateCustomer(Tblcustomer customer);
        void DeleteCustomer(int customer_id);

    }
}
