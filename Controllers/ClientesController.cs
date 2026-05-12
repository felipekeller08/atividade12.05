using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using atividade_11._05.Models;

namespace atividade_11._05.Controllers 
{
    
    public class ClientesController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente
            {
                Id = 1,
                Nome = "João",
                Email = "joao@example.com"
            },
            new Cliente
            {
                Id = 2,
                Nome = "Eduardo",
                Email = "eduardo@example.com"
            },
        };

        [HttpGet("ObterTodosOsClientes")]
        public ActionResult<IEnumerable<Cliente>> GetTodos()
        {
            return Ok(clientes);
        }

        [HttpPost("AdicionarCliente")]
        public ActionResult<Cliente> AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);

            return CreatedAtAction(nameof(GetTodos),
                new { id = cliente.Id }, cliente);
        }
    }
}