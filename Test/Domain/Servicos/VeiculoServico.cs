﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
using System.Reflection;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class VeiculoServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarVeiculo()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

            var veiculo = new Veiculo();
            veiculo.Nome = "Uno";
            veiculo.Marca = "Fiat";
            veiculo.Ano = 1995;

            var veiculoServico = new VeiculoServico(context);

            // Act
            veiculoServico.Incluir(veiculo);

            // Assert
            Assert.AreEqual(1, veiculoServico.Todos(1).Count());
        }

        [TestMethod]
        public void TestandoBuscaPorId()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

            var veiculo = new Veiculo();
            veiculo.Nome = "Uno";
            veiculo.Marca = "Fiat";
            veiculo.Ano = 1995;

            var veiculoServico = new VeiculoServico(context);

            // Act
            veiculoServico.Incluir(veiculo);
            var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

            // Assert
            Assert.AreEqual(1, veiculoDoBanco?.Id);
        }
    }
}