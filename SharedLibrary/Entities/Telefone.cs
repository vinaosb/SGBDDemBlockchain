using System.Numerics;

namespace API.SQL.Models
{
	public partial class Telefone
	{
		public long Numero { get; set; }
		public long CodEntidade { get; set; }
		public short Ano { get; set; }
		public short? Ddd { get; set; }
		public bool? Fax { get; set; }
		public BigInteger? Id { get; set; }

		public virtual Escola CodEntidadeNavigation { get; set; }
	}
}
