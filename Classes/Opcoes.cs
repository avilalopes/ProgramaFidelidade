using System;

namespace ProgramaFidelidade
{
	public class Opcoes
	{
		private Locacao locacao { get; set; }
		private double pontuacao { get; set; }
		private string Nome { get; set; }
		private int indiceConta { get; set; }
		public Opcoes(Locacao locacao, double pontuacao, string nome)
		{
			this.locacao = locacao;
			this.pontuacao = pontuacao;
			this.Nome = nome;
			this.indiceConta = indiceConta;
		}
		public void Adicionar(double valorAdicionado)
		{
			this.pontuacao += valorAdicionado;
			Console.WriteLine(); 
            Console.WriteLine("A pontuação atual da conta {0} é {1}.", this.indiceConta, this.pontuacao);
			Console.WriteLine();
			Console.Write("Pontuação adicionada com sucesso!");
			Console.WriteLine();      			             
		}
		public bool Utilizar(double valorUtilizado)
		{
            if (this.pontuacao < valorUtilizado)
			{
            	Console.WriteLine();				
                Console.WriteLine("Infelizmente a pontuação é insuficiente.");
                return false;
            }
			this.pontuacao -= valorUtilizado;
			Console.WriteLine(); 
            Console.WriteLine("Pontuação atual da conta de {0} é {1}.", this.indiceConta, this.pontuacao);
			Console.WriteLine(); 
            Console.Write("Pontuação deduzida com sucesso!");
            Console.WriteLine();			
            return true;
		}
		public void Transferir(double valorTransferencia, Opcoes clienteReceptor)
		{
			if (this.Utilizar(valorTransferencia)){
                clienteReceptor.Adicionar(valorTransferencia);
				Console.WriteLine(); 				
				Console.Write("Transferência concluida com sucesso!");
				Console.WriteLine();   				
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Primeira Locação: " + this.locacao + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo de Pontos: " + this.pontuacao;
			return retorno;
		} 
	}
}