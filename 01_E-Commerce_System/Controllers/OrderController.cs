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
                    order.FirstName,
                    order.OrderDate,
                    order.Status,
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

            if (orderEntity == null)
            {
                return NotFound();
            }

            return new OrderGetModel(
                    orderEntity.Id,
                    orderEntity.FirstName,
                    orderEntity.OrderDate,
                    orderEntity.Status,
                        new AdressModel(
                            orderEntity.Adresses.AdressLine,
                            orderEntity.Adresses.PostalCode,
                            orderEntity.Adresses.City));
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderPutModel>> UpdateOrder(int id, OrderPutModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var orderEntity = await _context.Orders
                .FindAsync(model.Id);

            orderEntity.FirstName = model.UsersFirstName;
            orderEntity.Status = model.Status;
            new AdressEntity(
                model.Adress.AdressLine,
                model.Adress.PostalCode,
                model.Adress.City);

            _context.Entry(orderEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return NoContent();

        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<OrderPostModel>> PostOrder(OrderInput model)
        {
            var orderEntity = new OrderEntity(
                model.Status,
                model.UserFirstName,
                model.Created);

            var adresses = await _context.Adresses
                .FirstOrDefaultAsync(x => x.AdressLine == model.AdressLine && x.PostalCode == model.PostalCode);

            if (adresses != null)
                orderEntity.AdressesId = adresses.Id;
            else
                return BadRequest();

            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = orderEntity.Id },
                new OrderPostModel(
                    orderEntity.Id,
                    orderEntity.FirstName,
                    orderEntity.OrderDate,
                    orderEntity.Status,
                    new AdressModel(
                        orderEntity.Adresses.AdressLine,
                        orderEntity.Adresses.PostalCode,
                        orderEntity.Adresses.City)));
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderEntityExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
