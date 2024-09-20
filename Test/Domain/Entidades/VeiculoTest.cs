using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Id = 1;
            veiculo.Nome = "Ferrari Enzo";
            veiculo.Marca = "Ferrari";
            veiculo.Ano = 2014;

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Ferrari Enzo", veiculo.Nome);
            Assert.AreEqual("Ferrari", veiculo.Marca);
            Assert.AreEqual(2014, veiculo.Ano);
        }
    }
}