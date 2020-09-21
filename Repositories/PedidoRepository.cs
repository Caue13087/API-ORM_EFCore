using EFCore.Context;
using EFCore.Domains;
using EFCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext cont;

      
        public PedidoRepository()
        {
            cont = new PedidoContext();
        }
        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return cont.Pedidos
                 
                    .Include(c => c.PedidosItens)
                    .ThenInclude(c =>c.Produto)
                    .FirstOrDefault(p =>p.Id == id); 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido Cadastrar(List<PedidoItem> pedidosItens)
        {
            try
            {
                
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now
                   
                };

               
                foreach (var item in pedidosItens)
                {
                   
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, 
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    }) ;
                }
               
                cont.Pedidos.Add(pedido);
                
                cont.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> LerTodos()
        {
            try
            {
                return cont.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
