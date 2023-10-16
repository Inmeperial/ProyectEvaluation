using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JsonAnalyzer_MService.Models;
using Newtonsoft.Json;

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
        public async Task<ActionResult<string>> GetNodeFiles()
        {
            Task<string> json;

            using StreamReader reader = new StreamReader("MyData/sample.complejo.json");
            json = reader.ReadToEndAsync();
            return await json;
        }
    }
}
