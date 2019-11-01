using System.Numerics;

namespace API.SQL.Models
{
	public partial class CorreioEletronico
	{
		public long CodEntidade { get; set; }
		public short Ano { get; set; }
		public string Email { get; set; }
		public BigInteger? Id { get; set; }

		public virtual Escola CodEntidadeNavigation { get; set; }
	}
}
