using APITest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ShopContext _shopContext;
		public ProductsController(ShopContext context)
		{
			_shopContext = context;
			_shopContext.Database.EnsureCreated();
		}
		[HttpGet]
		//public ActionResult<IEnumerable<Product>> GetAllProducts()
		//{
		//	return _shopContext.Products.ToArray();
		//}
		public async Task<ActionResult> GetAllProducts()
		{
			//Listen af produkter bliver hermed et argument i metoden, Ok. 
			//Hvis alt forløber, som det skal, returneres en Status Code 200 
			return Ok(await _shopContext.Products.ToArrayAsync());
		}
		//Her bliver der sat en routing. Vi har allerede en base route på class level 
		[HttpGet("{id}")]
		public async Task<ActionResult> GetProduct(int id)
		{
			var product = await _shopContext.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpPost]
		public async Task<ActionResult<Product>> PostProduct(Product product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			_shopContext.Products.Add(product);
			await _shopContext.SaveChangesAsync();

			return CreatedAtAction(
				"GetProduct",
				new {id = product.Id},
				product);
		}

		[HttpPut]
		public async Task<ActionResult> PutProduct(int id, Product product)
		{
			if (id != product.Id)
			{
				return BadRequest(); 
			}

			_shopContext.Entry(product).State = EntityState.Modified;
			try
			{
				await _shopContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if(!_shopContext.Products.Any(p => p.Id == id)) 
				{
					return NotFound(); 
				}
				else
				{
					throw; 
				}
			}
			return Ok(product);
		}

		[HttpDelete("{id")]
		public async Task<ActionResult<Product>> DeleteProduct(int id)
		{
			var product = await _shopContext.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound(); 
			}
			_shopContext.Products.Remove(product);
			await _shopContext.SaveChangesAsync();
			return product;
		}
	}
}
