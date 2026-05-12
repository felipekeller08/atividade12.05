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
    public class ProdutosController : ControllerBase
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
        };

        [HttpGet("ObterTodosOsProdutos")]
        public ActionResult<IEnumerable<Produto>> GetTodos()
        {
            return Ok(produtos);
        }

        [HttpPost("AdicionarProduto")]
        public ActionResult<Produto> AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);

            return CreatedAtAction(nameof(GetTodos),
                new { id = produto.Id }, produto);
        }

          [HttpPut("AtualizarNome/{id}")] 
        public ActionResult<Produto> AtualizarProduto(int id, Produto produtoAtualizado)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            produto.Nome = produtoAtualizado.Nome;

            return Ok(produto);
        }
        [HttpPut("AtualizarPreco/{id}")]
        public ActionResult<Produto> AtualizarPreco(int id, Produto produtoAtualizado)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            produto.Preco = produtoAtualizado.Preco;

            return Ok(produto);
        }
    }
}