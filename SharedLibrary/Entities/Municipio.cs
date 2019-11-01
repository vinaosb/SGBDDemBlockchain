using System.Collections.Generic;
using System.Numerics;

namespace API.SQL.Models
{
	public partial class Municipio
	{
		public Municipio()
		{
			Endereco = new HashSet<Endereco>();
		}

		public long CodMunicipio { get; set; }
		public long CodEstado { get; set; }
		public long PkCodMunicipioOld { get; set; }
		public string NomeMunicipio { get; set; }
		public BigInteger? Id { get; set; }

		public virtual Estado CodEstadoNavigation { get; set; }
		public virtual ICollection<Endereco> Endereco { get; set; }
	}
}
