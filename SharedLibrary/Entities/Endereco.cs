using System.Collections.Generic;
using System.Numerics;

namespace API.SQL.Models
{
	public partial class Endereco
	{
		public Endereco()
		{
			Escola = new HashSet<Escola>();
		}

		public long CodEndereco { get; set; }
		public long CodMunicipio { get; set; }
		public string Cep { get; set; }
		public string NomeDestrito { get; set; }
		public string Endereco1 { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string Bairro { get; set; }
		public BigInteger? Id { get; set; }

		public virtual Municipio CodMunicipioNavigation { get; set; }
		public virtual ICollection<Escola> Escola { get; set; }
	}
}
