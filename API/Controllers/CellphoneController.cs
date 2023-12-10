using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CellphoneAPI.Model;
using CellphoneAPI.Data;


namespace CellphoneAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CellphoneController : ControllerBase
    {
        private readonly ApiContext _context;

        public CellphoneController(ApiContext context)
        {
            _context = context;
        }

        // Create / Edit
        [HttpPost]
        public JsonResult CreateEdit(Cellphone cellphone)
        {
            if (cellphone.ID == 0)
            {
                _context.Cellphones.Add(cellphone);
            }
            else
            {
                var cellphoneInDb = _context.Cellphones.Find(cellphone.ID);

                if (cellphoneInDb == null) 
                    return new JsonResult(NotFound());

                cellphoneInDb = cellphone;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(cellphone));
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Cellphones.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }        
        
        // Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Cellphones.ToList();

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Cellphones.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Cellphones.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
