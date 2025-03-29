

namespace WebStore.Controllers
{
    /* Example implementation of API controller containing endpoints that could be accessed by client

    
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController
    {
        private readonly MyECommerceContext _context;

        public OrdersController(MyECommerceContext context)
        {
            _context = context;
        }

        // GET api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            // Example: include items and related products
            var orders = await _context.Orders
                                       .Include(o => o.OrderItems)
                                       .ThenInclude(oi => oi.Product)
                                       .ToListAsync();
            return Ok(orders);
        }

        // GET api/orders/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> GetOrderById([FromRoute] int id)
        {
            // Example: include items and related products
            var order = await _context.Orders
                                      .Include(o => o.OrderItems)
                                      .ThenInclude(oi => oi.Product)
                                      .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound(); // 404

            return Ok(order);
        }

        // POST api/orders
        // Example minimal body: { "customerId": 1, "orderStatus": "Pending" }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order newOrder)
        {
            if (newOrder == null)
                return BadRequest("Order data is null.");

            // Alternatively, you can validate required fields, e.g. newOrder.CustomerId, etc.

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            // Return 201 Created with the new resource's location
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.OrderId }, newOrder);
        }

        // PUT api/orders/{id}
        // Example minimal body: { "orderStatus": "Shipped" }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] Order updatedOrder)
        {
            if (id != updatedOrder.OrderId)
                return BadRequest("Order ID mismatch in request URL and body.");

            // Check if order exists
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
                return NotFound();

            // Update the properties you want to allow changes to
            existingOrder.OrderStatus = updatedOrder.OrderStatus;
            existingOrder.OrderDate = updatedOrder.OrderDate;
            // etc. for other updatable fields

            // Save
            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();

            return NoContent(); // 204
        }

        // DELETE api/orders/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent(); // 204
        }
    }
    */
}
