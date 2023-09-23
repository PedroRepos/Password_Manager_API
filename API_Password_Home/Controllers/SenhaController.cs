using API_Password_Home.Context;
using API_Password_Home.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Password_Home.Controllers
{
    /// <summary>
    /// Controladora da API que contém seus respectivos endpoints
    /// </summary>
    [ApiController]
    [Route("Api/[controller]")]
    public class SenhaController : ControllerBase   
    {
        private readonly Pass_Context _context;

        public SenhaController(Pass_Context context)
        {
            _context = context;
        }

        [HttpPost("InsereNovaSenha")]
        public IActionResult RegistraNovaSenha(Data_Password_Services services)
        {
            services.UltimaModificacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            _context.Add(services);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("MostarTodasAsSenhas")]
        public IActionResult BuscaTodasAsSenhas()
        {
            var buscaSenhas = _context.Data_Password_Services.ToList();

            if (buscaSenhas == null)
                return BadRequest();

            return Ok(buscaSenhas);
        }

        [HttpPut("AtualizaSenha/{id}")]
        public IActionResult AtualizaDadosPorId(int id, Data_Password_Services services)
        {
            var buscaSenhas = _context.Data_Password_Services.Find(id);

            if (buscaSenhas == null)
                return BadRequest();

            buscaSenhas.Nome = services.Nome;
            buscaSenhas.Senha = services.Senha;
            buscaSenhas.Plataforma = services.Plataforma;
            buscaSenhas.Email = services.Email;
            buscaSenhas.UltimaModificacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            _context.Data_Password_Services.Update(buscaSenhas);
            _context.SaveChanges();

            return Ok(buscaSenhas);
        }

        [HttpDelete("DeletaSenha/{id}")]
        public IActionResult DeletaDadosPorId(int id)
        {
            var buscaSenhas = _context.Data_Password_Services.Find(id);

            if (buscaSenhas == null)
                return BadRequest();

            _context.Data_Password_Services.Remove(buscaSenhas);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
