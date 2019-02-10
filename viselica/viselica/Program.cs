
using System;
using System.Threading;
namespace viselica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Загадайте слово");
            string input = Console.ReadLine();
            Viselica.EnterClass(input);
            //Console.ReadLine();
        }
        class Viselica
        {
            private static string SecretWorld;
            private static char[] Shifro;
            public static int Attempt;
            private static string ShifroString;
            public static void EnterClass(string input)
            {
                
                SecretWorld = input.ToLower();
                Attempt = 5;
                DoShifro();
            }
            static void DoShifro()
            {
                ShifroString = new string('*', SecretWorld.Length);
                Shifro=ShifroString.ToCharArray() ;
                //for (int counter=0;ShifroString.Length>counter;counter++)
                //{
                //    Shifro[counter] = ShifroString[counter];
                //    Console.WriteLine("whatafuck");
                //}
                //for(int counter=0;SecretWorld.Length>counter;counter++)
                //{
                //    Shifro[counter] = '*';
                //}
                DoDeshifro();
            }
            static void DoDeshifro()
            {
                Console.WriteLine("Отгадайте слово "+ShifroString+" \n У вас "+Attempt+" попыток");
                //start:
                Thread myThread = new Thread(ThreadHelper);
                myThread.Start();
                Thread checker = new Thread(Checker);
                checker.Start();
                string guess = Console.ReadLine();
                if (guess.Length>SecretWorld.Length)
                {
                    for (int counterFirst=0;counterFirst<SecretWorld.Length;counterFirst++)
                    {
                        Shifro[counterFirst] = guess[counterFirst];
                    }
                    //Console.Write("Вы ввели слово больше ,чем загаданное");
                    //goto start;
                }
                else if(guess.Length<SecretWorld.Length)
                {
                    //for ()
                    //{

                    //}
                            

                }
                for (int counter=0;guess.Length>counter;counter++)
                {
                    if (SecretWorld[counter]==guess[counter])
                    {
                        Shifro[counter] = SecretWorld[counter];
                        ShifroString = new string(Shifro);
                        //Console.WriteLine(ShifroString);
                        //ShifroString.Equals(string.Join("", Shifro));
                    }
                }
                Console.Clear();
                Attempt--;
                Check();                             
                DoDeshifro();                
            }
            static void Check()
            {
                
                if (SecretWorld==ShifroString)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вы отгадали слово "+ShifroString+" с"+Attempt+" попытки");
                    Console.ReadLine();
                }
            }
            

        }
        public static void ThreadHelper()
        {
            Thread.Sleep(15000);
            Console.WriteLine("Вы не уложились в 15 секунд");
            Viselica.Attempt--;

        }
        public static void Checker()
        {
            if (Viselica.Attempt==0)
            {
                Console.WriteLine("GAME OVER !");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
