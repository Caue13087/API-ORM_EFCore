using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCore.Domains
{
    /// <summary>
    /// Define a classe produto
    /// </summary>
    public class Produto : BaseDomain
    {
        // guid - codigo de identificacao
        public string   Nome { get; set; }
        public float    Preco { get; set; }
     
        [NotMapped] 
        [JsonIgnore]
        public IFormFile Imagem { get; set; }
      
        public string UrlImagem { get; set; }

       
        public List<PedidoItem> PedidoItens { get; set; }
    }
}
