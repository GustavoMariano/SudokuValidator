using System;

namespace Sudoku.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string sudoku =
           "1 3 2 5 7 9 4 6 8 " +
           "4 9 8 2 6 1 3 7 5 " +
           "7 5 6 3 8 4 2 1 9 " +
           "6 4 3 1 5 8 7 9 2 " +
           "5 2 1 7 9 3 8 4 6 " +
           "9 8 7 4 2 6 5 3 1 " +
           "2 1 4 9 3 5 6 8 7 " +
           "3 6 5 8 1 7 9 2 4 " +
           "8 7 9 6 4 2 1 5 3";

            int cont = 0;
            string[] semEspaco = new string[9];
            semEspaco = sudoku.Split(' ');
            string[] linha = new string[9];
            string[] coluna = new string[9];
            string[] bloco = new string[81];

            cont = 0;
            //Linhas
            cont = SeparaLinhas(cont, semEspaco, linha);

            cont = 0;
            //Colunas
            cont = SeparaColunas(cont, semEspaco, coluna);

            cont = 0;
            //Blocos
            cont = SeparaBlocos(cont, semEspaco, bloco);

            int soma = 45;

            Validacao(ref cont, linha, ref soma);

            Validacao(ref cont, coluna, ref soma);

            Validacao(ref cont, bloco, ref soma);
            
            Console.WriteLine("Sim");            

        }

        private static void Validacao(ref int cont, string[] sequencia, ref int soma)
        {
            for (int i = 0; i < 9; i++)
            {
                EhDiferenteDe45(soma);

                soma = 0;

                cont = 0;

                string[] numeros = sequencia[i].Split(' ');

                for (int c = 0; c < 9; c++)
                {
                    soma += Convert.ToInt32(numeros[c]);
                    if (numeros[i] == numeros[c])
                    {
                        cont++;
                    }
                    if (cont > 1)
                    {
                        Console.WriteLine("Não");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void EhDiferenteDe45(int soma)
        {
            if (soma != 45)
            {
                Console.WriteLine("Não");

                Console.ReadLine();

                Environment.Exit(0);
            }
        }

        private static int SeparaBlocos(int cont, string[] semEspaco, string[] bloco)
        {
            for (int i = 0; i < 3; i++)
            {
                bloco[i] = semEspaco[0 + cont] + " " + semEspaco[1 + cont] + " " + semEspaco[2 + cont] + " " + semEspaco[9 + cont] + " " + semEspaco[10 + cont] + " " + semEspaco[11 + cont] + " " + semEspaco[18 + cont] + " " + semEspaco[19 + cont] + " " + semEspaco[20 + cont];

                bloco[i + 3] = semEspaco[27 + cont] + " " + semEspaco[28 + cont] + " " + semEspaco[29 + cont] + " " + semEspaco[36 + cont] + " " + semEspaco[37 + cont] + " " + semEspaco[38 + cont] + " " + semEspaco[45 + cont] + " " + semEspaco[46 + cont] + " " + semEspaco[47 + cont];

                bloco[i + 6] = semEspaco[54 + cont] + " " + semEspaco[55 + cont] + " " + semEspaco[56 + cont] + " " + semEspaco[63 + cont] + " " + semEspaco[64 + cont] + " " + semEspaco[65 + cont] + " " + semEspaco[72 + cont] + " " + semEspaco[73 + cont] + " " + semEspaco[74 + cont];

                cont += 3;
            }

            return cont;
        }

        private static int SeparaLinhas(int cont, string[] semEspaco, string[] linha)
        {
            for (int i = 0; i < 9; i++)
            {
                linha[i] = semEspaco[0 + cont] + " " + semEspaco[1 + cont] + " " + semEspaco[2 + cont] + " " + semEspaco[3 + cont] + " " + semEspaco[4 + cont] + " " + semEspaco[5 + cont] + " " + semEspaco[6 + cont] + " " + semEspaco[7 + cont] + " " + semEspaco[8 + cont];

                cont += 9;

            }

            return cont;
        }

        private static int SeparaColunas(int cont, string[] semEspaco, string[] coluna)
        {
            for (int i = 0; i < 9; i++)
            {
                coluna[i] = semEspaco[0 + cont] + " " + semEspaco[9 + cont] + " " + semEspaco[18 + cont] + " " + semEspaco[27 + cont] + " " + semEspaco[36 + cont] + " " + semEspaco[45 + cont] + " " + semEspaco[54 + cont] + " " + semEspaco[63 + cont] + " " + semEspaco[72 + cont];

                cont++;
            }

            return cont;
        }
    }
}
