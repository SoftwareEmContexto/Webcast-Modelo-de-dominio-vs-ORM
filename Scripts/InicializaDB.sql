USE MASTER
IF(EXISTS(SELECT * FROM sysdatabases WHERE name = 'SeuCarroNaVitrine'))
Begin
	ALTER DATABASE [SeuCarroNaVitrine] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE [SeuCarroNaVitrine]
END
ELSE
	CREATE DATABASE [SeuCarroNaVitrine]
END

GO

USE [SeuCarroNaVitrine]

GO

/****** Object:  Table [dbo].[Anunciante]    Script Date: 3/13/2017 4:03:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Anunciante](
	[AnuncianteId] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Sobrenome] [varchar](100) NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[Estado] [varchar](100) NOT NULL,
	[Cep] [int] NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[DDDTelefonePrincipal] [int] NULL,
	[TelefonePrincipal] [varchar](9) NULL,
	[DDDTelefoneComercial] [int] NULL,
	[TelefoneComercial] [varchar](9) NULL,
	[DDDCelular] [int] NULL,
	[Celular] [varchar](9) NULL,
 CONSTRAINT [PK_Anunciante_1] PRIMARY KEY CLUSTERED 
(
	[AnuncianteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Anuncio]    Script Date: 3/13/2017 4:03:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Anuncio](
	[AnuncioId] [uniqueidentifier] NOT NULL,
	[AnuncianteId] [uniqueidentifier] NOT NULL,
	[DataDePublicacao] [date] NOT NULL,
	[PeriodoInicio] [date] NOT NULL,
	[PeriodoFinal] [date] NOT NULL,
 CONSTRAINT [PK_Anuncio] PRIMARY KEY CLUSTERED 
(
	[AnuncioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Anuncio]  WITH CHECK ADD  CONSTRAINT [FK_Anuncio_Anunciante] FOREIGN KEY([AnuncianteId])
REFERENCES [dbo].[Anunciante] ([AnuncianteId])
GO

ALTER TABLE [dbo].[Anuncio] CHECK CONSTRAINT [FK_Anuncio_Anunciante]
GO


/****** Object:  Table [dbo].[Veiculo]    Script Date: 3/13/2017 4:03:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Veiculo](
	[VeiculoId] [uniqueidentifier] NOT NULL,
	[Marca] [varchar](100) NOT NULL,
	[Modelo] [varchar](100) NOT NULL,
	[AnoFabricacao] [int] NOT NULL,
	[AnoModelo] [int] NOT NULL,
	[Placa] [varchar](8) NOT NULL,
	[Kilometragem] [int] NOT NULL,
	[Portas] [int] NOT NULL,
	[Cambio] [varchar](50) NOT NULL,
	[Carroceria] [varchar](50) NOT NULL,
	[Cor] [varchar](50) NOT NULL,
	[Combustivel] [varchar](50) NOT NULL,
	[Preco] [decimal](18, 2) NOT NULL,
	[StatusDePublicacao] [varchar](50) NOT NULL,
	[Opcionais] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED 
(
	[VeiculoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Veiculo]  WITH CHECK ADD  CONSTRAINT [FK_anuncio] FOREIGN KEY([VeiculoId])
REFERENCES [dbo].[Anuncio] ([AnuncioId])
GO

ALTER TABLE [dbo].[Veiculo] CHECK CONSTRAINT [FK_anuncio]
GO