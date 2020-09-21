using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Utills
{
   
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", " ") + Path.GetExtension(file.FileName);

            
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/upload/imagens", nomeArquivo);

            
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

           
            file.CopyTo(streamImagem);

            
            return "https://localhost:44338/upload/imagens/" + nomeArquivo;
        }
    }

}
