using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domains;
using EFCore.Interfaces;
using EFCore.Repositories;
using EFCore.Utills;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Senai.EfCore.Tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        /// <summary>
        /// todos os produtos cadastrados
        /// </summary>
        /// <returns>Lista com todos os produtos</returns>
        [HttpGet]
        public IActionResult Get() // IActionResult vou retornar resultado da minha ação
        {
            // tentar
            try
            {
               
                var produtos = _produtoRepository.LerTodos();

                
                if (produtos.Count == 0)
                    return NoContent();

            
                return Ok(new{
                    
                    TotalCount = produtos.Count,
                    data = produtos
                });
            }
            
            catch (Exception)
            {
                
                return BadRequest(new { 
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos. Envie um e-mail para email@gmail.com informando"
                });
            }
        }

       
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                
                var produto =  _produtoRepository.BuscarPorId(id);

                
                if(produto == null)
                
                    return NotFound();
                
                return Ok(id);

            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                
                if(produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = urlImagem;
                }

               
                 _produtoRepository.Cadastrar(produto);

                
                return Ok(produto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                
                var produtoTemp = _produtoRepository.BuscarPorId(id);

                
                if (produtoTemp == null)
                    return NotFound();

                
                return Ok(produto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                
                _produtoRepository.Excluir(id);

                
                return Ok(id);


            }
            catch (Exception ex)
            {

                
                return BadRequest(ex.Message);
            }
        }
    }
}