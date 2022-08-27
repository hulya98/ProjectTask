using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTask.DAL;
using ProjectTask.DAL.UnitOfWork.Abstract;
using ProjectTask.DAL.UnitOfWork.Concrete;
using ProjectTask.Domains.Dtos;
using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        IMapper _mapper;
        public ProductCategoryController(IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(new ProductContext());
            _mapper = mapper;

        }

        [HttpGet("GetProductCategories")]
        public IActionResult GetProductCategories()
        {
            List<ProductCategory> products = _unitOfWork.ProductCategoryRepository.GetAll();
            List<ProductCategoryDto> productCategoryDtos = _mapper.Map<List<ProductCategoryDto>>(products);
            return Ok(productCategoryDtos);
        }

        [HttpGet("{productCategoryId}")]
        public IActionResult GetProductCategory(int productCategoryId)
        {
            ProductCategory productCategory = _unitOfWork.ProductCategoryRepository.Get(productCategoryId);

            if (productCategory == null)
                return NotFound();

            ProductCategoryDto result = _mapper.Map<ProductCategoryDto>(productCategory);

            return Ok(result);
        }

        [HttpPost("AddProductCategory")]
        public IActionResult AddProductCategory(ProductCategoryDto productCategoryDto)
        {
            if (ModelState.IsValid)
            {
                ProductCategory productCategory = _mapper.Map<ProductCategory>(productCategoryDto);
                _unitOfWork.ProductCategoryRepository.Add(productCategory);
                int res = _unitOfWork.Complete();
                if (res == 0)
                    return BadRequest();
                return StatusCode(StatusCodes.Status201Created);
            }
            else
                return BadRequest(ModelState.ToList());
        }

        [HttpPut("UpdateProductCategory")]
        public IActionResult UpdateProductCategory(ProductCategoryDto productCategoryDto)
        {
            if (ModelState.IsValid)
            {
                ProductCategory productCategory = _mapper.Map<ProductCategory>(productCategoryDto);
                _unitOfWork.ProductCategoryRepository.Update(productCategory);

                int result = _unitOfWork.Complete();

                if (result == 0)
                    return BadRequest();

                return Ok();
            }
            else
            {
                return BadRequest(ModelState.ToList());
            }
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {

            ProductCategory productCategory = _unitOfWork.ProductCategoryRepository.Get(id);

            if (productCategory == null)
                return NotFound();

            _unitOfWork.ProductCategoryRepository.DeleteProductCategory(id);
            int res = _unitOfWork.Complete();
            if (res == 0)
                return BadRequest();
            return Ok();
        }
    }
}
