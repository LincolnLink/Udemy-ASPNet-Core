using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var v1 = 5;
            var v2 = 25;
            var total = v1 + v2;

            //var teste1 = false;
            //var teste2 = true;

            //Console.WriteLine(teste1 && !teste2);
            //Console.WriteLine("valor é: "+ total);

            /*Operadores relacionais*/

            /*Repetição*/
            //For
            //while
            /*int x = 0;
            while(x < 10)
            {
                x++;
                Console.WriteLine(x);
                if (x == 7)
                    break;

            }*/

            int x = 2;
            switch(x)
            {
                case 1:
                    Console.WriteLine("igual a 1");
                    break;
                case 2:
                    Console.WriteLine("igual a 2");
                    break;
                case 3:
                    Console.WriteLine("igual a 3");
                    break;
                default:
                    Console.WriteLine("valor padrão");
                    break;
            }


            // Console.ReadLine();
        }
    }
}
