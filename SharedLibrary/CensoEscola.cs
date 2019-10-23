using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedLibrary
{
	public class CensoEscola
	{
		public int Ano { get; set; }
		public int CodEntidade { get; set; }
		public int IdDependenciaAdm { get; set; }
		public string DependenciaAdministrativa { get; set; }
		public bool Rede { get; set; }
		public DateTime DataInicioAnoLetivo { get; set; }
		public DateTime DataFimAnoLetivo { get; set; }
		public string SituacaoFuncionamento { get; set; }
		public bool EFOrganizadoEmCiclos { get; set; }

	}
}
