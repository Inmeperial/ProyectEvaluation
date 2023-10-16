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

    }
}
