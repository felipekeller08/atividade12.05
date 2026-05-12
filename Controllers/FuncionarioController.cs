using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using atividade_11._05.Models;

namespace atividade_11._05.Controllers 
{
    
    public class FuncionarioController : ControllerBase
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>()
        {
            new Funcionario
            {
                Id = 1,
                Nome = "Robson",
                Cargo = "Gerente"
            },
            new Funcionario
            {
                Id = 2,
                Nome = "Carlos",
                Cargo = "Desenvolvedor"
            },
        };

        [HttpGet("ObterTodosOsFuncionarios")]
        public ActionResult<IEnumerable<Funcionario>> GetTodos()
        {
            return Ok(funcionarios);
        }

        [HttpPost("AdicionarFuncionario")]
        public ActionResult<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);

            return CreatedAtAction(nameof(GetTodos),
                new { id = funcionario.Id }, funcionario);
        }
    }
}