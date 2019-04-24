using System;
using System.Security.Cryptography;
using System.Text;

namespace EnDeCoder
{
    class KeyGen : EncryptUtils
    {
        /// <summary>
        ///     Генерирует ключи шифрования для метода простой перестановки
        /// </summary>
        /// 
        /// <param name="length">
        ///     Длина сообщения
        /// </param>
        /// 
        /// <param name="cols">
        ///     Число столбцов в шифруемой таблице
        /// </param>
        /// 
        /// <param name="rows">
        ///     Число строк в шифруемой таблице
        /// </param>
        public static void ForSimplePermutation(int length, out int cols, out int rows)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            if (length < 6)
            {
                cols = 3;
                rows = 3;

                return;
            }

            do
            {
                cols = random.Next(2, length / 3);
                rows = length / cols;
            }
            while (cols * rows < length);
        }

        /// <summary>
        ///     Генерирует ключи шифрования для метода простой перестановки по ключу
        /// </summary>
        /// 
        /// <param name="length">
        ///     Длина сообщения
        /// </param>
        /// 
        /// <param name="cols">
        ///     Число столбцов в шифруемой таблице
        /// </param>
        /// 
        /// <param name="rows">
        ///     Число строк в шифруемой таблице
        /// </param>
        /// 
        /// <param name="keyWord">
        ///     Ключевое слово
        /// </param>
        public static void ForSinglePermutationWithKey(int length, out int cols, out int rows, out string keyWord)
        {
            ForSimplePermutation(length, out cols, out rows);

            keyWord = GenKeyWord(cols);
        }

        /// <summary>
        ///     Генерирует ключи шифрования для метода двойной перестановки
        /// </summary>
        /// 
        /// <param name="length">
        ///     Длина сообщения
        /// </param>
        /// 
        /// <param name="cols">
        ///     Число столбцов в шифруемой таблице
        /// </param>
        /// 
        /// <param name="rows">
        ///     Число строк в шифруемой таблице
        /// </param>
        /// 
        /// <param name="keyWord1">
        ///     Первое ключевое слово
        /// </param>
        /// 
        /// <param name="keyWord2">
        ///     Второе ключевое слово
        /// </param>
        public static void ForDoublePermutation(int length, out int cols, out int rows, out string keyWord1, out string keyWord2)
        {
            ForSimplePermutation(length, out cols, out rows);

            keyWord1 = GenKeyWord(rows);
            keyWord2 = GenKeyWord(cols);
        }

        /// <summary>
        ///     Генерирует ключи для указанного симметричного метода шифрования
        /// </summary>
        /// 
        /// <param name="keyWord1">
        ///     Первое ключевое слово
        /// </param>
        /// 
        /// <param name="keyWord2">
        ///     Второе ключевое слово
        /// </param>
        /// 
        /// <param name="algoritm">
        ///     Алгоритм шифрования
        /// </param>
        public static void GenKeyAndIV(out string keyWord1, out string keyWord2, SymmetricAlgorithm algoritm)
        {
            keyWord1 = BytesToString(algoritm.Key);
            keyWord2 = BytesToString(algoritm.IV);
        }

        /// <summary>
        ///     Генерирует ключевое слово указанной длины
        /// </summary>
        /// 
        /// <param name="length">
        ///     Длина ключевого слова
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает ключевое слово
        /// </returns>
        private static string GenKeyWord(int length)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var str = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                char chr = (char)random.Next(0, 255);

                str.Append(chr);
            }

            return str.ToString();
        }
    }
}