using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using atividade_11._05.Models;


namespace atividade_11._05.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoPrecoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>()
        {
            new Produto
            {
                Id = 1,
                Nome = "Geladeira",
                Preco = 2000,
            },
            new Produto
            {
                Id = 2,
                Nome = "Microondas",
                Preco = 600,
            },
             new Produto
            {
                Id = 2,
                Nome = "Pendrive",
                Preco = 30,
            },
        };

        [HttpGet("ObterTodosOsProdutos")]
        public ActionResult<IEnumerable<Produto>> GetTodos()
        {
            var produtosComPrecoMaiorQue100 = produtos.Where(p => p.Preco > 100).ToList();
            if (produtosComPrecoMaiorQue100.Any())
            {
                return Ok(produtosComPrecoMaiorQue100);
            }

            return NotFound();
        }
    }
}