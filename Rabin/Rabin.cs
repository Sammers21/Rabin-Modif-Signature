using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
namespace RabinLib
{
    //делегат использующийся в коде
    delegate bool SignatyreVert(BigInteger key);

    public static class Rabin
    {
        /// <summary>
        /// переменная для полуения случайных чисел
        /// </summary>
        static Random rnd = new Random();

        #region Methods for Big text Rabin Classic System

        /// <summary>
        /// Метод для шифровки большого текста
        /// </summary>
        /// <param name="text">Текс</param>
        /// <param name="OpenyKey">Открытый ключ</param>
        /// <returns>Массив зашиврованных чисел</returns>
        public static BigInteger[] EncryptionBigText(string text, BigInteger OpenyKey)
        {
            int size = (int)CalcylateByteSize(OpenyKey);

            byte[] textUTF8 = Encoding.UTF8.GetBytes(text);

            int cycleCount = (textUTF8.Length / size) + (textUTF8.Length % size == 0 ? 0 : 1);
            bool falgOK = cycleCount == (textUTF8.Length / size);

            BigInteger[] result = new BigInteger[cycleCount];

            int iteratoR = 0;

            for (int i = 0; i < cycleCount; i++)
            {
                result[i] = 0;

                int siZE = i == cycleCount - 1 ? falgOK ? size : (textUTF8.Length % size) : size;


                BigInteger pow2 = 1;

                for (int j = 0; j < siZE; j++)
                {
                    result[i] += textUTF8[iteratoR++] * pow2;
                    pow2 *= 256;
                }

                result[i] = MX(result[i]);
                result[i] = BigInteger.ModPow(result[i], 2, OpenyKey);

            }

            return result;
        }
        /// <summary>
        /// Расшифровка большого текста
        /// </summary>
        /// <param name="Text">зашифрованное представление текста</param>
        /// <param name="q">один из закрытых ключей</param>
        /// <param name="p">один из закрытых ключей</param>
        /// <returns>Расшифрованный текст</returns>
        public static string DecryptionBigText(BigInteger[] Text, BigInteger q, BigInteger p)
        {

            List<byte> bytelist = new List<byte>();

            foreach (BigInteger b in Text)
            {

                byte[] cur = DecryptionBytes(b, q, p);

                foreach (byte by in cur)
                {
                    bytelist.Add(by);
                }
            }
            return Encoding.UTF8.GetString(bytelist.ToArray());
        }

        /// <summary>
        /// Рассчет размера блока байт для ключа использующегося в шифровании
        /// </summary>
        /// <param name="Openkey">Открытый ключ</param>
        /// <returns>Размер максимального блока для шифрования</returns>
        public static BigInteger CalcylateByteSize(BigInteger Openkey)
        {
            BigInteger x = 256, bytecount = 1;

            string xi = Openkey + "";

            int lastOpKey = int.Parse(xi[xi.Length - 1] + "" + xi[(xi).Length - 2]);

            while (Openkey > (x * 100 + lastOpKey))
            {
                x *= 256;
                bytecount++;
            }
            bytecount--;

            if (bytecount <= 1)
                throw new Exception("слишком маленький открытый ключ");

            return bytecount;


        }
        #endregion

        #region Rabin Classic System
        //Криптосистема Рабина
        //page 156
        //
        /// <summary>
        /// Шифрование по обычной схеме Рабина
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        /// <param name="OpenKey">Открытый ключ</param>
        /// <returns>Число представлющее текст</returns>
        public static BigInteger Encryption(string text, BigInteger OpenKey)
        {
            BigInteger result = ConvToBigIntWithBit(text);


            result = MX(result);




            if (result > OpenKey)
                throw new Exception("Слишком большое сообщение");

            BigInteger C = BigInteger.ModPow(result, 2, OpenKey);




            return C;

        }

