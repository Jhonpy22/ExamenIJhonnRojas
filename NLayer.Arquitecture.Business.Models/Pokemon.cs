using System;
using System.Net.Http;
using System.Threading.Tasks;



namespace NLayer.Arquitecture.Business.Models
{
     public class Pokemon
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string SpriteUrl { get; set;}
        public List<string> Moves {get;set;}


    }
}
