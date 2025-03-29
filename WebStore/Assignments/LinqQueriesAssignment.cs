using Microsoft.EntityFrameworkCore;
using WebStore.Entities;

namespace WebStore.Assignments
{
    public class LinqQueriesAssignment
    {

        private readonly WebStoreContext _dbContext;

        public LinqQueriesAssignment(WebStoreContext context)
        {
            _dbContext = context;
        }


        /// <summary>
        /// 1. List all customers in the database:
        ///    - Print each customer's full name (First + Last) and Email.
        /// </summary>
        public async Task Task01_ListAllCustomers()
        {
            var customers = await _dbContext.Customers
                .AsNoTracking()
                .ToListAsync();

            Console.WriteLine("=== TASK 01: List All Customers ===");

            foreach (var c in customers)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName} - {c.Email}");
            }
        }

        /// <summary>
        /// 2. Fetch all orders along with:
        ///    - Customer Name
        ///    - Order ID
        ///    - Order Status
        ///    - Number of items in each order (the sum of OrderItems.Quantity)
        /// </summary>
        public async Task Task02_ListOrdersWithItemCount()
        {
            var orders = await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Select(o => new
                {
                    CustomerName = $"{o.Customer.FirstName} {o.Customer.LastName}",
                    o.OrderId,
                    o.OrderStatus,
                    ItemCount = o.OrderItems.Sum(oi => oi.Quantity)
                })
            .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== TASK 02: List Orders With Item Count ===");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order #{order.OrderId} - {order.CustomerName} - Status: {order.OrderStatus} - Items: {order.ItemCount}");
            }
        }

        /// <summary>
        /// 3. List all products (ProductName, Price),
        ///    sorted by price descending (highest first).
        /// </summary>
        public async Task Task03_ListProductsByDescendingPrice()
        {
            var products = await _dbContext.Products
                .AsNoTracking()
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== Task 03: List Products By Descending Price ===");

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductName} - ${product.Price:F2}");
            }
        }

        /// <summary>
        /// 4. Find all "Pending" orders (order status = "Pending")
        ///    and display:
        ///      - Customer Name
        ///      - Order ID
        ///      - Order Date
        ///      - Total price (sum of unit_price * quantity - discount) for each order
        /// </summary>
        public async Task Task04_ListPendingOrdersWithTotalPrice()
        {
            var pendingOrders = await _dbContext.Orders
                .Where(o => o.OrderStatus == "Pending")
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Select(o => new
                {
                    CustomerName = $"{o.Customer.FirstName} {o.Customer.LastName}",
                    o.OrderId,
                    o.OrderDate,
                    TotalPrice = o.OrderItems.Sum(oi => (oi.UnitPrice * oi.Quantity) - oi.Discount)
                })
                .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== Task 04: List Pending Orders With Total Price ===");

            foreach (var order in pendingOrders)
            {
                Console.WriteLine($"Order #{order.OrderId} - {order.CustomerName} - Date: {order.OrderDate:d} - Total: ${order.TotalPrice:F2}");
            }
        }

        /// <summary>
        /// 5. List the total number of orders each customer has placed.
        ///    Output should show:
        ///      - Customer Full Name
        ///      - Number of Orders
        /// </summary>
        public async Task Task05_OrderCountPerCustomer()
        {
            var customerOrders = await _dbContext.Customers
                .AsNoTracking()
                .Select(c => new
                {
                    FullName = $"{c.FirstName} {c.LastName}",
                    OrderCount = c.Orders.Count
                })
                .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== Task 05: Order Count Per Customer ===");

            foreach (var customer in customerOrders)
            {
                Console.WriteLine($"{customer.FullName} - Orders: {customer.OrderCount}");
            }
        }

        /// <summary>
        /// 6. Show the top 3 customers who have placed the highest total order value overall.
        ///    - For each customer, calculate SUM of (OrderItems * Price).
        ///      Then pick the top 3.
        /// </summary>
        public async Task Task06_Top3CustomersByOrderValue()
        {
            var topCustomers = await _dbContext.Customers
                .AsNoTracking()
                .Select(c => new
                {
                    FullName = $"{c.FirstName} {c.LastName}",
                    TotalOrderValue = c.Orders.SelectMany(o => o.OrderItems)
                        .Sum(oi => (oi.UnitPrice * oi.Quantity) - oi.Discount)
                })
                .OrderByDescending(c => c.TotalOrderValue)
                .Take(3)
                .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== Task 06: Top 3 Customers By Order Value ===");

            foreach (var customer in topCustomers)
            {
                Console.WriteLine($"{customer.FullName} - Total Order Value: ${customer.TotalOrderValue:F2}");
            }
        }

        /// <summary>
        /// 7. Show all orders placed in the last 30 days (relative to now).
        ///    - Display order ID, date, and customer name.
        /// </summary>
        public async Task Task07_RecentOrders()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var recentOrders = await _dbContext.Orders
                .Where(o => o.OrderDate >= thirtyDaysAgo)
                .Include(o => o.Customer)
                .AsNoTracking()
                .Select(o => new
                {
                    o.OrderId,
                    o.OrderDate,
                    CustomerName = $"{o.Customer.FirstName} {o.Customer.LastName}"
                })
                .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== Task 07: Recent Orders ===");

            foreach (var order in recentOrders)
            {
                Console.WriteLine($"Order #{order.OrderId} - Date: {order.OrderDate:d} - Customer: {order.CustomerName}");
            }
        }

        /// <summary>
        /// 8. For each product, display how many total items have been sold
        ///    across all orders.
        ///    - Product name, total sold quantity.
        ///    - Sort by total sold descending.
        /// </summary>
        public async Task Task08_TotalSoldPerProduct()
        {
            var productSales = await _dbContext.Products
                .AsNoTracking()
                .Select(p => new
                {
                    p.ProductName,
                    TotalSold = p.OrderItems.Sum(oi => oi.Quantity)
                })
                .OrderByDescending(p => p.TotalSold)
                .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== Task 08: Total Sold Per Product ===");

            foreach (var product in productSales)
            {
                Console.WriteLine($"{product.ProductName} - Total Sold: {product.TotalSold}");
            }
        }

        /// <summary>
        /// 9. List any orders that have at least one OrderItem with a Discount > 0.
        ///    - Show Order ID, Customer name, and which products were discounted.
        /// </summary>
        public async Task Task09_DiscountedOrders()
        {
            var discountedOrders = await _dbContext.Orders
                .Where(o => o.OrderItems.Any(oi => oi.Discount > 0))
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .AsNoTracking()
                .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== Task 09: Discounted Orders ===");

            foreach (var order in discountedOrders)
            {
                Console.WriteLine($"Order #{order.OrderId} - Customer: {order.Customer.FirstName} {order.Customer.LastName}");
                Console.WriteLine("  Discounted Products:");

                foreach (var item in order.OrderItems.Where(oi => oi.Discount > 0))
                {
                    Console.WriteLine($"  - {item.Product.ProductName} (Discount: ${item.Discount:F2})");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 10. (Open-ended) Combine multiple joins or navigation properties
        ///     to retrieve a more complex set of data. For example:
        ///     - All orders that contain products in a certain category
        ///       (e.g., "Electronics"), including the store where each product
        ///       is stocked most. (Requires `Stocks`, `Store`, `ProductCategory`, etc.)
        ///     - Or any custom scenario that spans multiple tables.
        /// </summary>
        public async Task Task10_AdvancedQueryExample()
        {
            // Find orders containing products in the "Electronics" category, and find which store 
            // has the most stock for each of those products

            var electronicsCategory = await _dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoryName == "Electronics");

            if (electronicsCategory == null)
            {
                Console.WriteLine(" ");
                Console.WriteLine("=== Task 10: Advanced Query Example ===");
                Console.WriteLine("No 'Electronics' category found in the database.");
                return;
            }

            var electronicsProducts = await _dbContext.Products
                .AsNoTracking()
                .Where(p => p.Categories.Any(c => c.CategoryId == electronicsCategory.CategoryId))
                .ToListAsync();

            var productIds = electronicsProducts.Select(p => p.ProductId).ToList();

            var ordersWithElectronics = await _dbContext.Orders
                .AsNoTracking()
                .Where(o => o.OrderItems.Any(oi => productIds.Contains(oi.ProductId)))
                .Include(o => o.Customer)
                .Include(o => o.OrderItems.Where(oi => productIds.Contains(oi.ProductId)))
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();

            // For each electronics product, find the store with highest stock
            var productStoreMaxStock = await _dbContext.Products
                .Where(p => productIds.Contains(p.ProductId))
                .Select(p => new
                {
                    Product = p,
                    StoreWithMaxStock = p.Stocks
                        .OrderByDescending(s => s.QuantityInStock) // Changed from s.Quantity to s.QuantityInStock
                        .Select(s => new { s.Store, Quantity = s.QuantityInStock }) // Changed to use s.QuantityInStock
                        .FirstOrDefault()
                })
                .ToListAsync();

            Console.WriteLine(" ");
            Console.WriteLine("=== Task 10: Advanced Query Example ===");
            Console.WriteLine("Orders containing Electronics products:");

            foreach (var order in ordersWithElectronics)
            {
                Console.WriteLine($"Order #{order.OrderId} - Customer: {order.Customer.FirstName} {order.Customer.LastName}");
                Console.WriteLine("  Electronics Products:");

                foreach (var item in order.OrderItems)
                {
                    var stockInfo = productStoreMaxStock.FirstOrDefault(p => p.Product.ProductId == item.ProductId);

                    if (stockInfo?.StoreWithMaxStock != null)
                    {
                        Console.WriteLine($"  - {item.Product.ProductName} (Quantity: {item.Quantity})");
                        Console.WriteLine($"    Best stocked at: {stockInfo.StoreWithMaxStock.Store.StoreName} " +
                            $"with {stockInfo.StoreWithMaxStock.Quantity} units");
                    }
                    else
                    {
                        Console.WriteLine($"  - {item.Product.ProductName} (Quantity: {item.Quantity})");
                        Console.WriteLine($"    No stock information available");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
