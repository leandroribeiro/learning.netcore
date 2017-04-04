using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace very_simple_01
{
    //http://cgoncalves.com/blog/como-e-quando-usar-o-parallel-foreach-em-vez-foreach/

    class Program
    {
        static void Main(string[] args)
        {
            string[] cores = {
                "Rosa",
                    "Laranja",
                    "Castanho",
                    "Amarelo",
                    "Preto",
                    "Branco",
                    "Cinza",
                    "Azul",
                    "Verde",
                    "Vermelho"
            };
            
            Console.WriteLine("loop foreach \n");
            var sw = Stopwatch.StartNew();
            foreach(string cor in cores) {
                Console.WriteLine("{0}, Thread Id= {1}", cor, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
            Console.WriteLine("loop foreach tempo de execução = {0} segundos\n", sw.Elapsed.TotalSeconds);
            
            Console.WriteLine("Parallel.ForEach");
            sw = Stopwatch.StartNew();
            Parallel.ForEach(cores, cor => {
                Console.WriteLine("{0}, Thread Id= {1}", cor, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
            Console.WriteLine("Parallel.ForEach() tempo de execução = {0} segundos", sw.Elapsed.TotalSeconds);

            Console.Read();
        }
    }
}
