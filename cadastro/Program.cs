using System;

namespace cadastro
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
            System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Dígite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrção da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo,
            ano: entradaAno, descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        public static void ListarSeries()
        {
            System.Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma Série Cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                System.Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }

        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
            titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Insere(novaSerie);            
        }
         
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Rod Plataforma ao seu Dispor!");
            System.Console.WriteLine("Informe a Opção Desejada:");

            System.Console.WriteLine("1 - Listar Séries");
            System.Console.WriteLine("2 - Inserir Nova Série");
            System.Console.WriteLine("3 - Atualziar Série");
            System.Console.WriteLine("4 - Excluir Série");
            System.Console.WriteLine("5 - Visualizar Série");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}