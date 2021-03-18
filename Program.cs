using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
            
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

        }

        private static void ExcluirSerie()
		{
            Console.Write("Excluir série");
            Console.WriteLine();
			Console.Write("Digite o id da série a ser excluída: ");
			int indiceSerie = int.Parse(Console.ReadLine());
            indiceSerie--;
			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
            Console.Write("Visualizar série");
            Console.WriteLine();
			Console.Write("Digite o id da série a ser visualizada: ");
			int indiceSerie = int.Parse(Console.ReadLine());
            indiceSerie--;
			var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine();
			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série a ser atualizada: ");
			int indiceSerie = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine();
            Console.WriteLine("Digite o gênero entre as opções abaixo: ");
            Console.WriteLine();
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Genero), i));
			}
			
			int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();
            Console.WriteLine();
			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();
			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
            Console.WriteLine();
			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("{0}. {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "(Excluída)" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            Console.WriteLine();
            Console.WriteLine("Digite o gênero entre as opções abaixo:");
            Console.WriteLine();
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(".NET Séries a seu dispor!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
