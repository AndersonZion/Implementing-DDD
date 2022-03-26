using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications
{
    [NotMapped]
    public class Notificar
    {
        [NotMapped]
        public string Propriedade { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }
        [NotMapped]
        public List<Notificar> Notificas { get; set; }
        public Notificar(){ Notificas = new List<Notificar>(); }

        public bool AssertArgumentNotNull(object object1, string propriedades)
        {
            if (object1 == null)
            {
                Notificas.Add(new Notificar
                { Mensagem = string.Format("Campo é requerido"), Propriedade = propriedades });
                return true;
            }
            return false;
        }
    
        public bool AssertArgumentNotEmpty(string valor, string propriedades)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(propriedades))
            {
                    Notificas.Add(new Notificar
                    { Mensagem = string.Format("Campo é requerido"), Propriedade = propriedades });
                    return true;
            }
            return false;
        }


   }    
}
