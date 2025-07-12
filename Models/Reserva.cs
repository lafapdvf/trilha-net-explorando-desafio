namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Implementado
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Implementado
                throw new Exception($"A capacidade da suíte ({Suite.Capacidade}) não comporta a quantidade de hóspedes ({hospedes.Count}). Reserva não realizada.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Implementado
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            return 0;
        }

        public string ObterNomesHospedes()
        {
            if (Hospedes == null || Hospedes.Count == 0)
                return "Nenhum hóspede cadastrado.";

            return string.Join(Environment.NewLine, Hospedes.Select(h => h.NomeCompleto));
        }

        public decimal CalcularValorEstadia()
        {
            // Implementado
            decimal valor = 0;
            if (Suite != null)
            {
                valor = DiasReservados * Suite.ValorDiaria;
            }

            // Implementado
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.1m; // Aplicando 10% de desconto
            }
            else if (DiasReservados <= 0)
            {
                valor = 0;
            }

            return valor;
        }
    }
}