using ApiCarros.Model;
using ApiCarros.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCarros.Controllers
{


    [Route("/api/Cliente")]
    public class ClienteController : Controller
    {

        private readonly IRepositoryCliente _repository;


        public ClienteController(IRepositoryCliente repository)
        {
            _repository = repository;       
        }


        [Route("")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody]Cliente cliente)
        {

            if (cliente == null)
                return NotFound();
            _repository.Cadastrar(cliente);
            return Created($"/api/Cliente/{cliente.Id}", cliente);


        }



        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = _repository.ObterClientes();
            
            

            if (obj == null)
                return NotFound();

            return Json(obj);
        }


        [Route("{id}")]
        [HttpGet]

        public IActionResult GetOne(int id)
        {
           var obj =  _repository.ObterCliente(id);

            if (obj == null) return NotFound();

            return Ok(obj);

        }






    }
}
