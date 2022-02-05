using Dapper.Core.Entities;
using Dapper.Core.Interfaces;
using Dapper.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [ServiceFilter(typeof(MyFilter))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IReadOnlyList<Product> list;

                list =  await _unitOfWork.Products.GetAllAsync();

                return Ok(list);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Products.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var data = await _unitOfWork.Products.AddAsync(product);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Products.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var data = await _unitOfWork.Products.UpdateAsync(product);
            return Ok(data);
        }
    }
}
