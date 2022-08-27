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
    public class ProductController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(new ProductContext());
            _mapper = mapper;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            List<Product> products = _unitOfWork.ProductRepository.GetProducts();
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{productId}")]
        public IActionResult GetProduct(int id)
        {
            Product product = _unitOfWork.ProductRepository.Get(id);

            if (product == null)
                return NotFound();

            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                productDto.IsDeleted = false;
                Product product = _mapper.Map<Product>(productDto);
                _unitOfWork.ProductRepository.Add(product);
                int res = _unitOfWork.Complete();

                if (res == 0)
                    return BadRequest();
                else
                    return StatusCode(StatusCodes.Status201Created);
            }
            else
                return StatusCode(400, ModelState.ToList());
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                Product product = _mapper.Map<Product>(productDto);
                product.IsDeleted = false;
                _unitOfWork.ProductRepository.Update(product);

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

        [HttpDelete("{DeleteProduct}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _unitOfWork.ProductRepository.Get(id);
            if (product == null)
                return NotFound();

            product.IsDeleted = true;

            _unitOfWork.ProductRepository.Update(product);

            int res = _unitOfWork.Complete();

            if (res == 0)
                return BadRequest();
            else
                return Ok();
        }
    }
}
