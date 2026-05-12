using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using atividade_11._05.Models;

namespace atividade_11._05.Controllers
{
    public class AlunoIdController : ControllerBase
    {
        private static List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno
            {
                Id = 1,
                Nome = "João",
                Email = "joao@example.com"
            },
            new Aluno
            {
                Id = 2,
                Nome = "Eduardo",
                Email = "eduardo@example.com"
            },
        };

        [HttpGet("ObterAlunoPorId/{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpPost("AdicionarAluno")]
        public ActionResult<Aluno> AdicionarAluno(Aluno aluno)
        {
            alunos.Add(aluno);

            return CreatedAtAction(nameof(GetById),
                new { id = aluno.Id }, aluno);
        }

        [HttpPut("AtualizarAluno/{id}")]
        public ActionResult<Aluno> AtualizarAluno(int id, Aluno alunoAtualizado)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            aluno.Nome = alunoAtualizado.Nome;
            aluno.Email = alunoAtualizado.Email;

            return NoContent();
        }
    }
}