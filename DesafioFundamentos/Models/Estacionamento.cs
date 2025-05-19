using System.Configuration.Assemblies;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        private List<string> veiculos = [];

        private static string NormalizarPlaca(string placa)
        {
            if (placa.Contains(' '))
            {
                placa = placa.Replace(" ", "");
                return placa;
            }
            else
                return placa;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo que você quer estacionar:");
            string placaDoVeiculo = Console.ReadLine().ToUpper();
            string placaMercosul = @"^([a-z]{3}\d{1}[a-z]{1}\d{2}[a-z]{1})$";

            placaDoVeiculo = NormalizarPlaca(placaDoVeiculo);

            if (veiculos.Contains(placaDoVeiculo))
            {
                Console.WriteLine("Este veículo já foi cadastrado em nosso sistema.");
            }
            else if (
                Regex.IsMatch(placaDoVeiculo, placaMercosul, RegexOptions.IgnoreCase)
                && !veiculos.Contains(placaDoVeiculo)
            )
            {
                veiculos.Add(placaDoVeiculo);
                Console.WriteLine($"Veículo de placa {placaDoVeiculo} cadastrado com sucesso.");
            }
            else
            {
                Console.WriteLine(
                    "Desculpe, parece que esta não é uma placa Mercosul válida. Tente novamente."
                );
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placaDoVeiculo = Console.ReadLine().ToUpper();

            placaDoVeiculo = NormalizarPlaca(placaDoVeiculo);

            if (veiculos.Contains(placaDoVeiculo))
            {
                Console.WriteLine(
                    "Digite a quantidade de horas que o veículo permaneceu estacionado:"
                );

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int horas))
                {
                    Console.WriteLine(
                        "Por favor, use apenas números para informar a quantidade de horas que o veículo permaneceu estacionado:"
                    );
                }
                ;
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placaDoVeiculo);

                Console.WriteLine(
                    $"O veículo {placaDoVeiculo} foi removido e o preço total foi de: R$ {valorTotal}."
                );
            }
            else
            {
                Console.WriteLine(
                    "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente."
                );
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
