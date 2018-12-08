using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Conferences.API.Model;
using Conferences.DataAccess.Common.Framework;
using Conferences.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Conferences.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var results = await _unitOfWork.ProductsRepository.GetAsync();
            return Json(Mapper.Map<IEnumerable<ProductDTO>>(results));
                                          
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var results = await _unitOfWork.ProductsRepository.GetAsync(id);
            return Json(Mapper.Map<ProductDTO>(results));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductModel model)
        {
            var entity = Mapper.Map<Products>(model);
            var result = await _unitOfWork.ProductsRepository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return Json(Mapper.Map<ProductDTO>(result));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] ProductModel model)
        {
            var entity = Mapper.Map<Products>(model);
            entity.ProductID = id;
            _unitOfWork.ProductsRepository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.ProductsRepository.GetAsync(id);
            _unitOfWork.ProductsRepository.Remove(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}
