using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EnDeCoder
{
    class EncryptUtils
    {
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
        /// <param name="isDecoding">
        ///     true, если необходимо использовать метод для дешифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает сообщение в зашифрованном виде.
        /// </returns>
        protected static string PermutationWithKey(string str, string key, bool isDecoding)
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

            int dimension = str.Length / key.Length, pos = 0;
            for (int i = 0; i < key.Length; i++)
            {
                int index = 0;
                if (isDecoding)
                {
                    for (int j = 0; j < key.Length; j++)
                    {
                        if (sequence[j] == pos)
                        {
                            index = j * dimension;
                            break;
                        }
                    }

                    pos++;
                }
                else
                {
                    index = sequence[i] * dimension;
                }
                result.Append(str.Substring(index, dimension));
            }

            return result.ToString();
        }

        /// <summary>
        ///     Выполняет шифрование сообщения указанным методом
        /// </summary>
        /// 
        /// <param name="text">
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
        /// <param name="algorithm">
        ///     Алгоритм шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает зашифрованное сообщение в виде последовательности байтов
        /// </returns>
        protected static byte[] EncryptStringToBytes(string text, byte[] key, byte[] IV, SymmetricAlgorithm algorithm)
        {
            byte[] encrypted;

            ICryptoTransform encryptor = algorithm.CreateEncryptor(key, IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            return encrypted;
        }

        /// <summary>
        ///     Выполняет дешифрование сообщения указанным методом
        /// </summary>
        /// 
        /// <param name="text">
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
        /// <param name="algorithm">
        ///     Алгоритм шифрования
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает расшифрованное сообщение
        /// </returns>
        protected static string DecryptStringFromBytes(byte[] encryptedText, byte[] key, byte[] IV, SymmetricAlgorithm algorithm)
        {
            string text = null;

            ICryptoTransform decryptor = algorithm.CreateDecryptor(key, IV);

            using (MemoryStream msDecrypt = new MemoryStream(encryptedText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        text = srDecrypt.ReadToEnd();
                    }
                }
            }

            return text;
        }

        /// <summary>
        ///     Переводит последовательность байтов в строку
        /// </summary>
        /// 
        /// <param name="bytes">
        ///     Последовательность байтов
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает полученную строку
        /// </returns>
        protected static string BytesToString(byte[] bytes)
        {
            StringBuilder result = new StringBuilder();
            foreach (byte chr in bytes)
            {
                result.Append(Convert.ToChar(chr));
            }

            return result.ToString();
        }

        /// <summary>
        ///     Переводит строку в последовательность байтов и расширяет ее при необходимости
        /// </summary>
        /// 
        /// <param name="str">
        ///     Строка
        /// </param>
        /// 
        /// <param name="size">
        ///     Размер строки
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает полученную последовательность байтов
        /// </returns>
        public static byte[] StringToBytes(string str, int size)
        {
            var keyToBytes = new byte[size];

            for (int i = 0; i < size; i++)
            {
                keyToBytes[i] = i < str.Length ? Convert.ToByte(str[i]) : Convert.ToByte(1);
            }

            return keyToBytes;
        }
    }
}