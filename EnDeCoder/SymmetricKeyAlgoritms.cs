using System.Text;

namespace EnDeCoder
{
    class SymmetricKeyAlgoritms
    {
        /// <summary>
        ///     Выполняет шифрование сообщения методом простой перестановки.
        /// </summary>
        /// 
        /// <param name="message">
        ///     Шифруемое сообщение.
        /// </param>
        /// 
        /// <param name="cols">
        ///     Количество столбцов шифрующей таблицы.
        /// </param>
        /// 
        /// <param name="rows">
        ///     Количество строк шифрующей таблицы.
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде.
        /// </returns>
        public static string SimplePermutation(string message, int cols, int rows)
        {
            var encodedMessage = new StringBuilder();

            var table = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                table[i] = new char[cols];
                for (int j = 0; j < cols; j++)
                {
                    int index = i * cols + j;
                    table[i][j] = index < message.Length ? message[index] : '/';
                }
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    encodedMessage.Append(table[j][i]);
                }
            }

            return encodedMessage.ToString();
        }

        /// <summary>
        ///     Выполняет шифрование сообщения методом простой перестановки с ключом.
        /// </summary>
        /// 
        /// <param name="message">
        ///     Шифруемое сообщение.
        /// </param>
        /// 
        /// <param name="cols">
        ///     Количество столбцов шифрующей таблицы.
        /// </param>
        /// 
        /// <param name="rows">
        ///     Количество строк шифрующей таблицы.
        /// </param>
        /// 
        /// <param name="key"></param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде.
        /// </returns>
        public static string SinglePermutationWithKey(string message, int cols, int rows, string key)
        {
            var encodedMessage = SimplePermutation(message, cols, rows);
            encodedMessage = PermutationWithKey(encodedMessage, key);
            return encodedMessage;
        }

        /// <summary>
        ///     Выполняет шифрование сообщения методом двойной перестановки.
        /// </summary>
        /// 
        /// <param name="message">
        ///     Шифруемое сообщение.
        /// </param>
        /// 
        /// <param name="cols">
        ///     Количество столбцов шифрующей таблицы.
        /// </param>
        /// 
        /// <param name="rows">
        ///     Количество строк шифрующей таблицы.
        /// </param>
        /// 
        /// <param name="key1">
        ///     Ключ шифрования.
        /// </param>
        /// 
        /// <param name="key2">
        ///     Ключ шифрования.
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде.
        /// </returns>
        public static string DoublePermutation(string message, int cols, int rows, string key1, string key2)
        {
            var encodedMessage = SinglePermutationWithKey(message, cols, rows, key1);
            encodedMessage = PermutationWithKey(encodedMessage, key2);
            return encodedMessage;
        }

        /// <summary>
        ///     Выполняет перестановку символов в строке по заданному ключу.
        /// </summary>
        /// 
        /// <param name="str">
        ///     Строка символов, подлежащая изменению.
        /// </param>
        ///     
        /// <param name="key">
        ///     Ключ перестановки.
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде.
        /// </returns>
        private static string PermutationWithKey(string str, string key)
        {
            var result = new StringBuilder();

            var sequence = new int[key.Length];
            var keyWord = new StringBuilder(key);
            for (int i = 0; i < key.Length; i++)
            {
                sequence[i] = i;
            }

            for (int i = 1; i < key.Length; i++)
            {
                int intBuf = sequence[i];
                char charBuf = keyWord[i];
                int j = i - 1;

                while (j >= 0 && keyWord[j] > charBuf)
                {
                    sequence[j + 1] = sequence[j];
                    keyWord[j + 1] = keyWord[j];
                    j--;
                }

                sequence[j + 1] = intBuf;
                keyWord[j + 1] = charBuf;
            }

            int dimension = str.Length / key.Length;
            for (int i = 0; i < key.Length; i++)
            {
                int index = sequence[i] * dimension;
                result.Append(str.Substring(index, dimension));
            }

            return result.ToString();
        }
    }
}