        /// <summary>
        /// Деширование
        /// </summary>
        /// <param name="TextC">Зашифрованный текст</param>
        /// <param name="q">Простое число q. Один из закрытых ключей</param>
        /// <param name="p">Простое число p. Один из закрытых ключей</param>
        /// <returns>Расшифрованный текст</returns>
        public static string Decryption(BigInteger TextC, BigInteger q, BigInteger p)
        {

            if (!(Miller_Rabin_Test(q) && Miller_Rabin_Test(p)))
                throw new Exception("Один из ключей не простой");

            BigInteger r, _r;

            BigInteger s, _s;

            BigInteger n = p * q;
            //step 1
            Get_Sqare(out r, out _r, p, TextC);
            //step 2
            Get_Sqare(out s, out _s, q, TextC);

            //step 3
            BigInteger D, c, d;
            do
            {
                ShareAlgoryeOfEyclid(out D, out c, out d, p, q);
            } while (D != 1);

            BigInteger x = BigInteger.ModPow((r * d * q + s * c * p), 1, n);
            while (x < 0)
                x += n;
            BigInteger minusX = n - x;
            BigInteger y = BigInteger.ModPow((r * d * q - s * c * p), 1, n);
            while (y < 0)
                y += n;
            BigInteger minusY = n - y;



            List<string> roots = new List<string>() {x.ToString(),minusX.ToString(),
         y.ToString(),minusY.ToString()};

            List<string> Analized = Analyze(roots);


            BigInteger message = BigInteger.Parse(Analized[0]);

            message /= 100;


            return (ConvToStringWithBit(message));

        }/// <summary>
         /// Деширование
         /// </summary>
         /// <param name="TextC">Зашифрованный текст</param>
         /// <param name="q">Простое число q. Один из закрытых ключей</param>
         /// <param name="p">Простое число p. Один из закрытых ключей</param>
         /// <returns>Расшифрованный текст</returns>
        public static byte[] DecryptionBytes(BigInteger TextC, BigInteger q, BigInteger p)
        {

            if (!(Miller_Rabin_Test(q) && Miller_Rabin_Test(p)))
                throw new Exception("Один из ключей не простой");

            BigInteger r, _r;
            BigInteger s, _s;

            BigInteger n = p * q;
            //step 1
            Get_Sqare(out r, out _r, p, TextC);
            //step 2
            Get_Sqare(out s, out _s, q, TextC);

            //step 3
            BigInteger D, c, d;

            do
            {
                ShareAlgoryeOfEyclid(out D, out c, out d, p, q);
            } while (D != 1);

            BigInteger x = BigInteger.ModPow((r * d * q + s * c * p), 1, n);
            while (x < 0)
                x += n;
            BigInteger minusX = n - x;
            BigInteger y = BigInteger.ModPow((r * d * q - s * c * p), 1, n);
            while (y < 0)
                y += n;
            BigInteger minusY = n - y;




            List<string> roots = new List<string>() {x.ToString(),minusX.ToString(),
         y.ToString(),minusY.ToString()};

            List<string> Analized = Analyze(roots);



            BigInteger message = BigInteger.Parse(Analized[0]);

            message /= 100;

            return (ConvToBitFromBigInteger(message));

        }

        #endregion

