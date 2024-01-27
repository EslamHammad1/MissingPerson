using Test_1.DataEF;
using Test_1.DTO;
using Test_1.Models;

namespace Test_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LostPersonController : ControllerBase
    {
        private readonly MissingPersonEntity context;
        public LostPersonController(MissingPersonEntity context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAllMissingperson()
        {
            List<LostPerson> missList = context.lostPerson.Include(u=>u.User).ToList();
            return Ok(missList);
        }
        [HttpGet("{id:int}", Name = "GetOnemissPrsRoute")]
        public IActionResult GetbyID(int id)
        {
            var miss = context.lostPerson.FirstOrDefault(m => m.Id == id);
            LostPersonWithUserDTO losDTO = new LostPersonWithUserDTO();
            losDTO.Id = miss.Id;
            losDTO.Name = miss.Name;
            losDTO.Age = miss.Age;
            losDTO.Gender = miss.Gender;
            losDTO.Date = miss.Date;
            losDTO.Address_City = miss.Address_City;
            losDTO.LostCity = miss.LostCity;
            losDTO.Image = miss.Image;
            losDTO.PersonWhoLost = miss.User.Name;
            losDTO.PhonePersonWhoLost = miss.User.Phone;
            return Ok(losDTO);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetbyName(string name)
        {
            var miss = context.lostPerson.FirstOrDefault(m => m.Name == name);
            return Ok(miss);
        }
        [HttpPost]
        public IActionResult PostMissingperson(LostPerson missPr)

        {
            if (ModelState.IsValid == true)
            {
                context.lostPerson.Add(missPr);
                context.SaveChanges();
                string? url = Url.Link("GetOnemissPrsRoute", new { id = missPr.Id });
                return Created(url, missPr);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, LostPerson newprs)
        {
            if (ModelState.IsValid == true)
            {
                LostPerson? oldPrs = context.lostPerson.FirstOrDefault(m => m.Id == id);
                if (oldPrs != null)
                {
                    oldPrs.Name = newprs.Name;
                    oldPrs.Gender = newprs.Gender;
                    oldPrs.Address_City = newprs.Address_City;
                    oldPrs.Age = newprs.Age;
                    oldPrs.Date = newprs.Date;
                    oldPrs.LostCity = newprs.LostCity;
                    oldPrs.Image = newprs.Image;
                    context.SaveChanges();
                    return StatusCode(204, newprs);
                }
                return BadRequest("ID Not Valid");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete( int id ) 
        {
            LostPerson? oldprs = context.lostPerson.FirstOrDefault(m => m.Id == id);
            if (oldprs != null)
            {
                try
                {
                    context.lostPerson.Remove(oldprs);
                    context.SaveChanges();
                    return StatusCode(204, "Record remove Success");
                }
                catch(Exception ex) 
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        
        
    }
}
