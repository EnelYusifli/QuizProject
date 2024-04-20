using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.DTOs;
using Quiz.Business.Helpers.Exceptions;
using Quiz.Business.Services.Interfaces;
using Quiz.Core.Entities;

namespace Quiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _service;

        public BlogController(IBlogService service)
        {
            _service = service;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
              var dtos= await _service.GetAll(null);
                return Ok(dtos);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBtId(int id)
        {
            try
            {
                var dto=await _service.GetById(id);
                return Ok(dto);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(BlogPostDto dto)
        {
            try
            {
                await _service.Create(dto);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update(BlogPutDto dto,int id)
        {
            try
            {
                await _service.Update(dto,id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(BlogDeleteDto dto, int id)
        {
            try
            {
                await _service.Delete(dto, id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("[action]/{id}")]
        public async Task<IActionResult> SoftDelete(BlogSoftDeleteDto dto, int id)
        {
            try
            {
                await _service.SoftDelete(dto, id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
