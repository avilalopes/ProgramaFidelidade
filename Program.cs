using System;
using System.Collections.Generic;

namespace ProgramaFidelidade
{
	class Program
	{
		static List<Opcoes> listOpcoes = new List<Opcoes>();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Adicionar();
						break;
					case "4":
						Utilizar();
						break;
					case "5":
						Transferir();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Atividade realizada com sucesso.");			
		}
		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("         PROGRAMA FIDELIDADE LOCALIZA         ");
			Console.WriteLine();			
			Console.WriteLine(" ESCOLHA UMA OPÇÃO");
			Console.WriteLine();
			Console.WriteLine(" 1 - CONSULTAR LISTA DE CLIENTES FIDELIZADOS");
			Console.WriteLine(" 2 - CADASTRAR CLIENTE NO PROGRAMA FIDELIDADE");
			Console.WriteLine(" 3 - ADICIONAR PONTOS");
			Console.WriteLine(" 4 - UTILIZAR PONTOS");
			Console.WriteLine(" 5 - TRANSFERIR PONTOS");
			Console.WriteLine(" X - SAIR");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		private static void ListarContas()
		{
			if (listOpcoes.Count == 0)
			{
				Console.WriteLine("Nenhum cliente cadastrado.");
				return;
			}
            Console.Write(" CLIENTES FIDELIZADOS");
    		Console.WriteLine(); 
			for (int i = 0 ; i < listOpcoes.Count; i++)
			{                
				Opcoes opcoes = listOpcoes[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(opcoes);
			}
		}
		private static void InserirConta()
		{
			Console.WriteLine(" 2 - CADASTRAR CLIENTE NO PROGRAMA FIDELIDADE");
 			Console.WriteLine();  
			Console.Write("Esta é a primeira locação do cliente? Digite 1 para Sim ou 2 Não: ");
			int entradalocacao = int.Parse(Console.ReadLine());
 			Console.WriteLine();  
			Console.Write("Informe o Nome Completo do Cliente: ");
			string entradaNome = Console.ReadLine();
 			Console.WriteLine();  
			Console.Write("Digite o saldo de pontos que o cliente está recebendo com essa locação de carro: ");
			double entradapontuacao = double.Parse(Console.ReadLine());

			Opcoes novaConta = new Opcoes(locacao: (Locacao)entradalocacao,
										pontuacao: entradapontuacao,
										nome: entradaNome);

			listOpcoes.Add(novaConta);
 			Console.WriteLine();  
 			Console.Write("Cliente cadastrado(a) com sucesso!");  
 			Console.WriteLine();                        
		}
		private static void Adicionar()
		{
			{
                if (listOpcoes.Count == 0)
                {
                    Console.WriteLine("Nenhum cliente cadastrado.");
                    Console.WriteLine("Os clientes devem ser cadastrados na opção 2 do menu inicial.");                    
                    return;
                }
                Console.Write(" CLIENTES FIDELIZADOS");
                Console.WriteLine(); 
                for (int i = 0; i < listOpcoes.Count; i++)
                {

                    Opcoes opcoes = listOpcoes[i];
					Console.Write("#{0} - ", i);
                    Console.WriteLine(opcoes);
				}
                Console.WriteLine(); 				
				Console.WriteLine(" 3 - ADICIONAR PONTOS");
                Console.WriteLine(); 								 				
				Console.Write("Escolha um número de cliente da lista: #");
				int indiceConta = int.Parse(Console.ReadLine());
				Console.WriteLine(); 
				Console.Write("Informe a pontuação que deverá ser adicionada: ");
				double valorAdicionado = double.Parse(Console.ReadLine());
				listOpcoes[indiceConta].Adicionar(valorAdicionado);            						
			}
        }
		private static void Utilizar()
		{
            if (listOpcoes.Count == 0)
                {
                    Console.WriteLine("Nenhum cliente cadastrado.");
                    Console.WriteLine("Os clientes devem ser cadastrados na opção 2 do menu inicial.");                    
                    return;
                }
                Console.Write(" CLIENTES FIDELIZADOS");
 			    Console.WriteLine();                
                for (int i = 0; i < listOpcoes.Count; i++)
                {
                    Opcoes opcoes = listOpcoes[i];
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(opcoes);
                }             
			Console.WriteLine();
            Console.WriteLine(" 4 - UTILIZAR PONTOS");			
            Console.WriteLine(); 			
            Console.Write("Escolha um número de cliente da lista: #");
			int indiceConta = int.Parse(Console.ReadLine());
			Console.WriteLine();
			Console.Write("Informe a pontuação que será utilizada para essa locação: ");
			double valorUtilizado = double.Parse(Console.ReadLine());
            listOpcoes[indiceConta].Utilizar(valorUtilizado);
		}
		private static void Transferir()
		{
                if (listOpcoes.Count == 0)
                {
                    Console.WriteLine("Nenhum cliente cadastrado.");
                    Console.WriteLine("Os clientes devem ser cadastrados na opção 2 do menu inicial.");                    
                    return;
                }
                
                Console.Write(" CLIENTES FIDELIZADOS");
 			    Console.WriteLine();                 
                for (int i = 0; i < listOpcoes.Count; i++)
                {
                    Opcoes opcoes = listOpcoes[i];
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(opcoes);
                }
 			Console.WriteLine(); 
			Console.WriteLine(" 5 - TRANSFERIR PONTOS");
            Console.WriteLine(); 						                           
			Console.Write("Informe o número do cliente que irá transferir a pontuação: ");
			int indiceClienteOrigem = int.Parse(Console.ReadLine());
			Console.WriteLine();
            Console.Write("Informe o número do cliente que irá receber a pontuação: ");
			int indiceClienteReceptor = int.Parse(Console.ReadLine());
			Console.WriteLine();
			Console.Write("Informe a pontuação que será transferida: ");
			double valorTransferencia = double.Parse(Console.ReadLine());
            listOpcoes[indiceClienteOrigem].Transferir(valorTransferencia, listOpcoes[indiceClienteReceptor]);         
		}
	}
}