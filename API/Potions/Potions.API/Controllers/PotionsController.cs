using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Potions.API.Data.PotionAPI;
using Potions.API.Models.PotionAPI;

namespace PotionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PotionsController : Controller
    {
        private readonly PotionsDbContext potionsDbContext;
        public PotionsController(PotionsDbContext potionsDbContext)
        {
            this.potionsDbContext = potionsDbContext;
        }
        // Get Potions
        [HttpGet]
        public async Task<IActionResult> GetAllPotions()
        {
            var potions = await potionsDbContext.Potions.ToListAsync();
            return Ok(potions);
        }

        // Get single potion
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetPotion")]
        public async Task<IActionResult> GetPotion([FromRoute] Guid id)
        {
            var potion = await potionsDbContext.Potions.FirstOrDefaultAsync(x => x.Id == id);
            if (potion != null)
            {
                return Ok(potion);
            }

            return NotFound("Potion not found");
        }

        // Add singl potion
        [HttpPost]

        public async Task<IActionResult> AddPotion([FromBody] Potion potion)
        {
            potion.Id = Guid.NewGuid();
            await potionsDbContext.Potions.AddAsync(potion);
            await potionsDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPotion), new { id = potion.Id }, potion);
        }

        // Updating a potion
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePotion([FromRoute] Guid id, [FromBody] Potion potion)
        {
            var existingPotion = await potionsDbContext.Potions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPotion != null)
            {
                existingPotion.Name = potion.Name;
                existingPotion.Description = potion.Description;
                existingPotion.Price = potion.Price;
                await potionsDbContext.SaveChangesAsync();
                return Ok(existingPotion);
            }
            else
                return NotFound("Potion not found");

        }

        // Delete a potion
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePotion([FromRoute] Guid id)
        {
            var existingPotion = await potionsDbContext.Potions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPotion != null)
            {
                potionsDbContext.Remove(existingPotion);
                await potionsDbContext.SaveChangesAsync();
                return Ok(existingPotion);
            }
            else
                return NotFound("Potion not found");
        }
    }
}