using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JsonAnalyzer_MService.Models;

namespace JsonAnalyzer_MService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeFilesController : ControllerBase
    {
        private readonly NodeContext _context;

        public NodeFilesController(NodeContext context)
        {
            _context = context;
        }

        // GET: api/NodeFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodeFile>>> GetNodeFiles()
        {
          if (_context.NodeFiles == null)
          {
              return NotFound();
          }
            return await _context.NodeFiles.ToListAsync();
        }

        // GET: api/NodeFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NodeFile>> GetNodeFile(long id)
        {
          if (_context.NodeFiles == null)
          {
              return NotFound();
          }
            var nodeFile = await _context.NodeFiles.FindAsync(id);

            if (nodeFile == null)
            {
                return NotFound();
            }

            return nodeFile;
        }

        // PUT: api/NodeFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNodeFile(long id, NodeFile nodeFile)
        {
            if (id != nodeFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(nodeFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeFileExists(id))
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

        // POST: api/NodeFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NodeFile>> PostNodeFile(NodeFile nodeFile)
        {
          if (_context.NodeFiles == null)
          {
              return Problem("Entity set 'NodeContext.NodeFiles'  is null.");
          }
            _context.NodeFiles.Add(nodeFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNodeFile", new { id = nodeFile.Id }, nodeFile);
        }

        // DELETE: api/NodeFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNodeFile(long id)
        {
            if (_context.NodeFiles == null)
            {
                return NotFound();
            }
            var nodeFile = await _context.NodeFiles.FindAsync(id);
            if (nodeFile == null)
            {
                return NotFound();
            }

            _context.NodeFiles.Remove(nodeFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NodeFileExists(long id)
        {
            return (_context.NodeFiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
