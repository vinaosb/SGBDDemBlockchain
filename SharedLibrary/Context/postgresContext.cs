using Microsoft.EntityFrameworkCore;

namespace API.SQL.Models
{
	public partial class postgresContext : DbContext
	{
		public postgresContext()
		{
		}

		public postgresContext(DbContextOptions<postgresContext> options)
			: base(options)
		{
		}

		public virtual DbSet<CensoEscola> CensoEscola { get; set; }
		public virtual DbSet<CorreioEletronico> CorreioEletronico { get; set; }
		public virtual DbSet<Endereco> Endereco { get; set; }
		public virtual DbSet<Escola> Escola { get; set; }
		public virtual DbSet<Estado> Estado { get; set; }
		public virtual DbSet<MantenedoraDaEscola> MantenedoraDaEscola { get; set; }
		public virtual DbSet<Municipio> Municipio { get; set; }
		public virtual DbSet<Regiao> Regiao { get; set; }
		public virtual DbSet<Telefone> Telefone { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasPostgresExtension("adminpack");

			modelBuilder.Entity<CensoEscola>(entity =>
			{
				entity.HasKey(e => new { e.Ano, e.CodEntidade })
					.HasName("censo_escola_pkey");

				entity.ToTable("censo_escola");

				entity.Property(e => e.Ano).HasColumnName("ano");

				entity.Property(e => e.CodEntidade).HasColumnName("cod_entidade");

				entity.Property(e => e.AbreFinalSemana).HasColumnName("abre_final_semana");

				entity.Property(e => e.Acessibilidade).HasColumnName("acessibilidade");

				entity.Property(e => e.Aee).HasColumnName("aee");

				entity.Property(e => e.AtividadeComplementar).HasColumnName("atividade_complementar");

				entity.Property(e => e.DataFimAnoLetivo)
					.HasColumnName("data_fim_ano_letivo")
					.HasColumnType("date");

				entity.Property(e => e.DataInicioAnoLetivo)
					.HasColumnName("data_inicio_ano_letivo")
					.HasColumnType("date");

				entity.Property(e => e.DependenciaAdministrativa).HasColumnName("dependencia_administrativa");

				entity.Property(e => e.DependenciasPne).HasColumnName("dependencias_pne");

				entity.Property(e => e.DocumentoRegulamentacao).HasColumnName("documento_regulamentacao");

				entity.Property(e => e.EducacaoIndigena).HasColumnName("educacao_indigena");

				entity.Property(e => e.EfOrganizadoEmCiclos).HasColumnName("ef_organizado_em_ciclos");

				entity.Property(e => e.EspacoTurmaPba).HasColumnName("espaco_turma_pba");

				entity.Property(e => e.IdDependenciaAdm).HasColumnName("id_dependencia_adm");

				entity.Property(e => e.LinguaIndigena).HasColumnName("lingua_indigena");

				entity.Property(e => e.LinguaPortuguesa).HasColumnName("lingua_portuguesa");

				entity.Property(e => e.ModEducEspecial).HasColumnName("mod_educ_especial");

				entity.Property(e => e.ModEja).HasColumnName("mod_eja");

				entity.Property(e => e.ModEnsRegular).HasColumnName("mod_ens_regular");

				entity.Property(e => e.NumFuncionarios).HasColumnName("num_funcionarios");

				entity.Property(e => e.NumSalasExistentes).HasColumnName("num_salas_existentes");

				entity.Property(e => e.NumSalasLeitura).HasColumnName("num_salas_leitura");

				entity.Property(e => e.NumSalasUsadas).HasColumnName("num_salas_usadas");

				entity.Property(e => e.Rede).HasColumnName("rede");

				entity.Property(e => e.SanitariosPne).HasColumnName("sanitarios_pne");

				entity.Property(e => e.SituacaoFuncionamento).HasColumnName("situacao_funcionamento");

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");

				entity.HasOne(d => d.CodEntidadeNavigation)
					.WithMany(p => p.CensoEscola)
					.HasForeignKey(d => d.CodEntidade)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("censo_escola_cod_entidade_fkey");
			});

			modelBuilder.Entity<CorreioEletronico>(entity =>
			{
				entity.HasKey(e => new { e.CodEntidade, e.Ano })
					.HasName("correio_eletronico_pkey");

				entity.ToTable("correio_eletronico");

				entity.Property(e => e.CodEntidade).HasColumnName("cod_entidade");

				entity.Property(e => e.Ano).HasColumnName("ano");

				entity.Property(e => e.Email)
					.IsRequired()
					.HasColumnName("email");

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");

				entity.HasOne(d => d.CodEntidadeNavigation)
					.WithMany(p => p.CorreioEletronico)
					.HasForeignKey(d => d.CodEntidade)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("correio_eletronico_cod_entidade_fkey");
			});

			modelBuilder.Entity<Endereco>(entity =>
			{
				entity.HasKey(e => e.CodEndereco)
					.HasName("endereco_pkey");

				entity.ToTable("endereco");

				entity.Property(e => e.CodEndereco)
					.HasColumnName("cod_endereco")
					.ValueGeneratedNever();

				entity.Property(e => e.Bairro)
					.IsRequired()
					.HasColumnName("bairro");

				entity.Property(e => e.Cep)
					.IsRequired()
					.HasColumnName("cep");

				entity.Property(e => e.CodMunicipio).HasColumnName("cod_municipio");

				entity.Property(e => e.Complemento)
					.IsRequired()
					.HasColumnName("complemento");

				entity.Property(e => e.Endereco1)
					.IsRequired()
					.HasColumnName("endereco");

				entity.Property(e => e.NomeDestrito)
					.IsRequired()
					.HasColumnName("nome_destrito");

				entity.Property(e => e.Numero)
					.IsRequired()
					.HasColumnName("numero");

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");

				entity.HasOne(d => d.CodMunicipioNavigation)
					.WithMany(p => p.Endereco)
					.HasForeignKey(d => d.CodMunicipio)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("endereco_cod_municipio_fkey");
			});

			modelBuilder.Entity<Escola>(entity =>
			{
				entity.HasKey(e => e.CodEntidade)
					.HasName("escola_pkey");

				entity.ToTable("escola");

				entity.Property(e => e.CodEntidade)
					.HasColumnName("cod_entidade")
					.ValueGeneratedNever();

				entity.Property(e => e.Categoria).HasColumnName("categoria");

				entity.Property(e => e.CodEndereco).HasColumnName("cod_endereco");

				entity.Property(e => e.IdLatitude).HasColumnName("id_latitude");

				entity.Property(e => e.IdLongitude).HasColumnName("id_longitude");

				entity.Property(e => e.InstituicaoSemFimLucrativo).HasColumnName("instituicao_sem_fim_lucrativo");

				entity.Property(e => e.Localizacao).HasColumnName("localizacao");

				entity.Property(e => e.Nome)
					.IsRequired()
					.HasColumnName("nome");

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");

				entity.HasOne(d => d.CodEnderecoNavigation)
					.WithMany(p => p.Escola)
					.HasForeignKey(d => d.CodEndereco)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("escola_cod_endereco_fkey");
			});

			modelBuilder.Entity<Estado>(entity =>
			{
				entity.HasKey(e => e.CodEstado)
					.HasName("estado_pkey");

				entity.ToTable("estado");

				entity.Property(e => e.CodEstado)
					.HasColumnName("cod_estado")
					.ValueGeneratedNever();

				entity.Property(e => e.CodRegiao).HasColumnName("cod_regiao");

				entity.Property(e => e.NomeEstado)
					.IsRequired()
					.HasColumnName("nome_estado");

				entity.Property(e => e.Uf)
					.IsRequired()
					.HasColumnName("UF")
					.HasMaxLength(2)
					.IsFixedLength();

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");

				entity.HasOne(d => d.CodRegiaoNavigation)
					.WithMany(p => p.Estado)
					.HasForeignKey(d => d.CodRegiao)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("estado_cod_regiao_fkey");
			});

			modelBuilder.Entity<MantenedoraDaEscola>(entity =>
			{
				entity.HasKey(e => e.CodEntidade)
					.HasName("mantenedora_da_escola_pkey");

				entity.ToTable("mantenedora_da_escola");

				entity.Property(e => e.CodEntidade)
					.HasColumnName("cod_entidade")
					.ValueGeneratedNever();

				entity.Property(e => e.Empresa).HasColumnName("empresa");

				entity.Property(e => e.Senai).HasColumnName("senai");

				entity.Property(e => e.Sesc).HasColumnName("sesc");

				entity.Property(e => e.Sindicato).HasColumnName("sindicato");

				entity.Property(e => e.SistemsSSesi).HasColumnName("sistems_s_sesi");

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");

				entity.HasOne(d => d.CodEntidadeNavigation)
					.WithOne(p => p.MantenedoraDaEscola)
					.HasForeignKey<MantenedoraDaEscola>(d => d.CodEntidade)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("mantenedora_da_escola_cod_entidade_fkey");
			});

			modelBuilder.Entity<Municipio>(entity =>
			{
				entity.HasKey(e => e.CodMunicipio)
					.HasName("municipio_pkey");

				entity.ToTable("municipio");

				entity.Property(e => e.CodMunicipio)
					.HasColumnName("cod_municipio")
					.ValueGeneratedNever();

				entity.Property(e => e.CodEstado).HasColumnName("cod_estado");

				entity.Property(e => e.NomeMunicipio)
					.IsRequired()
					.HasColumnName("nome_municipio");

				entity.Property(e => e.PkCodMunicipioOld).HasColumnName("pk_cod_municipio_old");

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");

				entity.HasOne(d => d.CodEstadoNavigation)
					.WithMany(p => p.Municipio)
					.HasForeignKey(d => d.CodEstado)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("municipio_cod_estado_fkey");
			});

			modelBuilder.Entity<Regiao>(entity =>
			{
				entity.HasKey(e => e.CodRegiao)
					.HasName("regiao_pkey");

				entity.ToTable("regiao");

				entity.Property(e => e.CodRegiao)
					.HasColumnName("cod_regiao")
					.ValueGeneratedNever();

				entity.Property(e => e.NomeRegiao)
					.IsRequired()
					.HasColumnName("nome_regiao");

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");
			});

			modelBuilder.Entity<Telefone>(entity =>
			{
				entity.HasKey(e => new { e.Numero, e.CodEntidade, e.Ano })
					.HasName("telefone_pkey");

				entity.ToTable("telefone");

				entity.Property(e => e.Numero).HasColumnName("numero");

				entity.Property(e => e.CodEntidade).HasColumnName("cod_entidade");

				entity.Property(e => e.Ano).HasColumnName("ano");

				entity.Property(e => e.Ddd).HasColumnName("ddd");

				entity.Property(e => e.Fax).HasColumnName("fax");

				entity.Property(e => e.Id).HasColumnName("IdBlockchain");

				entity.HasOne(d => d.CodEntidadeNavigation)
					.WithMany(p => p.Telefone)
					.HasForeignKey(d => d.CodEntidade)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("telefone_cod_entidade_fkey");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
