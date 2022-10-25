using ApiCarros.Helpers;
using ApiCarros.Model;
using ApiCarros.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiCarros.Controllers
{
    [Route("/api/Estoque")]
    public class EstoqueController : Controller
    {
        private readonly IRepositoryEstoque _repository;
        public EstoqueController(IRepositoryEstoque repository)
        {
            _repository = repository;
        }


        [Route("")]
        [HttpGet]
        public IActionResult ObterTodos([FromQuery]CarroQuery query)
        {

            


            var obj = _repository.ObterTodos(query);

            if(obj.Count == 0) return NotFound();


            return Ok(obj);

        }




        [Route("")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody]Carro carro)
        {

            

            _repository.Cadastrar(carro);
            return Created($"/api/Carro/{carro.Id}", carro);
        }



        [Route("{id}")]

        [HttpPut]

        public IActionResult Atualizar(int id, [FromQuery]UpdateQuery carro)
        {

            if (_repository.ObterCarro(id) == null)
                return NotFound();


            _repository.Atualizar(id, carro);


            return Ok();

        }


        [Route("Filtro")]
        [HttpGet] 
        public IActionResult ObterFiltros(FilterQuery query)
        {


            var obj = _repository.ObterFiltros();


            return Ok(obj);

        }

    }
}
