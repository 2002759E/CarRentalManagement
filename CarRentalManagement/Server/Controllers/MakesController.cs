using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;

        
        public MakesController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
      
        public async Task<IActionResult> GetMakes()
        {
            
            var makes = await _unitOfWork.Makes.GetAll();
            return Ok(makes);
        }

        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetMake(int id)
        {
           
            var make = await _unitOfWork.Makes.Get(q => q.Id == id);

            if (make == null)
            {
                return NotFound();
            }

            return Ok(make);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.Id)
            {
                return BadRequest();
            }

           
            _unitOfWork.Makes.Update(make);

            try
            {
                
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
               
                if (!await MakeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
           
            await _unitOfWork.Makes.Insert(make);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            
            var make = await _unitOfWork.Makes.Get(q =>q.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            
            await _unitOfWork.Makes.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

       
        private async Task<bool> MakeExists(int id)
        {
            
            var make = await _unitOfWork.Makes.Get(q => q.Id == id);
            return make != null;
        }
    }
}
