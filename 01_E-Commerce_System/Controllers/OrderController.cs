using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _01_E_Commerce_System.Data;
using _01_E_Commerce_System.Models.Entities;
using _01_E_Commerce_System.Models.Models.Order;
using _01_E_Commerce_System.Models.Models.Adress;
using _01_E_Commerce_System.Models.Input;

namespace _01_E_Commerce_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order : ControllerBase
    {
        private readonly SqlContext _context;

        public Order(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGetModel>>> GetOrders()
        {
            var orders = new List<OrderGetModel>();
            foreach (var order in await _context.Orders
                .Include(x => x.Adresses)
                .ToListAsync())

                orders.Add(new OrderGetModel(
                    order.Id,
                    order.OrderNumber,
                    order.Status,
                    order.OrderDate,
                    order.FirstName,
                    order.ProductName,
                    order.Quantity,
                        new AdressModel(
                            order.Adresses.AdressLine,
                            order.Adresses.PostalCode,
                            order.Adresses.City)));
            return orders;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGetModel>> GetOrder(int id)
        {
            var orderEntity = await _context.Orders
                .Include(x => x.Adresses)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(orderEntity == null)
            {
                return NotFound("Order Id doesn't exist! Try again!");
            }

            return new OrderGetModel(
                orderEntity.Id,
                orderEntity.OrderNumber,
                orderEntity.Status,
                orderEntity.OrderDate,
                orderEntity.FirstName,
                orderEntity.ProductName,
                orderEntity.Quantity,
                    new AdressModel(
                        orderEntity.Adresses.AdressLine,
                        orderEntity.Adresses.PostalCode,
                        orderEntity.Adresses.City));
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderPutModel>> UpdateOrder(int id, OrderPutModel model)
        {
            {
                if(id != model.Id)
                {
                    return BadRequest("Order Id doesn't exist! Try again!");
                }

                var orderEntity = await _context.Orders
                    .FindAsync(model.Id);

                orderEntity.OrderNumber = model.OrderNumber;
                orderEntity.Status = model.Status;
                orderEntity.OrderDate = model.OrderDate;
                orderEntity.FirstName = model.FirstName;
                orderEntity.ProductName = model.ProductName;
                orderEntity.Quantity = model.Quantity;
                    new AdressEntity(
                        model.AdressLine,
                        model.PostalCode,
                        model.City);

                _context.Entry(orderEntity).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!OrderEntityExists(id))
                    {
                        return NotFound("Something went wrong! Try again!");
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok("Your Order is updated!");
            }

        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<OrderPostModel>> PostOrder(OrderInput model)
        {
            var orderEntity = new OrderEntity(
                model.OrderNumber,
                model.Status,
                model.OrderDate,
                model.FirstName,
                model.ProductName,
                model.Quantity);

            var users = await _context.Users.Include(x => x.Adresses)
                .FirstOrDefaultAsync(x => x.FirstName == model.FirstName && x.Adresses.AdressLine == model.AdressLine);
            if (users != null)
                orderEntity.FirstName = model.FirstName;
            else
                return BadRequest("First Name and Adress Line doesn't match or they don't exist. Try again or Create a new User with a new Adress!");

            var adresses = await _context.Adresses
                .FirstOrDefaultAsync(x => x.AdressLine == model.AdressLine);
            if (adresses != null)
                orderEntity.AdressesId = adresses.Id;
            else
                return BadRequest();

            var products = await _context.Products
                .FirstOrDefaultAsync(x => x.ProductName == model.ProductName);
            if (products != null)
                orderEntity.ProductName = model.ProductName;
            else
                return BadRequest("The Product Name doesn't exist! Create a new Product!");


            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = orderEntity.Id },
                new OrderPostModel(
                    orderEntity.Id,
                    orderEntity.OrderNumber,
                    orderEntity.Status,
                    orderEntity.OrderDate,
                    orderEntity.FirstName,
                    orderEntity.ProductName,
                    orderEntity.Quantity,
                        new OrderAdressModel(
                            orderEntity.Adresses.AdressLine)));
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity == null)
            {
                return NotFound("Order Id doesn't exist! Try again!");
            }

            _context.Orders.Remove(orderEntity);
            await _context.SaveChangesAsync();

            return Ok("Your Order is deleted!");
        }

        private bool OrderEntityExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