        #region Methods for Big text Rabin Signature System
        /// <summary>
        /// Метод для подписи большо теста
        /// </summary>
        /// <param name="text">Входящий текст</param>
        /// <param name="p">Один из факторов закрытого ключа</param>
        /// <param name="q">Один из факторов закрытого ключа</param>
        /// <returns>Массив подписей текста</returns>
        public static Signature[] RabinSignatureBigtext(string text, BigInteger p, BigInteger q)
        {
            BigInteger OpKey = p * q;

            byte[] textUTF8 = Encoding.UTF8.GetBytes(text);

            int size = (int)CalcylateByteSize(OpKey);

            int cycleCount = (textUTF8.Length / size) + (textUTF8.Length % size == 0 ? 0 : 1);
            bool falgOK = cycleCount == (textUTF8.Length / size);

            Signature[] res = new Signature[cycleCount];

            int iteratoR = 0;

            for (int i = 0; i < cycleCount; i++)
            {
                int siZE = i == cycleCount - 1 ? falgOK ? size : (textUTF8.Length % size) : size;

                List<byte> block = new List<byte>();

                for (int j = 0; j < siZE; j++)
                    block.Add(textUTF8[iteratoR++]);


                res[i] = RabinSignatyre(block.ToArray(), p, q);

            }

            return res;

        }
        /// <summary>
        /// Метод для проверки большого количества подписей
        /// </summary>
        /// <param name="sign">Массив подписей</param>
        /// <param name="OpenKey">открыттый ключ</param>
        /// <param name="TrueSign">Массив проверок подписей</param>
        /// <returns></returns>
        public static string DecryptionWithVertifBigText(Signature[] sign, BigInteger OpenKey, out bool[] TrueSign)
        {
            List<byte> resToDecode = new List<byte>();
            List<bool> TrueSignatures = new List<bool>();

            for (int i = 0; i < sign.Length; i++)
            {
                BigInteger M;

                TrueSignatures.Add(SignatyreVertif(sign[i].S, sign[i].I, OpenKey, out M));

                byte[] inh = ConvToBitFromBigInteger(M);
                foreach (byte b in inh)
                {
                    resToDecode.Add(b);
                }

            }
            TrueSign = TrueSignatures.ToArray();
            return Encoding.UTF8.GetString(resToDecode.ToArray());
          

        }

        #endregion

        #region Rabin Signatyre
        //Электронно цифровая подпись Рабина с Извлечением сообщения
        //page158 Nabebin A.A.




        /// <summary>
        /// Вычисление подписи
        /// </summary>
        /// <param name="text">Подписываемый текс</param>
        /// <param name="p">Однин из закрытых ключей</param>
        /// <param name="q">Одни из закрытых ключей</param>
        /// <param name="II">Получаемый сдвиг</param>
        /// <returns>Получаемая подпись</returns>
        public static Signature RabinSignatyre(string text, BigInteger p, BigInteger q)
        {

            if (!(Miller_Rabin_Test(q) && Miller_Rabin_Test(p)))
                throw new Exception("Один из ключей не простой");

            BigInteger OpenKey = p * q;

            BigInteger result = ConvToBigIntWithBit(text);

            result = MX(result);

            if (result > OpenKey)
                throw new Exception("Слишком большое сообщение");

            BigInteger s, II;

            funcR(result, p, q, out s, out II);

            return new Signature(s, II);

        }

        /// <summary>
        /// Вычисление подписи
        /// </summary>
        /// <param name="text">Подписываемый массив байт</param>
        /// <param name="p">Однин из закрытых ключей</param>
        /// <param name="q">Одни из закрытых ключей</param>
        /// <param name="II">Получаемый сдвиг</param>
        /// <returns>Получаемая подпись</returns>
        public static Signature RabinSignatyre(byte[] ByteArr, BigInteger p, BigInteger q)
        {

            if (!(Miller_Rabin_Test(q) && Miller_Rabin_Test(p)))
                throw new Exception("Один из ключей не простой");

            BigInteger OpenKey = p * q;

            BigInteger result = ConvToBigIntWithBit(ByteArr);

            result = MX(result);

            if (result > OpenKey)
                throw new Exception("Слишком большое сообщение");

            BigInteger s, II;

            funcR(result, p, q, out s, out II);

            return new Signature(s, II);

        }

