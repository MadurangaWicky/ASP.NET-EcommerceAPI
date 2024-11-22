using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Data;
using EcommerceApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;





namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext context;

        public ProductController(ProductContext context){
            this.context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<Product>?> SaveProduct(Product product){
            try{
                context.Add(product);
                 await context.SaveChangesAsync();
                return product;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                return null;
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Product>?>> GetProductList(){
            return await context.Products.ToListAsync();
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>?> GetProductById(int id){
            var product = await context.Products.FindAsync(id);
            if(product==null){
                return NotFound();
            }
            return product;
        }
    }
}