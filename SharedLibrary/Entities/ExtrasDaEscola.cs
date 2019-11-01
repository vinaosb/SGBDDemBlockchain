using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Numerics;

namespace SharedLibrary.Entities.Custom
{
	public class ExtrasDaEscola
	{
		public class Tipo_Educacional
		{
			public int Cod_TE { get; set; }
			public string TipoEducacional { get; set; }
		}
		public class Numero_Matriculas
		{
			public Tipo_Educacional TE { get; set; }
			public string Especificacao { get; set; }
			public int Numero_De_Matriculas { get; set; }
		}
		public class MediaPorAlunoPorEscola
		{
			public Tipo_Educacional Cod_TE { get; set; }
			public int Serie { get; set; }
			public double Media { get; set; }
		}
		public class EquipamentosDaEscola
		{
			public string Nome_Equip { get; set; }
			public short Numero_De_Equip { get; set; }
		}
		public class MateriaisDidaticosEspecificos
		{
			public bool MaterialEspecificoNaoUtiliza { get; set; }
			public bool MaterialEspecificoQuilombola { get; set; }
			public bool MaterialEspecificoIndigena { get; set; }
		}
		public class EspecificacaoEscolaPrivada
		{
			public bool EscolaEFilantropica { get; set; }
			public int NumCNPJEscolaPrivada { get; set; }
		}
		public class Indexer
		{
			public long Cod_Entidade { get; set; }
			public short Ano { get; set; }
		}

		[BsonId]
		public Indexer ID { get; set; }
		public List<Numero_Matriculas> Matriculas { get; set; }
		public List<MediaPorAlunoPorEscola> Medias { get; set; }
		public List<EquipamentosDaEscola> Equipamentos { get; set; }
		public MateriaisDidaticosEspecificos MateriaisEspecificos { get; set; }
		public List<string> DependenciasDaEscola { get; set; }
		public int NumCNPJUnidadeExecutora { get; set; }
		public string ServicosDaEscola { get; set; }
		public EspecificacaoEscolaPrivada EscolaPrivada { get; set; }
		public BigInteger Id { get; set; }
	}
}
