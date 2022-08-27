using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTask.DAL;
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
    public class ProductStockController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWorkProdStock;
        private readonly UnitOfWork _unitOfWorkProd;
        IMapper _mapper;

        public ProductStockController(IMapper mapper)
        {
            _unitOfWorkProdStock = new UnitOfWork(new ProductStockContext());
            _unitOfWorkProd = new UnitOfWork(new ProductContext());
            _mapper = mapper;
        }

        [HttpGet("GetProductStock")]
        public IActionResult GetProductStocks()
        {
            List<ProductStock> productStock = _unitOfWorkProdStock.ProductStockRepository.GetAll();

            if (productStock == null)
                return NotFound();

            List<ProductStockDto> productStockDto = _mapper.Map<List<ProductStockDto>>(productStock);

            return Ok(productStockDto);

        }

    
    }
}