        /// <summary>
        /// Проверка подписи с извлечением сообщения
        /// </summary>
        /// <param name="OpenKey">Открытый ключ</param>
        /// <param name="s">Подпись</param>
        /// <returns>Результат извлечения сообщения </returns>
        public static string DecryptionWithVertif(BigInteger OpenKey, Signature s, out bool TrueSignature)
        {
            return DecryptionWithVertif(OpenKey, s.S, s.I, out TrueSignature);
        }
        /// <summary>
        /// Проверка подписи с извлечением сообщения
        /// </summary>
        /// <param name="OpenKey">Открытый ключ</param>
        /// <param name="S">Подпись</param>
        /// <param name="I">Сдвиг</param>
        /// <returns>Результат извлечения сообщения </returns>
        public static string DecryptionWithVertif(BigInteger OpenKey, BigInteger S, BigInteger I, out bool TrueSignature)
        {
            BigInteger M;

            TrueSignature = SignatyreVertif(S, I, OpenKey, out M);

            return (ConvToStringWithBit(M));
        }

        /// <summary>
        /// Проверка подписи
        /// </summary>
        /// <param name="S">Подпись</param>
        /// <param name="I">Сдвиг</param>
        /// <param name="opKey">Открытый ключ</param>
        /// <param name="?"></param>
        /// <returns>True в случае удлевостворения подписи хеш-функции и false в обратном</returns>
        static bool SignatyreVertif(BigInteger S, BigInteger I, BigInteger opKey, out BigInteger M)
        {
            BigInteger w = BigInteger.ModPow(S, 2, opKey);

            BigInteger m = w - I;

            List<string> lst = new List<string>() { m.ToString() };

            List<string> analyzed = Analyze(lst);

            if (analyzed.Count == 1)
            {
                m /= 100;
                M = m;
                return true;
            }
            else
            {
                M = 0;
                return false;
            }
        }
        /// <summary>
        /// Вычисление сдвига и подписи
        /// </summary>
        /// <param name="m">Число для которого мы ищем ближешее имеющее квадратные вычеты</param>
        /// <param name="p">Один из закртых ключей</param>
        /// <param name="q">Один из закртых ключей</param>
        /// <param name="S">Вычесленная подпись</param>
        /// <param name="i">Сдвиг подписи</param>
        static void funcR(BigInteger m, BigInteger p, BigInteger q, out BigInteger S, out BigInteger i)
        {
            BigInteger k = 0, n = p * q;

            while (Jacobi(m + k, n) == -1 || Jacobi(m + k, p) == -1 || Jacobi(m + k, q) == -1)
            {
                k++;
            }

            m = m + k;

            BigInteger r, _r;
            BigInteger s, _s;
            //step 1


            Get_Sqare(out r, out _r, p, m);
            //step 2
            Get_Sqare(out s, out _s, q, m);


            BigInteger D, c, d;
            do
            {
                ShareAlgoryeOfEyclid(out D, out c, out d, p, q);
            } while (D != 1);

            BigInteger x = BigInteger.ModPow((r * d * q + s * c * p), 1, n);
            while (x < 0)
                x += n;
            S = x;
            i = k;
        }

        #endregion

        #region Rabin Modif Signatyre
        //Модифицированная цифровая подпись Рабина с извелением сообщения

        /// <summary>
        /// Вычисление закрытого ключа
        /// </summary>
        /// <param name="p">p эквивалентно 3 mod 8</param>
        /// <param name="q">q эквивалентно 7 mod 8</param>
        /// <returns>Закртый ключ</returns>
        public static BigInteger CalcOfSecretKey(BigInteger p, BigInteger q)
        {
            if (p % 8 == 3 && q % 8 == 7)
                return ((p * q - p - q + 5) / 8);
            else
                throw new Exception("Ошибка в Вычислении ключей");

        }

