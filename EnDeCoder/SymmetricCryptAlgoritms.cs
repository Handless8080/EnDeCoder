using System.Security.Cryptography;
using System.Text;

namespace EnDeCoder
{
    class SymmetricCryptAlgoritms : EncryptUtils
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

            var table = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int index = i * cols + j;
                    table[i, j] = index < message.Length ? message[index] : '/';
                }
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    encodedMessage.Append(table[j, i]);
                }
            }
            
            return encodedMessage.ToString();
        }

        /// <summary>
        ///     Выполняет дешифрование сообщения методом простой перестановки.
        /// </summary>
        /// 
        /// <param name="message">
        ///     Зашифрованное сообщение.
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
        ///     Возвращает сообщение в расшифрованном виде.
        /// </returns>
        public static string SimplePermutation_Decrypt(string message, int cols, int rows)
        {
            var encodedMessage = new StringBuilder();

            var table = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int index = j * rows + i;
                    table[i, j] = message[index];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    encodedMessage.Append(table[i, j]);
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
        /// <param name="key">
        ///     Ключевое слово
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде.
        /// </returns>
        public static string SinglePermutationWithKey(string message, int cols, int rows, string key)
        {
            var encodedMessage = SimplePermutation(message, cols, rows);
            encodedMessage = PermutationWithKey(encodedMessage, key, false);
            return encodedMessage;
        }

        /// <summary>
        ///     Выполняет дешифрование сообщения методом простой перестановки с ключом.
        /// </summary>
        /// 
        /// <param name="message">
        ///     Зашифрованное сообщение.
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
        /// <param name="key">
        ///     Ключевое слово
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в расшифрованном виде.
        /// </returns>
        public static string SinglePermutationWithKey_Decrypt(string message, int cols, int rows, string key)
        {
            var decodedMessage = PermutationWithKey(message, key, true);
            decodedMessage = SimplePermutation_Decrypt(decodedMessage, cols, rows);
            return decodedMessage;
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
            encodedMessage = PermutationWithKey(encodedMessage, key2, false);
            return encodedMessage;
        }

        /// <summary>
        ///     Выполняет дешифрование сообщения методом двойной перестановки.
        /// </summary>
        /// 
        /// <param name="message">
        ///     Зашифрованное сообщение.
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
        ///     Возвращает сообщение в расшифрованном виде.
        /// </returns>
        public static string DoublePermutation_Decrypt(string message, int cols, int rows, string key1, string key2)
        {
            var decodedMessage = PermutationWithKey(message, key2, true);
            decodedMessage = SinglePermutationWithKey_Decrypt(decodedMessage, cols, rows, key1);
            return decodedMessage;
        }

        /// <summary>
        ///     Выполняет шифрование сообщения алгоритмом AES
        /// </summary>
        /// 
        /// <param name="message">
        ///     Шифруемое сообщение
        /// </param>
        /// 
        /// <param name="key">
        ///     Ключ шифрования
        /// </param>
        /// 
        /// <param name="IV">
        ///     Вектор шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде
        /// </returns>
        public static byte[] AESEncrypt(string message, string key, string IV)
        {
            var keyToBytes = StringToBytes(key, 32);
            var IVToBytes = StringToBytes(IV, 16);

            byte[] encrypted = EncryptStringToBytes(message, keyToBytes, IVToBytes, Aes.Create());

            return encrypted;
        }

        /// <summary>
        ///     Выполняет дешифрование сообщения алгоритмом AES
        /// </summary>
        /// 
        /// <param name="message">
        ///     Зашифрованное сообщение
        /// </param>
        /// 
        /// <param name="key">
        ///     Ключ шифрования
        /// </param>
        /// 
        /// <param name="IV">
        ///     Вектор шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает расшифрованное сообщения
        /// </returns>
        public static string AESDecrypt(byte[] message, string key, string IV)
        {
            var keyToBytes = StringToBytes(key, 32);
            var IVToBytes = StringToBytes(IV, 16);

            string decrypted = DecryptStringFromBytes(message, keyToBytes, IVToBytes, Aes.Create());

            return decrypted;
        }

        /// <summary>
        ///     Выполняет шифрование сообщения алгоритмом DES
        /// </summary>
        /// 
        /// <param name="message">
        ///     Шифруемое сообщение
        /// </param>
        /// 
        /// <param name="key">
        ///     Ключ шифрования
        /// </param>
        /// 
        /// <param name="IV">
        ///     Вектор шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде
        /// </returns>
        public static byte[] DESEncrypt(string message, string key, string IV)
        {
            var keyToBytes = StringToBytes(key, 8);
            var IVToBytes = StringToBytes(IV, 8);

            byte[] encrypted = EncryptStringToBytes(message, keyToBytes, IVToBytes, DES.Create());

            return encrypted;
        }

        /// <summary>
        ///     Выполняет дешифрование сообщения алгоритмом DES
        /// </summary>
        /// 
        /// <param name="message">
        ///     Зашифрованное сообщение
        /// </param>
        /// 
        /// <param name="key">
        ///     Ключ шифрования
        /// </param>
        /// 
        /// <param name="IV">
        ///     Вектор шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает расшифрованное сообщения
        /// </returns>
        public static string DESDecrypt(byte[] message, string key, string IV)
        {
            var keyToBytes = StringToBytes(key, 8);
            var IVToBytes = StringToBytes(IV, 8);

            string decrypted = DecryptStringFromBytes(message, keyToBytes, IVToBytes, DES.Create());

            return decrypted;
        }

        /// <summary>
        ///     Выполняет шифрование сообщения алгоритмом 3DES
        /// </summary>
        /// 
        /// <param name="message">
        ///     Шифруемое сообщение
        /// </param>
        /// 
        /// <param name="key">
        ///     Ключ шифрования
        /// </param>
        /// 
        /// <param name="IV">
        ///     Вектор шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде
        /// </returns>
        public static byte[] TripleDESEncrypt(string message, string key, string IV)
        {
            var keyToBytes = StringToBytes(key, 24);
            var IVToBytes = StringToBytes(IV, 8);

            byte[] encrypted = EncryptStringToBytes(message, keyToBytes, IVToBytes, TripleDES.Create());

            return encrypted;
        }

        /// <summary>
        ///     Выполняет дешифрование сообщения алгоритмом 3DES
        /// </summary>
        /// 
        /// <param name="message">
        ///     Зашифрованное сообщение
        /// </param>
        /// 
        /// <param name="key">
        ///     Ключ шифрования
        /// </param>
        /// 
        /// <param name="IV">
        ///     Вектор шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает расшифрованное сообщения
        /// </returns>
        public static string TripleDESDecrypt(byte[] message, string key, string IV)
        {
            var keyToBytes = StringToBytes(key, 24);
            var IVToBytes = StringToBytes(IV, 8);

            string decrypted = DecryptStringFromBytes(message, keyToBytes, IVToBytes, TripleDES.Create());

            return decrypted;
        }

        /// <summary>
        ///     Выполняет шифрование сообщения алгоритмом RC2
        /// </summary>
        /// 
        /// <param name="message">
        ///     Шифруемое сообщение
        /// </param>
        /// 
        /// <param name="key">
        ///     Ключ шифрования
        /// </param>
        /// 
        /// <param name="IV">
        ///     Вектор шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде
        /// </returns>
        public static byte[] RC2Encrypt(string message, string key, string IV)
        {
            var keyToBytes = StringToBytes(key, 16);
            var IVToBytes = StringToBytes(IV, 8);

            byte[] encrypted = EncryptStringToBytes(message, keyToBytes, IVToBytes, RC2.Create());

            return encrypted;
        }

        /// <summary>
        ///     Выполняет дешифрование сообщения алгоритмом RC2
        /// </summary>
        /// 
        /// <param name="message">
        ///     Зашифрованное сообщение
        /// </param>
        /// 
        /// <param name="key">
        ///     Ключ шифрования
        /// </param>
        /// 
        /// <param name="IV">
        ///     Вектор шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает расшифрованное сообщения
        /// </returns>
        public static string RC2Decrypt(byte[] message, string key, string IV)
        {
            var keyToBytes = StringToBytes(key, 16);
            var IVToBytes = StringToBytes(IV, 8);

            string decrypted = DecryptStringFromBytes(message, keyToBytes, IVToBytes, RC2.Create());

            return decrypted;
        }
    }
}