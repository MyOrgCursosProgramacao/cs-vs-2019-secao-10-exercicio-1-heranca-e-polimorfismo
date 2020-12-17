using src.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solução do primeiro exercício proposto da seção 10");
            Console.WriteLine("Entre com os dados dos produtos");
            Console.WriteLine();

            List<Product> listaDeProdutos = new List<Product>();

            bool loop = true;
            while (loop)
            {
                int itemCount = 0;

                if (listaDeProdutos.Count > 0)
                {
                    Console.WriteLine(Environment.NewLine + "Lista de produtos cadastrados");

                    int listCount = 0;
                    foreach (Product obj in listaDeProdutos)
                    {
                        listCount++;
                        Console.WriteLine($"{listCount}: " + obj.PriceTag());
                    }
                    itemCount = listCount;
                }

                Console.Write(Environment.NewLine + "Deseja cadastrar algum item (s/n)? ");
                char resposta = char.Parse(Console.ReadLine());
                if (resposta == 'n' || resposta == 'N')
                {
                    Console.WriteLine("Sair");
                    loop = false;
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + $"Dados do item #{itemCount + 1}:");
                    Console.Write("Comum, usado ou importado (c/u/i): ");
                    string tipoResposta = Console.ReadLine().Trim().ToLower();
                    char tipoSwitch = tipoResposta[0];

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Preço: $ ");
                    double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    switch (tipoSwitch)
                    {
                        case 'c':
                            listaDeProdutos.Add(new Product(nome, preco));
                            break;
                        case 'u':
                            Console.Write("Data de fabricação (dd/mm/aaaa): ");
                            string dataDeFabricacao = Console.ReadLine().Trim();
                            bool loopData = true;
                            do
                            {
                                if (String.IsNullOrEmpty(dataDeFabricacao) || dataDeFabricacao.Length != 10
                                    || !dataDeFabricacao.Contains('/') || dataDeFabricacao.Contains('.')
                                    || dataDeFabricacao.Contains('-') || String.IsNullOrWhiteSpace(dataDeFabricacao))
                                {
                                    Console.Write(Environment.NewLine
                                        + "A data de fabricação deve ter um formato válido dd/mm/aaaa."
                                        + Environment.NewLine
                                        + "Digite a data de fabricação: ");
                                    dataDeFabricacao = Console.ReadLine().Trim();
                                }
                                else if (int.Parse(dataDeFabricacao.Substring(6, 4)) > DateTime.Now.Year)
                                {
                                    Console.Write(Environment.NewLine
                                        + $"O ano deve ser anterior a {DateTime.Now.Year}."
                                        + Environment.NewLine
                                        + "Digite a data de fabricação: ");
                                    dataDeFabricacao = Console.ReadLine().Trim(); ;
                                }
                                else
                                {
                                    loopData = false;
                                }
                            } while (loopData);

                            listaDeProdutos.Add(new UsedProduct(nome, preco, DateTime.Parse(dataDeFabricacao)));
                            break;
                        case 'i':
                            Console.Write("Taxa aduaneira: $ ");
                            double taxaAduaneira = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            listaDeProdutos.Add(new ImportedProduct(nome, preco, taxaAduaneira));
                            break;
                        default:
                            Console.WriteLine("Tipo de item não existente");
                            break;
                    }
                }
            }
        }
    }
}
