using System.Numerics;

namespace API.SQL.Models
{
	public partial class MantenedoraDaEscola
	{
		public long CodEntidade { get; set; }
		public bool Empresa { get; set; }
		public bool Sindicato { get; set; }
		public bool SistemsSSesi { get; set; }
		public bool Senai { get; set; }
		public bool Sesc { get; set; }
		public BigInteger? Id { get; set; }

		public virtual Escola CodEntidadeNavigation { get; set; }
	}
}
