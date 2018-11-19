using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CodingTheory
{
    public class Conversion
    {
        public static string StringToBinary(string _text)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in _text.ToCharArray())
            {
                stringBuilder.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            return stringBuilder.ToString();
        }

        public static string BinaryToString(string _text)
        {
            List<Byte> byteList = new List<byte>();

            for (int i = 0; i < _text.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(_text.Substring(i, 8), 2));
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public static string ImageToBinary(Image _image, ImageFormat _imageFormat)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                _image.Save(memoryStream, _imageFormat);

                foreach (byte bit in memoryStream.ToArray())
                {
                    stringBuilder.Append(Convert.ToString(bit, 2).PadLeft(8, '0'));
                }
            }

            return stringBuilder.ToString();
        }

        public static Queue<bool> BinaryStringToQueue(string _binaryString)
        {
            Queue<bool> binaryQueue = new Queue<bool>();

            foreach (char c in _binaryString)
            {
                bool result = (c == '1') ? true : false;
                binaryQueue.Enqueue(result);
            }

            return binaryQueue;
        }


        public static Image BinaryToImage(string _binaryString)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < _binaryString.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(_binaryString.Substring(i, 8), 2));
            }

            using (MemoryStream memoryStream = new MemoryStream(byteList.ToArray()))
            {
                return Image.FromStream(memoryStream);
            }
        }

        public static string BinaryQueueToString(Queue<bool> _binaryQueue)
        {
            char[] charArray = new char[_binaryQueue.Count];
            bool bit;
            char binaryValue;

            for (int i = 0; i < _binaryQueue.Count; i++)
            {
                bit = _binaryQueue.Dequeue();
                _binaryQueue.Enqueue(bit);

                binaryValue = bit ? '1' : '0';
                charArray[i] = binaryValue;
            }

            return new string(charArray);
        }
    }
}
