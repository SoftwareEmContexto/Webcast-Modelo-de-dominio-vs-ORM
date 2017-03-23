﻿using Dapper;
using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using Webcast.ModeloDeDominioComORM.Negocio.DominioPuro.GerenciamentoDeAnunciante;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado.Enums;
using System;
using System.Data.SqlClient;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioDapper
{
    public sealed class AnuncioRepositorioSQL
    {
        public string StringDeConexao => @"Server=(LocalDb)\MSSQLLocalDB;Database=SeuCarroNaVitrine;Trusted_Connection=True;";

        public AnuncioRepositorioSQL()
        {

        }

        public Anuncio ObterPorId(Identidade id)
        {
            using (SqlConnection cn = new SqlConnection(StringDeConexao))
            {
                var select =
                            @"
                                SELECT [AnuncioId]
                                  ,[AnuncianteId]
                                  ,[DataDePublicacao]
                                  ,[PeriodoInicio]
                                  ,[PeriodoFinal]
                                FROM [SeuCarroNaVitrine].[dbo].[Anuncio]
                                WHERE AnuncioId = @id

                                SELECT [VeiculoId]
                                    ,[Marca]
                                    ,[Modelo]
                                    ,[AnoFabricacao]
                                    ,[AnoModelo]
                                    ,[Placa]
                                    ,[Kilometragem]
                                    ,[Portas]
                                    ,[Cambio]
                                    ,[Carroceria]
                                    ,[Cor]
                                    ,[Combustivel]
                                    ,[Preco]
                                    ,[StatusDePublicacao]
                                    ,[Opcionais]
                                FROM [SeuCarroNaVitrine].[dbo].[Veiculo]
                                WHERE VeiculoId = @id
                            ";

                using (var result = cn.QueryMultiple(select, new { id = id.ToString() }))
                {
                    var anuncioDyn = result.ReadSingleOrDefault();
                    var veiculoDyn = result.ReadSingleOrDefault();

                    var anuncioId = new Identidade(Guid.Parse(anuncioDyn.AnuncioId.ToString()));
                    var anuncianteId = new Identidade(Guid.Parse(anuncioDyn.AnuncianteId.ToString()));
                    var veiculoId = new Identidade(Guid.Parse(veiculoDyn.VeiculoId.ToString()));

                    var vigencia = Periodo.Novo(anuncioDyn.PeriodoInicio, anuncioDyn.PeriodoFinal);

                    var detalheDoVeiculo = DetalheDoVeiculo.Novo(veiculoDyn.Placa.ToString(),
                        (int)veiculoDyn.Kilometragem,
                        Enumeration.FromDisplayName<TipoDoCambio>(veiculoDyn.Cambio.ToString()),
                        Enumeration.FromDisplayName<TipoDaCarroceria>(veiculoDyn.Carroceria.ToString()),
                        Enumeration.FromDisplayName<Cor>(veiculoDyn.Cor.ToString()),
                        Enumeration.FromDisplayName<TipoDeCombustivel>(veiculoDyn.Combustivel.ToString()),
                        (int)veiculoDyn.Portas,
                        (decimal)veiculoDyn.Preco);

                    var detalheDeFabricacao = DetalheDeFabricacao.Novo(veiculoDyn.Marca, veiculoDyn.Modelo,
                        veiculoDyn.AnoFabricacao, veiculoDyn.AnoModelo);

                    var opcionais = ItensOpcicionais.Novo(veiculoDyn.Opcionais);

                    var veiculo = new Veiculo(veiculoId, detalheDeFabricacao, opcionais, detalheDoVeiculo);

                    var anuncio = new Anuncio(anuncioId, anuncianteId, vigencia, veiculo);

                    return anuncio;
                }
            }
        }

        public void Salvar(Anuncio agregado)
        {
            using (SqlConnection cn = new SqlConnection(StringDeConexao))
            {
                cn.Open();

                var insertAnuncio =
                            @"
                                INSERT INTO [dbo].[Anuncio]
                                       ([AnuncioId] ,[AnuncianteId], [DataDePublicacao]
                                       ,[PeriodoInicio], [PeriodoFinal])
                                 VALUES
                                       (@anuncioId, @anuncianteId, @dataDePublicacao,
                                        @periodoInicio, @periodoFinal)
                            ";

                var insertVeiculo =
                            @"
                                INSERT INTO [dbo].[Veiculo]
                                       ([VeiculoId], [Marca], [AnoFabricacao]
                                       ,[Modelo],[AnoModelo],[Placa],[Kilometragem]
                                       ,[Portas],[Cambio],[Carroceria],[Cor]
                                       ,[Combustivel],[Preco],[StatusDePublicacao],[Opcionais])
                                 VALUES
                                       (@veiculoId,@marca,@anoFabricacao
                                       ,@modelo,@anoModelo,@placa,@kilometragem
                                       ,@portas,@cambio,@carroceria,@cor
                                       ,@combustivel,@preco,@statusDePublicacao
                                       ,@opcionais)
                            ";
                var parametrosAnuncio = new
                {
                    anuncioId = agregado.Id.ToString(),
                    anuncianteId = agregado.AnuncianteId.Id.ToString(),
                    dataDePublicacao = agregado.DataDePublicacao,
                    periodoInicio = agregado.Vigencia.Inicial,
                    periodoFinal = agregado.Vigencia.Inicial
                };

                var parametrosVeiculo = new
                {
                    veiculoId = agregado.Id.ToString(),
                    marca = agregado.Veiculo.DetalheDeFabricacao.Marca,
                    anoFabricacao = agregado.Veiculo.DetalheDeFabricacao.AnoFabricacao,
                    modelo = agregado.Veiculo.DetalheDeFabricacao.Modelo,
                    anoModelo = agregado.Veiculo.DetalheDeFabricacao.AnoModelo,
                    placa = agregado.Veiculo.Detalhe.Placa,
                    kilometragem = agregado.Veiculo.Detalhe.Kilometragem,
                    portas = agregado.Veiculo.Detalhe.Portas,
                    cambio = agregado.Veiculo.Detalhe.Cambio.DisplayName,
                    carroceria = agregado.Veiculo.Detalhe.Carroceria.DisplayName,
                    cor = agregado.Veiculo.Detalhe.Cor.DisplayName,
                    combustivel = agregado.Veiculo.Detalhe.Combustivel.DisplayName,
                    preco = agregado.Veiculo.Detalhe.Preco,
                    statusDePublicacao = agregado.Veiculo.StatusDePublicacao.DisplayName,
                    opcionais = agregado.Veiculo.Opcionais.Itens
                };

                cn.Execute(insertAnuncio, parametrosAnuncio);
                cn.Execute(insertVeiculo, parametrosVeiculo);

                cn.Close();
            }
        }
    }
}
