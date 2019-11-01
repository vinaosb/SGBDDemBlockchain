using System.Collections.Generic;
using System.Numerics;

namespace API.SQL.Models
{
	public partial class Regiao
	{
		public Regiao()
		{
			Estado = new HashSet<Estado>();
		}

		public long CodRegiao { get; set; }
		public string NomeRegiao { get; set; }
		public BigInteger? Id { get; set; }

		public virtual ICollection<Estado> Estado { get; set; }
	}
}
