using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBech.Data;
using PruebaTecnicaBech.DTOs;
using PruebaTecnicaBech.Models;

namespace PruebaTecnicaBech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listaPost")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .ToListAsync();
        }

        [HttpGet("detallePost/{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) return NotFound();
            return post;
        }

        
        [HttpPost("crearPost")]
        public async Task<ActionResult<Post>> CreatePost(PostDTO dto)
        {
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        
        [HttpPut("actualizarPost/{id}")]
        public async Task<IActionResult> UpdatePost(int id, PostDTO dto)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            post.Title = dto.Title;
            post.Content = dto.Content;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("eliminarPost/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/posts/test
        //Para probar el endpoint sin gaurdar los datos en la db
        [HttpPost("test")]
        public ActionResult<PostDTO> TestInput([FromBody] PostDTO dto)
        {
            
            return Ok(dto);
        }
    }
}
