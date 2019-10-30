-- Table: public.regiao

-- DROP TABLE public.regiao;

CREATE TABLE public.regiao
(
    cod_regiao bigint NOT NULL,
    nome_regiao text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT regiao_pkey PRIMARY KEY (cod_regiao)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.regiao
    OWNER to postgres;
    
-- Table: public.estado

-- DROP TABLE public.estado;

CREATE TABLE public.estado
(
    cod_estado bigint NOT NULL,
    "UF" character(2) COLLATE pg_catalog."default" NOT NULL,
    nome_estado text COLLATE pg_catalog."default" NOT NULL,
    cod_regiao bigint NOT NULL,
    CONSTRAINT estado_pkey PRIMARY KEY (cod_estado),
    CONSTRAINT estado_cod_regiao_fkey FOREIGN KEY (cod_regiao)
        REFERENCES public.regiao (cod_regiao) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.estado
    OWNER to postgres;   
    
    
-- Table: public.municipio

-- DROP TABLE public.municipio;

CREATE TABLE public.municipio
(
    cod_municipio bigint NOT NULL,
    cod_estado bigint NOT NULL,
    pk_cod_municipio_old bigint NOT NULL,
    nome_municipio text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT municipio_pkey PRIMARY KEY (cod_municipio),
    CONSTRAINT municipio_cod_estado_fkey FOREIGN KEY (cod_estado)
        REFERENCES public.estado (cod_estado) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.municipio
    OWNER to postgres;
    
-- Table: public.endereco

-- DROP TABLE public.endereco;

CREATE TABLE public.endereco
(
    cod_endereco bigint NOT NULL,
    cod_municipio bigint NOT NULL,
    cep text COLLATE pg_catalog."default" NOT NULL,
    nome_destrito text COLLATE pg_catalog."default" NOT NULL,
    endereco text COLLATE pg_catalog."default" NOT NULL,
    numero text COLLATE pg_catalog."default" NOT NULL,
    complemento text COLLATE pg_catalog."default" NOT NULL,
    bairro text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT endereco_pkey PRIMARY KEY (cod_endereco),
    CONSTRAINT endereco_cod_municipio_fkey FOREIGN KEY (cod_municipio)
        REFERENCES public.municipio (cod_municipio) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.endereco
    OWNER to postgres;
    
-- Table: public.escola

-- DROP TABLE public.escola;

CREATE TABLE public.escola
(
    cod_entidade bigint NOT NULL,
    cod_endereco bigint NOT NULL,
    localizacao boolean,
    nome text COLLATE pg_catalog."default" NOT NULL,
    categoria text COLLATE pg_catalog."default",
    id_longitude text COLLATE pg_catalog."default",
    id_latitude text COLLATE pg_catalog."default",
    instituicao_sem_fim_lucrativo text COLLATE pg_catalog."default",
    CONSTRAINT escola_pkey PRIMARY KEY (cod_entidade),
    CONSTRAINT escola_cod_endereco_fkey FOREIGN KEY (cod_endereco)
        REFERENCES public.endereco (cod_endereco) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.escola
    OWNER to postgres;
    
-- Table: public.mantenedora_da_escola

-- DROP TABLE public.mantenedora_da_escola;

CREATE TABLE public.mantenedora_da_escola
(
    cod_entidade bigint NOT NULL,
    empresa boolean NOT NULL,
    sindicato boolean NOT NULL,
    sistems_s_sesi boolean NOT NULL,
    senai boolean NOT NULL,
    sesc boolean NOT NULL,
    CONSTRAINT mantenedora_da_escola_pkey PRIMARY KEY (cod_entidade),
    CONSTRAINT mantenedora_da_escola_cod_entidade_fkey FOREIGN KEY (cod_entidade)
        REFERENCES public.escola (cod_entidade) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.mantenedora_da_escola
    OWNER to postgres;
    
-- Table: public.censo_escola

-- DROP TABLE public.censo_escola;

CREATE TABLE public.censo_escola
(
    id_dependencia_adm smallint,
    dependencia_administrativa text COLLATE pg_catalog."default",
    rede text COLLATE pg_catalog."default",
    data_inicio_ano_letivo date,
    data_fim_ano_letivo date,
    situacao_funcionamento text COLLATE pg_catalog."default",
    ef_organizado_em_ciclos boolean,
    atividade_complementar text COLLATE pg_catalog."default",
    documento_regulamentacao text COLLATE pg_catalog."default",
    acessibilidade boolean,
    dependencias_pne text COLLATE pg_catalog."default",
    sanitarios_pne text COLLATE pg_catalog."default",
    aee text COLLATE pg_catalog."default",
    num_salas_existentes bigint,
    num_salas_usadas bigint,
    num_salas_leitura bigint,
    num_funcionarios bigint,
    educacao_indigena boolean,
    lingua_indigena boolean,
    lingua_portuguesa boolean,
    espaco_turma_pba boolean,
    abre_final_semana boolean,
    mod_ens_regular boolean,
    mod_educ_especial boolean,
    mod_eja boolean,
    ano smallint NOT NULL,
    cod_entidade bigint NOT NULL,
    CONSTRAINT censo_escola_pkey PRIMARY KEY (ano, cod_entidade),
    CONSTRAINT censo_escola_cod_entidade_fkey FOREIGN KEY (cod_entidade)
        REFERENCES public.escola (cod_entidade) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.censo_escola
    OWNER to postgres;
    
-- Table: public.correio_eletronico

-- DROP TABLE public.correio_eletronico;

CREATE TABLE public.correio_eletronico
(
    cod_entidade bigint NOT NULL,
    ano smallint NOT NULL,
    email text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT correio_eletronico_pkey PRIMARY KEY (cod_entidade, ano),
    CONSTRAINT correio_eletronico_cod_entidade_fkey FOREIGN KEY (cod_entidade)
        REFERENCES public.escola (cod_entidade) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.correio_eletronico
    OWNER to postgres;
   

-- Table: public.telefone

-- DROP TABLE public.telefone;

CREATE TABLE public.telefone
(
    numero bigint NOT NULL,
    cod_entidade bigint NOT NULL,
    ano smallint NOT NULL,
    ddd smallint,
    fax boolean,
    CONSTRAINT telefone_pkey PRIMARY KEY (numero, cod_entidade, ano),
    CONSTRAINT telefone_cod_entidade_fkey FOREIGN KEY (cod_entidade)
        REFERENCES public.escola (cod_entidade) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.telefone
    OWNER to postgres;