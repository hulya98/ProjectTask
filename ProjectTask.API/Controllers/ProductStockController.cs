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

        [HttpGet("GetProductStocks")]
        public IActionResult GetProductStocks()
        {
            List<ProductStock> productStock = _unitOfWorkProdStock.ProductStockRepository.GetAll();

            if (productStock == null)
                return NotFound();

            List<ProductStockDto> productStockDto = _mapper.Map<List<ProductStockDto>>(productStock);

            return Ok(productStockDto);

        }

        [HttpGet("GetProductStock")]
        public IActionResult GetProductStock(int productId)
        {
            ProductStock productStock = _unitOfWorkProdStock.ProductStockRepository.GetProductStockByProductId(productId);

            if (productStock == null)
                return NotFound();

            ProductStockDto productStockDto = _mapper.Map<ProductStockDto>(productStock);

            return Ok(productStockDto);

        }

        [HttpPost("AddProductStock")]
        public IActionResult AddProductStock(ProductStockDto productStockDto)
        {
            if (ModelState.IsValid)
            {
                var getRowFromProductStock = _unitOfWorkProdStock.ProductStockRepository.GetProductStockByProductId(productStockDto.ProductId); //this check dublicate data for ProductId where IsDeleted = false

                var getRowFromProduct = _unitOfWorkProd.ProductRepository.Get(productStockDto.ProductId); //this check Product is exists or not in Product List

                if (getRowFromProductStock != null)
                    return BadRequest("This Product already exist");

                if (getRowFromProduct == null)
                    return BadRequest("This Product is not exist in Product List");

                ProductStock productStock = _mapper.Map<ProductStock>(productStockDto);
                _unitOfWorkProdStock.ProductStockRepository.Add(productStock);
                int res = _unitOfWorkProdStock.CompleteProductStock();

                if (res == 0)
                    return BadRequest();
                else
                    return StatusCode(StatusCodes.Status201Created);
            }
            else
                return BadRequest(ModelState.ToList());
        }

        [HttpPut("AddStock")]
        public IActionResult AddStock(AddProductStock addProductStock)
        {
            if (ModelState.IsValid)
            {
                var getRowFromProduct = _unitOfWorkProd.ProductRepository.Get(addProductStock.ProductId); //this check Product is exists or not in Priduct List

                if (getRowFromProduct == null)
                    return BadRequest("This product is not exist Product Stock list. Please, before add this product to Product Stock list");


                ProductStock productStock = _unitOfWorkProdStock.ProductStockRepository.GetProductStockByProductId(addProductStock.ProductId);

                productStock.Count += addProductStock.NewAddedProductCount;

                _unitOfWorkProdStock.ProductStockRepository.Update(productStock);

                int res = _unitOfWorkProdStock.CompleteProductStock();

                if (res == 0)
                    return BadRequest();

                return Ok();
            }
            else
                return BadRequest(ModelState.ToList());

        }

        [HttpPut("RemoveStock")]
        public IActionResult RemoveStock(RemoveProductStock removeProductStock)
        {
            if (ModelState.IsValid)
            {
                var getRowFromProduct = _unitOfWorkProd.ProductRepository.Get(removeProductStock.ProductId); //this check Product is exists or not in Priduct List

                if (getRowFromProduct == null)
                    return BadRequest("This product is not exist Product Stock list. Please, before add this product to Product Stock list");


                ProductStock productStock = _unitOfWorkProdStock.ProductStockRepository.GetProductStockByProductId(removeProductStock.ProductId);

                if (removeProductStock.NewSoldProductCount > productStock.Count)
                    return BadRequest("Out Of Stock exception");

                productStock.Count -= removeProductStock.NewSoldProductCount;

                _unitOfWorkProdStock.ProductStockRepository.Update(productStock);

                int res = _unitOfWorkProdStock.CompleteProductStock();

                if (res == 0)
                    return BadRequest();

                return Ok();
            }
            else
                return BadRequest(ModelState.ToList());

        }

        [HttpDelete("DeleteProductStock")]
        public IActionResult DeleteProductStock(int id)
        {
            ProductStock productStock = _unitOfWorkProdStock.ProductStockRepository.GetProductStockByProductId(id);
            if (productStock == null)
                return NotFound();

            _unitOfWorkProdStock.ProductStockRepository.DeleteProductStockForProductId(id);

            int res = _unitOfWorkProdStock.CompleteProductStock();

            if (res == 0)
                return BadRequest();
            else
                return Ok();
        }

    }
}
