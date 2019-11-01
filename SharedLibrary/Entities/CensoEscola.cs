using System;
using System.Numerics;

namespace API.SQL.Models
{
	public partial class CensoEscola
	{
		public short? IdDependenciaAdm { get; set; }
		public string DependenciaAdministrativa { get; set; }
		public string Rede { get; set; }
		public DateTime? DataInicioAnoLetivo { get; set; }
		public DateTime? DataFimAnoLetivo { get; set; }
		public string SituacaoFuncionamento { get; set; }
		public bool? EfOrganizadoEmCiclos { get; set; }
		public string AtividadeComplementar { get; set; }
		public string DocumentoRegulamentacao { get; set; }
		public bool? Acessibilidade { get; set; }
		public string DependenciasPne { get; set; }
		public string SanitariosPne { get; set; }
		public string Aee { get; set; }
		public long? NumSalasExistentes { get; set; }
		public long? NumSalasUsadas { get; set; }
		public long? NumSalasLeitura { get; set; }
		public long? NumFuncionarios { get; set; }
		public bool? EducacaoIndigena { get; set; }
		public bool? LinguaIndigena { get; set; }
		public bool? LinguaPortuguesa { get; set; }
		public bool? EspacoTurmaPba { get; set; }
		public bool? AbreFinalSemana { get; set; }
		public bool? ModEnsRegular { get; set; }
		public bool? ModEducEspecial { get; set; }
		public bool? ModEja { get; set; }
		public short Ano { get; set; }
		public long CodEntidade { get; set; }
		public BigInteger? Id { get; set; }

		public virtual Escola CodEntidadeNavigation { get; set; }
	}
}
