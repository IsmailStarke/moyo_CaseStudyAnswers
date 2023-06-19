using moyo_ismailstarke_backend.ViewModels;

namespace moyo_ismailstarke_backend.Models
{
    public interface IRepository
    {
        //Create
        void Add<T>(T entity) where T : class;

        //Delete
        void Delete<T>(T entity) where T : class;

        //Save changes in the database
        bool SaveChanges();

        //====================================== CATEGORY =======================================
        Category[] GetAllCategories();
        Category GetCategory(int categoryId);

        //====================================== PRODUCT ========================================
        Product[] GetAllProducts();
        Product GetProduct(int productId);
        

        //==================================== ORDER STATUS =====================================
        OrderStatus[] GetAllOrderStatuses();

        //======================================= ORDER =========================================
        OrderResponseDTO[] GetAllOrders();
        Order GetOrder(int orderId);

        //==================================== ORDER ITEMS =====================================
    }
}
