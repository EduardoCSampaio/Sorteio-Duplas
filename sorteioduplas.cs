using System;
using System.Threading;

namespace SorteioNãoRepitido
{
    class Program
    {
        static void Main(string[] args)
        {
            Random geranum = new Random();
            string lista, vNome;
            int m, i;

            Console.SetCursorPosition(30, 4);
            Console.Write("Quantas pessoas vão participar: ");
            m = int.Parse(Console.ReadLine());
            string[] numeros = new string[m];
            string num;
            Console.Clear();

            if (m % 2 != 1)
            {
                int h;
                h = 0;
                for (int p = 0; p < m; p++)
                {
                   
                    Console.SetCursorPosition(30, 7 + p);
                    Console.Write($"Informe o {p + 1} nome: ");
                    num = Console.ReadLine();
                    numeros[p] = num;
                    Console.Clear();
                    
                    if (h >= 1)
                    {
                        
                        if (jaExiste(num, numeros, p-1))
                        {
                            Console.SetCursorPosition(30, 9 + p);
                            Console.WriteLine("Nome já existente");
                            Console.SetCursorPosition(30, 10 + p);
                            Console.WriteLine("Digite outro nome");
                            p--;
                        }
                        else
                        {
                           
                        }
                    }
                    else
                    {
                        h = 1;
                    }

                }

                int vQtdNomes = numeros.Length;
                string[] Sorteado = new string[vQtdNomes];
                string Numeros_Sorteados = "";

                int l, n;

                for (l = 0; l < vQtdNomes; l++)
                {
                    n = geranum.Next(0, vQtdNomes);
                    if (!Numeros_Sorteados.Contains(n.ToString()))
                    {
                        Sorteado[l] = numeros[n];
                        Numeros_Sorteados += n + "~";
                    }
                    else
                    {
                        l--;
                    }
                }

                int Duplas = ((Sorteado.Length) / 2);
                int d;
                d = 1;
                for (i = 0; i < (vQtdNomes); i++)
                {

                    Console.SetCursorPosition(30, 3 + i);
                    Thread.Sleep(1000);
                    Console.WriteLine($"Dupla {d++}: {Sorteado[i]} e {Sorteado[i + 1]}");
                    i++;

                }
            }
            else
            {
                Console.SetCursorPosition(30, 7);
                Console.WriteLine("Impóssivel fazer sorteio de duplas. Informe um valor Par");
            }
        }
        static bool jaExiste(string vTexto, string[] vetor, int vezes)
        {
            bool tem = false;
            for (int f = 0; f <= vezes; f++)
            {
                if (vTexto == vetor[f])
                {
                    tem = true;
                }
            }
            return tem;
        }
    }
}

