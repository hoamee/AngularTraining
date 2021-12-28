using Infrastrure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo)
        {
            this.productTypeRepo = productTypeRepo;
            this.productBrandRepo = productBrandRepo;
            this.productRepo = productRepo;

        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await productRepo.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var product = await productRepo.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return product;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            return Ok(await productTypeRepo.ListAllAsync());
        }
    }
}