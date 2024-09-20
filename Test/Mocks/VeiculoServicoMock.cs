using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace Test.Mocks
{
    public class VeiculoServicoMock : IVeiculoServico
    {
        private static List<Veiculo> veiculos = new List<Veiculo>(){
            new Veiculo{
                Id = 1,
                Nome = "Uno",
                Marca = "Fiat",
                Ano = 1995
            },
            new Veiculo{
                Id = 2,
                Nome = "Gol",
                Marca = "Volkswagen",
                Ano = 2014
            }
        };

        public void Apagar(Veiculo veiculo)
        {
            veiculos.Remove(veiculo);
        }

        public void Atualizar(Veiculo veiculo)
        {
            foreach (var vcl in veiculos)
            {
                if (vcl.Id == veiculo.Id)
                {
                    vcl.Nome = veiculo.Nome;
                    vcl.Marca = veiculo.Marca;
                    vcl.Ano = veiculo.Ano;
                }
            }
        }

        public Veiculo? BuscaPorId(int id)
        {
            return veiculos.Find(a => a.Id == id);
        }

        public void Incluir(Veiculo veiculo)
        {
            veiculo.Id = veiculos.Count() + 1;
            veiculos.Add(veiculo);
        }

        public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
        {
            return veiculos;
        }
    }
}