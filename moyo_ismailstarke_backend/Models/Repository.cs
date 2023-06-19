using Microsoft.EntityFrameworkCore;
using moyo_ismailstarke_backend.ViewModels;

namespace moyo_ismailstarke_backend.Models
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        //==================================== CATEGORY ==========================================

        public Category[] GetAllCategories()
        {
            // Retrieving all categories synchronously
            return _context.Category.ToArray();
        }

        public Category GetCategory(int categoryId)
        {
            //Retrieving only one category based on the Category ID
            return _context.Category.FirstOrDefault(c => c.categoryId == categoryId);
        }

        //==================================== PRODUCT ===========================================

        public Product[] GetAllProducts()
        {
            // Retrieving all products synchronously
            return _context.Product.Include(p => p.Category).ToArray();
        }

        public Product GetProduct(int productId)
        {
            //Retrieving only one product based on the Product ID
            return _context.Product.Include(p => p.Category).FirstOrDefault(p => p.productId == productId);
        }

        //===================================== ORDER STATUS ======================================
        public OrderStatus[] GetAllOrderStatuses()
        {
            // Retrieving all statuses synchronously
            return _context.OrderStatus.ToArray();
        }

        //======================================== ORDER ========================================
        public OrderResponseDTO[] GetAllOrders()
        {
            // Retrieving all order synchronously
            return _context.Order
                .Include(o => o.User)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderItem)
                .ThenInclude(oi => oi.Product)
                .Select(o => new OrderResponseDTO
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    UserName = o.UserName,
                    OrderStatus = o.OrderStatus.Status,
                    ProductDescription = o.OrderItem.Product.description,
                    TotalPrice = o.TotalPrice
                })
                .ToArray();
        }

        public Order GetOrder(int orderId)
        {
            //Retrieving only one order based on the Order ID
            return _context.Order.FirstOrDefault(o => o.OrderId == orderId);
        }

        //================================ DO NOT CODE BELOW THIS LINE ===========================

        public void Add<T>(T entity) where T : class
        {
            // Adding an entity
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            // Deleting an entity
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            // Saving changes synchronously
            return _context.SaveChanges() > 0;
        }
    }
}
