using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
   public class Pessoa : Notificar
    {
        [Key]
        public int PessoaId { get; private set; }
        public string Nome   { get; private set; }
        public string SobreNome { get; private set; }
        public Pessoa( string nome, string sobrenome)
        {
            this.Nome = nome;
            this.SobreNome = sobrenome;
        }

        public Pessoa()
        {

        }

        public bool Valido()
        {
            NaoAceitaVazio( Nome, "Nome");
            NaoAceitaVazio(SobreNome, "SobreNome");
            NaoAceitaNulo(Nome, "Nome");
            NaoAceitaNulo(SobreNome, "SobreNome");

            if (!Notificas.Any()) return true;
            return false;
        }

        private void NaoAceitaVazio(string valor, string propriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(propriedade))
                Notificas.Add(new Notificar { Mensagem = string.Format("Campo Requirido"), Propriedade = propriedade });
        }

        private void NaoAceitaNulo(object object1, string strProperty)
        {
            if (object1 == null)
                Notificas.Add(new Notificar { Mensagem = string.Format("Campo Requirido"), Propriedade = strProperty });

        }



    }
}
