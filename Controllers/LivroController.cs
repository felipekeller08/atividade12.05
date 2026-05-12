using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using atividade_11._05.Models;

namespace atividade_11._05.Controllers 
{
    
    public class LivroController : ControllerBase
    {
        private static List<Livro> livros = new List<Livro>()
        {
            new Livro
            {
                Id = 1,
                Nome = "O Senhor dos Anéis",
                Preco = 39.90
            },
            new Livro
            {
                Id = 2,
                Nome = "Harry Potter",
                Preco = 29.90
            },
        };

        [HttpGet("ObterTodosOsLivros")]
        public ActionResult<IEnumerable<Livro>> GetTodos()
        {
            return Ok(livros);
        }

        [HttpPost("AdicionarLivro")]
        public ActionResult<Livro> AdicionarLivro(Livro livro)
        {
            livros.Add(livro);

            return CreatedAtAction(nameof(GetTodos),
                new { id = livro.Id }, livro);
        }
    }
}