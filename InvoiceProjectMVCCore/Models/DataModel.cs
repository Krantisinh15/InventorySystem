namespace InvoiceProjectMVCCore.Models
{
    public class DataModel
    {
    }
    public class CategoryModel
    {
        public int Category_id { get; set; }
        public string Category { get; set; }
        public int user_id { get; set; }
        public string User_name { get; set; }
    }

    public class SubCategoryModel
    {
        public int Subcategory_id { get; set; }
        public string Subcategory_name { get; set; }

        public int Category_id { get; set; }
        public string category_name { get; set; }
        public int user_id { get; set; }
        public string User_name { get; set; }
    }

    public class StateModel
    {
        public int state_id { get; set; }
        public string state_name { get; set; }
    }

    public class CityModel
    {
        public int City_id { get; set; }
        public string City_name { get; set; }
        public int State_id { get; set; }
        public string State_name { get; set; }
    }

    public class LocationModel
    {
        public int Location_id { get; set; }
        public string Location_name { get; set; }
        public int City_id { get; set; }
        public string City_name { get; set; }
    }
    public class UnitModel
    {
        public int Unit_id { get; set; }
        public string Unit_name { get; set; }
    }

    public class UserModel
    {

        public int User_id { get; set; }
        public string User_name { get; set; }
        public string MobileNumber { get; set; }
        public string Email_Address { get; set; }
        public string Unique_code { get; set; }
        public string password { get; set; }
        public string User_photo { get; set; }
        public int flag { get; set; }
        public int location_id { get; set; }
        public string location_name { get; set; }

    }

    public class VenderModel
    {
        public int Vender_id { get; set; }
        public string Vender_name { get; set; }
        public string Mobile_no { get; set; }
        public string Email_address { get; set; }
        public int User_id { get; set; }
        public string User_name { get; set; }
        public int flag { get; set; }
    }
    public class CustomerModel
    {
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Mobile_No { get; set; }
        public string Email_address { get; set; }
        public int User_id { get; set; }
        public string User_name { get; set; }
        public int location_id { get; set; }
        public string location_name { get; set; }
        public int flag { get; set; }
    }

    public class ProductModel
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int Unit_id { get; set; }
        public string Unit_name { get; set; }
        public int Subcategory_id { get; set; }
        public string Subcategory_name { get; set; }
        public int category_id { get; set; }
        public string category_name { get; set; }
        public float Selling_rate { get; set; }
        public double Tax { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }

    }
    public class OrderStockModel
    {
        public int OrderStock_id { get; set; }
        public string Order_date { get; set; }
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_Mobile_number { get; set; }
        public string User_mail { get; set; }
        public int Vender_id { get; set; }
        public string Vender_name { get; set; }
        public string Vender_Mobile_number { get; set; }
        public string Vender_mail { get; set; }
    }

    public class OrderStock_ProductsModel
    {
        public int OrderStockProduct_id { get; set; }
        public int Order_stock_id { get; set; }
        public string Order_date { get; set; }
        public int order_product_Quantity { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int SubCategory_id { get; set; }
        public string SubCategory_name { get; set; }
        public int Category_id { get; set; }
        public string Category_name { get; set; }
        public int Unit_id { get; set; }
        public string Unit_name { get; set; }
        public int totalorderquantites { get; set; }

    }

    public class RecivedStockModel
    {
        public int RecivedStock_id { get; set; }
        public int Vendor_id { get; set; }
        public string Vendor_name { get; set; }
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string Recived_date { get; set; }

    }
    public class RecivedStock_ProductModel
    {
        public int RecivedStockProduct_id { get; set; }
        public int RecivedStock_id { get; set; }
        public int Vendor_id { get; set; }
        public string Vendor_name { get; set; }
        public int Product_id { get; set; }
        public float RecivedProduct_quantity { get; set; }
        public float RecivedProduct_Rate { get; set; }
        public string product_name { get; set; }
        public float Selling_rate { get; set; }
        public double Tax { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set;}

    }

    public class CustomerInvoiceModel
    {
        public int Invoice_id { get; set; }
        public string Invoice_date { get; set; }
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string customer_mobile_no { get; set; }
        public string customer_mail { get; set; }
        public int User_id { get; set; }
        public string User_name { get; set; }
        public float Total_Amount { get; set; }
        public float Remaining_Amount { get; set; }
        public float Paid { get; set; }
        public string status{get;set; }

        public InvoiceProductModel invoicepr { get; set; }
      
    }

    public class InvoiceProductModel
    {
        public int Invoice_Product_id { get; set; }
        public int Invoice_id { get; set; }
        public string Invoice_date { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int Unit_id { get; set; }
        public string Unit_name { get; set; }
        public float Purchase_Quantity { get; set; }
        public int flag { get; set; }
        public float Total_amount { get; set; }
    }

    public class InvoicePaymentModel
    {
        public int Payment_id { get; set; }
        public string Payment_date { get; set; }
        public int Invoice_id { get; set; }
        public string Invoice_Date { get; set; }
        public float Total_Amount { get; set; }
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_email { get; set; }
        public float Payment_Amount { get; set; }
        public string Payment_mode { get; set; }
        public string Payment_description { get; set; }

    }
    public class Invoice
    {
        public int Invoice_id { get; set; }
        public string Invoice_date { get; set; }
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string customer_mobile_no { get; set; }
        public string customer_mail { get; set; }
        public int User_id { get; set; }
        public string User_name { get; set; }
        public float Total_Amount { get; set; }
        public float Remaining_amount { get; set; }
        public float Pay_amount { get; set; }
        public float Paid_Amount { get; set; }
        public string status { get; set; }

    }

    public class customerpurchasehistory
    {
       public List <Invoice>InvoiceModel { get; set; }
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string customer_mobile_no { get; set; }
        public string customer_mail { get; set; }
        public float Total_Amount { get; set; }
        public int Invoice_Product_id { get; set; }
        public List<InvoiceProductModel>InvoiceProductModel { get; set; }

    }



}
