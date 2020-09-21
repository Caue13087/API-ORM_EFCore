using EFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Interfaces
{
    interface IProdutoRepository
    {
        // Interface assinador de contratos
        List<Produto> LerTodos();

        Produto BuscarPorId(Guid id);

       List<Produto> BuscarporNome(string nome);

        void Cadastrar(Produto produto);

        void Alterar(Produto produto);

        void Excluir(Guid id);


    }
}
