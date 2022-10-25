using ApiCarros.Helpers;
using ApiCarros.Model;
using ApiCarros.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCarros.Controllers
{

    [Route("/api/Carro")]
    public class CarrosController : Controller
    {
        private readonly IRepositoryCarros _repository;
        
        public CarrosController(IRepositoryCarros repository)
        {
            _repository = repository;
        }



        [HttpPost]
        [Route("")]
        public IActionResult Cadastrar([FromBody]CarroVendido carro)
        {

            if(carro == null) return NotFound();


           bool Response =  _repository.CadastrarCarro(carro);

            if (!Response)
            {
                return NotFound();
            }


            return Created($"/api/Carro/{carro.Id}",carro);


        }


     


        [Route("")]
        [HttpGet]

        public IActionResult Obter()
        {
            var obj = _repository.ObterCarros();

            if (obj == null) return NotFound();

            return Json(obj);   
        }

       

    }
}
