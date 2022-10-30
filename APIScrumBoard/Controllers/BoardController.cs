using Microsoft.AspNetCore.Mvc;
using ScrumBoard;
using Microsoft.Extensions.Caching.Memory;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIScrumBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public BoardController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET: api/<BoardController>
        [HttpGet]
        public IEnumerable<Board> Get()
        {
            List<Board> boards = new List<Board>();
            _memoryCache.TryGetValue("boards", out boards);
            return boards;
        }

        // GET api/<BoardController>/5
        [HttpGet("{name}")]
        public Board? Get(string name)
        {
            List<Board> boards;
            _memoryCache.TryGetValue("boards", out boards);
            if (boards == null) return null;

            return boards.Find(Obj => Obj.BoardName == name);
        }

        // POST api/<BoardController>
        [HttpPost]
        public void Post([FromBody] string name)
        {
            List<Board> boards;
            _memoryCache.TryGetValue("boards", out boards);
            if (boards == null) boards = new List<Board>();
            boards.Add(new Board(name));

            _memoryCache.Set("boards", boards);
        }

        // PUT api/<BoardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
