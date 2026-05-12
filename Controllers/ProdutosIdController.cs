using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using atividade_11._05.Models;

namespace atividade_11._05.Controllers
{
    
    public class ProdutosIdController : ControllerBase
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

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
    }
}