        /// <summary>
        /// Вычисление подписи
        /// </summary>
        /// <param name="st">Подписываемый текст</param>
        /// <param name="OpenKey">Открытый ключ</param>
        /// <param name="SecretKey">Закрытый ключ</param>
        /// <returns>Подпись S</returns>
        public static BigInteger ModifCalcSignatyre(string st, BigInteger OpenKey, BigInteger SecretKey)
        {
            //step 1 page 160
            BigInteger T = ConvToBigIntWithBit(st);

            if (T > ((OpenKey - 6) / 16))
                throw new Exception("не удалось вычислить подпись так как m=>(n-6)/16");
            //step 2
            BigInteger w = 16 * T + 6;
            //step 3
            BigInteger Jack = Jacobi(w, OpenKey);

            //step 4
            BigInteger S;

            if (Jack == 1)
                S = BigInteger.ModPow(w, SecretKey, OpenKey);

            else if (Jack == -1)
                S = BigInteger.ModPow((w / 2), SecretKey, OpenKey);

            else
                throw new Exception("Требуется факторизация числа n");

            return S;
        }

        /// <summary>
        /// Расшифровка и извелечение сообщения 
        /// </summary>
        /// <param name="S">Подпись</param>
        /// <param name="OpenKey">Открытый ключ</param>
        /// <param name="res">Подтвержедние подписи</param>
        /// <returns>Извлеченное сообщение</returns>
        public static string DecryptSign(BigInteger S, BigInteger OpenKey, out bool res)
        {
            BigInteger u = BigInteger.ModPow(S, 2, OpenKey), U = BigInteger.ModPow(u, 1, 8);


            BigInteger w;

            if (U == 6)
                w = u;

            else if (U == 3)
                w = 2 * u;

            else if (U == 7)
                w = OpenKey - u;

            else if (U == 2)
                w = 2 * (OpenKey - u);

            else
                throw new Exception("Ошибка в проверке подписи");


            SignatyreVert Vetif = delegate (BigInteger si)
              {
                  if ((si - 6) % 16 == 0)
                      return true;
                  else return false;
              };

            res = Vetif(w);

            if (res == false)
                throw new Exception("Подпись не принята");

            BigInteger m = (w - 6) / 16;

            return ConvToStringWithBit(m);
        }

        #endregion

        #region ConvertMethods

        /// <summary>
        /// Преобразование в число текста
        /// </summary>
        /// <param name="Text">текст</param>
        /// <returns>число</returns>
        static BigInteger ConvToBigIntWithBit(string Text)
        {


            byte[] data = Encoding.UTF8.GetBytes(Text);


            return ConvToBigIntWithBit(data);
        }

        static BigInteger ConvToBigIntWithBit(byte[] data)
        {

            BigInteger res = 0;

            for (int i = 0; i < data.Length; i++)
                res += data[i] * (BigInteger)Math.Pow(2, 8 * i);



            return res;
        }

