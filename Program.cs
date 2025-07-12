using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Configuração da suíte, determinante para o lançamento da exceção e dos cálculos
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

Console.WriteLine("Bem-vindo ao sistema de hospedagem!");
Console.Write("Informe a quantidade de hóspedes para cadastrar: ");
int quantidadeHospedes = int.Parse(Console.ReadLine());

List<Pessoa> hospedes = new List<Pessoa>();

for (int i = 1; i <= quantidadeHospedes; i++)
{
    Console.Write($"Digite o nome do hóspede {i}: ");
    string nome = Console.ReadLine();
    hospedes.Add(new Pessoa(nome: nome));
}

// Cria uma nova reserva, passando a suíte e os hóspedes
Console.Clear();
Console.Write("Quantos dias deseja reservar? ");

Reserva reserva = new Reserva(diasReservados: int.Parse(Console.ReadLine()));
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine("Nomes dos hóspedes:");
Console.WriteLine(reserva.ObterNomesHospedes());
Console.WriteLine($"Valor da estadia: {reserva.CalcularValorEstadia().ToString("C", new System.Globalization.CultureInfo("pt-BR"))}");