using System;
using ordenacao.Colecoes;

namespace ordenacao
{
    class Program
    {
        static void Main(string[] args)
        {
            OperacoesArray op = new OperacoesArray();
            int[] array = new int[5] {8,2,4,12,5};

            System.Console.WriteLine("Array Original");
            op.ImprimirArray(array);

            op.OrdenarBubbleSort(ref array);

            System.Console.WriteLine("Array Ordenado");
            op.ImprimirArray(array);

        }
    }
}