        /// <summary>
        /// преобразует число в массив байт
        /// </summary>
        /// <param name="textnumb">Число</param>
        /// <returns>Массив байт</returns>
        static byte[] ConvToBitFromBigInteger(BigInteger textnumb)
        {

            byte[] data = new byte[0];


            for (int j = 0; textnumb != 0; j++)
            {

                byte numb = 0;

                for (int i = 0; i < 8; i++)
                {

                    if (textnumb != 0)
                    {
                        numb += (byte)((textnumb % 2) * (byte)Math.Pow(2, i));
                        textnumb /= 2;
                    }
                    else
                    {
                        Array.Resize(ref data, data.Length + 1);
                        data[data.Length - 1] = numb;

                        break;
                    }
                    if (i == 7)
                    {
                        Array.Resize(ref data, data.Length + 1);
                        data[data.Length - 1] = numb;
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// Метод преобразующий число в текст
        /// </summary>
        /// <param name="textnumb">Число</param>
        /// <returns>Текст</returns>
        public static string ConvToStringWithBit(BigInteger textnumb)
        {


            byte[] data = ConvToBitFromBigInteger(textnumb);

            string result = Encoding.UTF8.GetString(data);

            return result;
        }



        #endregion

        #region CoreMethods




        /// <summary>
        /// Анализирует удлевотворяет ли сообщение хеш функции
        /// </summary>
        /// <param name="sqares">квадратные вычеты</param>
        /// <returns>Список удвелотворяющей хеш функции строк</returns>
        static List<string> Analyze(List<string> sqares)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < sqares.Count; i++)
            {
                char c1 = sqares[i][sqares[i].Length - 1], c2 = sqares[i][sqares[i].Length - 3],
                    c3 = sqares[i][sqares[i].Length - 2], c4 = sqares[i][sqares[i].Length - 4];
                if (c1 == c2 && c3 == c4)
                {
                    result.Add(sqares[i]);
                }
            }
            /*  if (result.Count() == 1)
              { }
              else
                  throw new Exception("Не удалось однозначно установить часть исходного соощение");*/

            return result;

        }



        /// <summary>
        /// Выбор рандомного числа B
        /// </summary>
        /// <param name="p">модуль числа по которому мы вычисляем</param>
        /// <returns>Выбранное число </returns>
        static BigInteger ChooseRandB(BigInteger p)
        {
            BigInteger result;
            do
            {
                result = Rand(p);
                if (Jacobi(result, p) == -1)
                    return result;

            } while (true);
        }

        /// <summary>
        /// Шаг второй. Нахождение S и T
        /// </summary>
        /// <param name="P">Число </param>
        /// <param name="T">Конечный остаток</param>
        /// <param name="S">Степень двойки</param>
        static void Step2PowSumnT(BigInteger P, out BigInteger T, out BigInteger S)
        {
            BigInteger Pminus = P - 1;

            int Some2Pow = 0;

            do
            {
                if (Pminus % 2 == 0)
                {
                    Some2Pow++;
                    Pminus /= 2;
                }
                else
                {
                    T = Pminus;
                    S = Some2Pow;
                    return;
                }

            } while (true);

        }

        /// <summary>
        /// Сивол якоби
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns>Значение символа Якоби</returns>
        static int Jacobi(BigInteger a, BigInteger n)
        {
            BigInteger d, v, u;
            ShareAlgoryeOfEyclid(out d, out v, out u, a, n);
            if (d != 1)
                return 0;
            if (a < 0)     //1
                return (((n - 1) / 2) == 0 ? 1 : -1) * Jacobi(-a, n);

            if (a % 2 == 0)//2
            {
                return ((n * n - 1) / 8 % 2 == 0 ? 1 : -1) * Jacobi((a / 2), n);
            }

            if (a == 1)    //3
                return 1;

            if (a < n)     //4
                return ((((a - 1) / 2) * ((n - 1) / 2)) % 2 == 0 ? 1 : -1) * Jacobi(n, a);

            return Jacobi(a % n, n);//5

            throw new Exception("Encryption exception");
        }

        /// <summary>
        /// Нахождение обратного элемента
        /// </summary>
        /// <param name="a">Число обратный элемент которого мы ищем</param>
        /// <param name="n">Число по модулю которого идет вычисление обратного элемента</param>
        /// <returns>Обратный элемент</returns>
        static BigInteger FindA_1ModN(BigInteger a, BigInteger n)
        {
            BigInteger d, x, y;
            ShareAlgoryeOfEyclid(out d, out y, out x, n, a);

            if (d > 1)
                throw new Exception("Обратного элемента не существует");
            while (x < 0)
                x += n;
            return x;

        }

        /// <summary>
        /// Расширенный Алгоритм  Евклида.
        /// </summary>
        /// <param name="d"> d=НОД(a,b)</param>
        /// <param name="u">d=ua+vb</param>
        /// <param name="v">d=ua+vb</param>
        /// <param name="a">A>=B</param>
        /// <param name="b">A>=B</param>
        static void ShareAlgoryeOfEyclid(out BigInteger d, out BigInteger u, out BigInteger v, BigInteger a, BigInteger b)
        {
            if (b == 0)
            {
                d = a;
                u = 1;
                v = 0;
                return;
            }

            BigInteger u2 = 1, u1 = 0, v2 = 0, v1 = 1, q, r;

            while (b > 0)
            {
                q = a / b;
                r = a - q * b;
                u = u2 - q * u1;
                v = v2 - q * v1;
                a = b;
                b = r;
                u2 = u1;
                u1 = u;
                v2 = v1;
                v1 = v;
            }
            d = a;
            u = u2;
            v = v2;
        }

        /// <summary>
        /// проверка эквивалентно ли d=-1(mod p)
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        static bool Eq_1(BigInteger d, BigInteger p)
        {
            if (d + 1 == p)
                return true;
            else
                return false;
        }

        /// <summary>
        /// вычисление одноо из квадратных корней
        /// </summary>
        /// <param name="p"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        static BigInteger Get_Sqare1(BigInteger p, BigInteger a)
        {
            BigInteger Rr, _R, P = p, A = a;
            Get_Sqare(out Rr, out _R, P, A);

            return Rr;
        }

        /// <summary>
        /// Получение квадратных корней(двух)
        /// </summary>
        /// <param name="r">Первый корень</param>
        /// <param name="_r">Второй корень</param>
        /// <param name="p">модуль по которому берётся корень</param>
        /// <param name="a">число корень из которого следует вычислить</param>
        static void Get_Sqare(out BigInteger r, out BigInteger _r, BigInteger p, BigInteger a)
        {


            //step 1
            if (Jacobi(a, p) == -1)
            {

                throw new Exception("корня а по модулю п не существует");
            }
            //step 2
            BigInteger b = ChooseRandB(p), t, s;

            //step 3
            Step2PowSumnT(p, out t, out s);

            //step 4
            BigInteger a_1 = FindA_1ModN(a, p);

            //step 5
            BigInteger c = BigInteger.ModPow(b, t, p);
            r = BigInteger.ModPow(a, (t + 1) / 2, p);

            //step 6
            for (BigInteger i = 1; i <= s - 1; i++)
            {
                BigInteger d = BigInteger.ModPow((r * r * a_1), BigInteger.Pow(2, (int)(s - i - 1)), p);
                if (Eq_1(d, p))
                    r = BigInteger.ModPow(r * c, 1, p);
                c = BigInteger.ModPow(c, 2, p);
            }
            _r = -r;


        }

        /// <summary>
        /// Хеш функция удваивания двух последних цифр
        /// </summary>
        /// <param name="CryptTEXT">Число цифры которого удваиваем</param>
        /// <returns>Число с удвоемнными последними цифрами</returns>
        static BigInteger MX(BigInteger CryptTEXT)
        {
            return CryptTEXT % 100 + CryptTEXT * 100;
        }
        #endregion

        #region Miller_Rabin_Tests

        /// <summary>
        /// Тест на простоту Миллера-Рабина
        /// </summary>
        /// <param name="Number">Проверяемое число</param>
        /// <param name="Rounds">Точность(количество раундов)</param>
        /// <returns>True если число вероятно простое. False в случае если оно составное </returns>
        public static bool Miller_Rabin_Test(BigInteger Number, BigInteger Rounds)
        {
            if (Number <= 2)
                throw new Exception("На тест подано чилос меньше 3");

            if (BigInteger.ModPow(Number, 1, 2) == 0)
                return false;

            BigInteger S, T;

            Step2PowSumnT(Number, out T, out S);

            //цикл А
            for (int i = 0; i < Rounds; i++)
            {
                bool flagtoCycleA = false;
                BigInteger a = Rand(Number - 1);
                BigInteger x = BigInteger.ModPow(a, T, Number);
                if (x == 1 || x == Number - 1)
                    continue;
                //цикл Б
                for (int k = 0; k < (S - 1); k++)
                {
                    x = BigInteger.ModPow(x, 2, Number);
                    if (x == 1)
                        return false;
                    if (x == Number - 1)
                    {
                        flagtoCycleA = true;
                        break;
                    }


                }
                if (flagtoCycleA)
                    continue;
                return false;

            }

            return true;
        }

        /// <summary>
        /// Тест на простоту Миллера-Рабина с автоматическое точностью
        /// равное log2(n)
        /// </summary>
        /// <param name="Number">Проверяемое число</param>
        /// <returns>True если число вероятно простое. False в случае если оно составное</returns>
        public static bool Miller_Rabin_Test(BigInteger Number)
        {
            if (Number <= 2)
                throw new Exception("На тест подано чилос меньше 3");

            if (BigInteger.ModPow(Number, 1, 2) == 0)
                return false;

            int X = 1;
            BigInteger pow = 2;
            do
            {
                if (X < pow * 2 && pow >= X)
                    break;
                pow *= 2;
                X++;
            } while (true);

            return Miller_Rabin_Test(Number, X);


        }

        /// <summary>
        /// Выбор случайного числа в промежутке от 1 до p
        /// </summary>
        /// <param name="p">Промежуток генерации</param>
        /// <returns>Число в промежутке от 1 до p</returns>
        public static BigInteger Rand(BigInteger p)
        {

            BigInteger result;
            string str = "";
            bool flag = true;

            int[] pio = (p + "").ToCharArray().Select(k => int.Parse(k + "")).ToArray();

            for (int i = 0; i < pio.Length; i++)
            {

                int x;
                if (flag)
                {
                    x = rnd.Next(1, pio[i] + 1);
                    if (x < pio[i])
                        flag = false;

                }
                else
                {
                    x = rnd.Next(1, 10);
                }

                str += x;
            }

            result = BigInteger.Parse(str);
            return result;
        }

        public static string GeneRateKey(int symbCount)
        {
            bool rx = false;


            string rs = "";
            do
            {
                rs = "";
                for (int i = 0; i < symbCount; i++)
                {
                    rs += "9";
                }
                BigInteger k99 = BigInteger.Parse(rs);
                BigInteger rnd = Rabin.Rand(k99);
                rx = Rabin.Miller_Rabin_Test(rnd);
                if (rx)
                {
                    rs = rnd + "";
                    break;
                }
            } while (true);

            return rs;
        }

        public static string gen2Keys(int symb1, int symb2)
        {
            return GeneRateKey(symb1) + " " + GeneRateKey(symb2);
        }

        #endregion

        #region Inactive methods
        //в этом разделе находятся методы которые могут использоваться для быстроты
        // но в силу их узкости были заменены


        /// <summary>
        /// Преобразует строку в число
        /// </summary>
        /// <param name="text">Входная строка </param>
        /// <returns>Число</returns>
        static BigInteger ConvToString(string text)
        {


            char[] newSystemMod = text.ToCharArray();
            Array.Reverse(newSystemMod);

            BigInteger result = 0;

            for (int i = 0; i < newSystemMod.Length; i++)
                result += (BigInteger)Math.Pow(27, i) * ((int)newSystemMod[i] - (int)'A' + 1);
            return result;
        }

        /// <summary>
        /// Конвертировние в строку из числа по основанию 27
        /// </summary>
        /// <param name="numDEX">Число для перевода</param>
        /// <returns>тТекст</returns>
        static string ConvertTo27System(BigInteger numDEX)
        {


            string result = "";
            BigInteger initNumb = numDEX;
            while (initNumb > 26)
            {
                result += (char)('A' - 1 + initNumb % 27);
                initNumb /= 27;
            }
            result += (char)('A' - 1 + initNumb);
            char[] ch = result.ToCharArray();
            Array.Reverse(ch);
            result = "";
            foreach (char c in ch)
                result += c + "";
            return result;
        }
        #endregion
    }

}
