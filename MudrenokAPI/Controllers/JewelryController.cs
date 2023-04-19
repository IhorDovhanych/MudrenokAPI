using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MudrenokAPI.Models;
using MudrenokAPI.Services;

namespace MudrenokAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelryController : ControllerBase
    {

        private readonly DataContext _context;
        public JewelryController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Jewelry>>> Get()
        {
            return Ok(await this._context.Jewelry.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Jewelry>>> Get(int id)
        {
            List<Jewelry> List = await this._context.Jewelry.ToListAsync();
            return Ok(List.Find(j => j.Id == id));
        }
        [HttpPost]
        public async Task<ActionResult<List<Jewelry>>> AddJewelry(Jewelry jewelry)
        {
            if (
                JewelryService.ValidateName(jewelry.Name) &&
                JewelryService.ValidateUrl(jewelry.ImageUrl)
                ) {

                this._context.Jewelry.Add(jewelry);
                await this._context.SaveChangesAsync();

                return Ok(await this._context.Jewelry.ToListAsync());
            }
            return BadRequest("POST: Invalid data values");
        }

        [HttpPut]
        public async Task<ActionResult<List<Jewelry>>> UpdateJewelry(Jewelry jewelry)
        {
            if (
                JewelryService.ValidateName(jewelry.Name) &&
                JewelryService.ValidateUrl(jewelry.ImageUrl)
                )
            {

                this._context.Jewelry.Update(jewelry);
                await this._context.SaveChangesAsync();

                return Ok(await this._context.Jewelry.ToListAsync());
            }
            return BadRequest("PUT: Invalid data values");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Jewelry>>> DeleteJewelry(int id)
        {
            var DBjewelry = await this._context.Jewelry.FindAsync(id);
            if (DBjewelry == null)
            {
                return BadRequest("Value is null");
            }
            this._context.Jewelry.Remove(DBjewelry);
            await this._context.SaveChangesAsync();
            return Ok(await this._context.Jewelry.ToListAsync());
        }
    }
}
