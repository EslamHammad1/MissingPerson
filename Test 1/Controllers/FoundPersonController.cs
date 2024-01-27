
namespace Test_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundPersonController : ControllerBase
    {
        private readonly MissingPersonEntity context;
        public FoundPersonController(MissingPersonEntity context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAllMissingperson()
        {
            List<FoundPerson> missList = context.foundPerson.ToList();
            return Ok(missList);
        }
        [HttpGet("{id:int}", Name = "GetOnefoundPrsRoute")]
        public IActionResult GetbyID(int id)
        {
            var miss = context.foundPerson.Include(u=>u.User).FirstOrDefault(m => m.Id == id);
            FoundPersonWithUserDTO foDTO = new FoundPersonWithUserDTO();
            foDTO.Id = miss.Id;
            foDTO.Name = miss.Name;
            foDTO.Age = miss.Age;
            foDTO.Gender = miss.Gender;
            foDTO.Date = miss.Date;
            foDTO.Address_City = miss.Address_City;
            foDTO.FoundCity = miss.FoundCity;
            foDTO.Image = miss.Image;
            foDTO.PersonWhoFoundhim = miss.User.Name;
            foDTO.PhonePersonWhoFoundhim = miss.User.Phone;  

            return Ok(foDTO);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetbyName(string name)
        {
            var miss = context.foundPerson.FirstOrDefault(m => m.Name == name);
            return Ok(miss);
        }
        [HttpPost]
        public IActionResult PostMissingperson(FoundPerson missPr)

        {
            if (ModelState.IsValid == true)
            {
                context.foundPerson.Add(missPr);
                context.SaveChanges();
                string? url = Url.Link("GetOnefoundPrsRoute", new { id = missPr.Id });
                return Created(url, missPr);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, FoundPerson newprs)
        {
            if (ModelState.IsValid == true)
            {
                FoundPerson? oldPrs = context.foundPerson.FirstOrDefault(m => m.Id == id);
                if (oldPrs != null)
                {
                    oldPrs.Name = newprs.Name;
                    oldPrs.Gender = newprs.Gender;
                    oldPrs.Address_City = newprs.Address_City;
                    oldPrs.Age = newprs.Age;
                    oldPrs.Date = newprs.Date;
                    oldPrs.FoundCity = newprs.FoundCity;
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
            FoundPerson? oldprs = context.foundPerson.FirstOrDefault(m => m.Id == id);
            if (oldprs != null)
            {
                try
                {
                    context.foundPerson.Remove(oldprs);
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
