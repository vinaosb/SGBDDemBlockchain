using System.Collections.Generic;
using System.Numerics;

namespace API.SQL.Models
{
	public partial class Estado
	{
		public Estado()
		{
			Municipio = new HashSet<Municipio>();
		}

		public long CodEstado { get; set; }
		public string Uf { get; set; }
		public string NomeEstado { get; set; }
		public long CodRegiao { get; set; }
		public BigInteger? Id { get; set; }

		public virtual Regiao CodRegiaoNavigation { get; set; }
		public virtual ICollection<Municipio> Municipio { get; set; }
	}
}
