using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.Microservice.Data;
using Customer.Microservice.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemeController : ControllerBase
    {
        private IApplicationDbContext _context;
        public MemeController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Meme meme)
        {
            //string result = await Request.Content.ReadAsStringAsync();

            //HttpContent requestContent = Request.Bod;
            //string jsonContent = requestContent.ReadAsStringAsync().Result;
            //Meme meme = JsonConvert.DeserializeObject<Meme>(jsonContent);
            _context.Memes.Add(meme);
            await _context.SaveChanges();
            return Ok(meme.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var memes = await _context.Memes.ToListAsync();
            if (memes == null) return NotFound();
            return Ok(memes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meme = await _context.Memes.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (meme == null) return NotFound();
            return Ok(meme);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var meme = await _context.Memes.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (meme == null) return NotFound();
            _context.Memes.Remove(meme);
            await _context.SaveChanges();
            return Ok(meme.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Meme memeData)
        {
            var meme = _context.Memes.Where(a => a.Id == id).FirstOrDefault();

            if (meme == null) return NotFound();
            else
            {
                meme.TopText = memeData.TopText;
                meme.BottomText = memeData.BottomText;
                await _context.SaveChanges();
                return Ok(meme.Id);
            }
        }
    }
}