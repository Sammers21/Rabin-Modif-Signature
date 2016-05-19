using System;
using RabinLib;
using System.Numerics;

namespace RabinTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введиет тестиремый реджим \n" +
                "1- обычная демонстрация\n" +
                "2- подпись Рабина\n" +
                "3- модифицированная подпись Рабина\n");
                Console.ForegroundColor = ConsoleColor.Green;

                string Answer = Console.ReadLine();

                switch (Answer)
                {
                    case "1":
                        {

                            Console.Clear();

                            BigInteger p = 3004913, q = 20979403, n = p * q;


                            Console.WriteLine("В данном случае используются p={0}\tq={1}", p, q);

                            Console.WriteLine("Ведите текст для зашифровки\n");
                            string text = Console.ReadLine();
                            Console.WriteLine("\n");
                            try
                            {
                                BigInteger[] arr = Rabin.EncryptionBigText(text, n);

                                Console.WriteLine("\nBigInt Зашифрованное представление Массив :\n\n");
                                foreach (BigInteger b in arr)
                                {
                                    Console.WriteLine("\t " + b);
                                }
                                Console.WriteLine("\n");
                                string decrText = Rabin.DecryptionBigText(arr, p, q);


                                Console.WriteLine("\n\n\nПри расшивровке было получено сообдещие:\n\n"
                                     + decrText);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        break;
                    case "2":
                        {


                            Console.Clear();

                            Console.WriteLine("Ведите текст для зашифровки");

                            string text = Console.ReadLine();


                            BigInteger p = 3004913, q = 1109219;
                            BigInteger n = p * q;

                            Console.WriteLine("В данном случае используются p={0}\tq={1}", p, q);
                            try
                            {
                                Signature[] S = Rabin.RabinSignatureBigtext(text, p, q);

                                Console.WriteLine("\n");
                                foreach (Signature numTe in S)
                                    Console.WriteLine("Подпись S={0},I={1}", numTe.S, numTe.I);
                                Console.WriteLine("\n");
                                bool[] truestor;
                                string dec = Rabin.DecryptionWithVertifBigText(S, n, out truestor);

                                Console.WriteLine(dec);
                                Console.WriteLine("\n");
                                
                                foreach(Boolean b in truestor)
                                    Console.WriteLine(b);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        break;

                    case "3":
                        {

                            Console.Clear();
                            Console.WriteLine("Ведиет текст для зашифровки");
                            string Text = Console.ReadLine();
                            try
                            {
                                BigInteger p = 3795059, q = 3795007, n = q * p, SEcret = Rabin.CalcOfSecretKey(p, q);

                                Console.WriteLine("Отрытый ключ n={0}  Secret key={1}", n, SEcret);

                                BigInteger Sign = Rabin.ModifCalcSignatyre(Text, n, SEcret);
                                Console.WriteLine("Подпись S= " + Sign);

                                bool ans;
                                string result = Rabin.DecryptSign(Sign, n, out ans);
                                Console.WriteLine("Результат расшифровки " + result);
                                Console.WriteLine("Подпись имеет значе " + ans);

                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine(e.Message);
                                Console.WriteLine("\n Не забыайте что ключи должны быть дотстаточно большими");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Не корректный ввод, попробуйте еще раз");
                        break;
                }
                Console.WriteLine("\n\nдля выхода нажимте Esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);



        }
    }

}