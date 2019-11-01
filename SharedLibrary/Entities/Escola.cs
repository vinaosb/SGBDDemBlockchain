using System.Collections.Generic;
using System.Numerics;

namespace API.SQL.Models
{
	public partial class Escola
	{
		public Escola()
		{
			CensoEscola = new HashSet<CensoEscola>();
			CorreioEletronico = new HashSet<CorreioEletronico>();
			Telefone = new HashSet<Telefone>();
		}

		public long CodEntidade { get; set; }
		public long CodEndereco { get; set; }
		public bool? Localizacao { get; set; }
		public string Nome { get; set; }
		public string Categoria { get; set; }
		public string IdLongitude { get; set; }
		public string IdLatitude { get; set; }
		public string InstituicaoSemFimLucrativo { get; set; }
		public BigInteger? Id { get; set; }

		public virtual Endereco CodEnderecoNavigation { get; set; }
		public virtual MantenedoraDaEscola MantenedoraDaEscola { get; set; }
		public virtual ICollection<CensoEscola> CensoEscola { get; set; }
		public virtual ICollection<CorreioEletronico> CorreioEletronico { get; set; }
		public virtual ICollection<Telefone> Telefone { get; set; }
	}
}
