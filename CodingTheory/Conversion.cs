﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CodingTheory
{
    /// <summary>
    /// Klasė skirta duomenų konvertavimui iš vieno duomenų tipo į kitą
    /// </summary>
    public class Conversion
    {
        public Image ImageWithErrors { get;  private set; }
        public Image DecodedImage { get; private set; }
        private byte[] ImageHeader = new byte[Constants.HeaderBytes];
        private Channel Channel;
        public string EncodedVector { get; private set; }
        public string EncodedAndSentVector { get; private set; }
        public string DecodedVector { get; private set; }
        public int[] ErrorPositions { get; private set; }

        public Conversion(double _errorChance)
        {
            Channel = new Channel(_errorChance);
        }

        /// <summary>
        /// Tekstas 
        /// </summary>
        /// <param name="_text"></param>
        /// <returns></returns>
        public string StringToBinary(string _text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            char[] charArray = _text.ToCharArray();

            for (int position = 0; position < charArray.Length; position++)
            {
                char chr = charArray[position];
                stringBuilder.Append(Convert.ToString(chr, 2).PadLeft(8, '0'));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Dvejetainis tekstas yra paverčiamas į ascii simbolius 
        /// </summary>
        /// <param name="_text">
        /// Dvejetainis tekstas
        /// </param>
        /// <returns>
        /// Grąžina tekstą ascii simbolių pavidalu
        /// </returns>
        public string BinaryToString(string _text)
        {
            List<byte> byteList = new List<byte>();

            for (int position = 0; position < _text.Length; position += 8)
            {
                byteList.Add(Convert.ToByte(_text.Substring(position, 8), 2));
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        /// <summary>
        /// Paveikslėlis yra konvertuojamas į dvejetainį tekstą
        /// </summary>
        /// <param name="_image">
        /// Paveikslėlis kurį norima konvertuoti
        /// </param>
        /// <param name="_imageFormat">
        /// To paveikslėlio formatas
        /// </param>
        /// <returns>
        /// Grąžinamas string tipo kintamasis, kuris turi dvejetainį tekstą
        /// </returns>
        public string ImageToBinary(Image _image, ImageFormat _imageFormat)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                _image.Save(memoryStream, _imageFormat);
                byte[] tmpArray = memoryStream.ToArray();
                byte byteValue;

                for (int position = 0; position < tmpArray.Length; position++)
                {
                    byteValue = tmpArray[position];

                    if (position < Constants.HeaderBytes)
                    {
                        ImageHeader[position] = byteValue;
                    }

                    stringBuilder.Append(Convert.ToString(byteValue, 2).PadLeft(8, '0'));
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Dvejetainį tekstą sudedame į <bool> tipo eilę
        /// </summary>
        /// <param name="_binaryString">
        /// Dvejetainis tekstas
        /// </param>
        /// <returns>
        /// Eilė, kurioje yra saugomos true arba false reikšmės
        /// </returns>
        public Queue<bool> BinaryStringToQueue(string _binaryString)
        {
            Queue<bool> binaryQueue = new Queue<bool>();
            bool result;

            foreach (char c in _binaryString)
            {
                result = (c == '1') ? true : false;
                binaryQueue.Enqueue(result);
            }

            return binaryQueue;
        }

        /// <summary>
        /// Dvejetainis tekstas yra konvertuojamas į paveikslėlį
        /// </summary>
        /// <param name="_binaryString">
        /// Dvejetainis tekstas
        /// </param>
        /// <returns>
        /// Grąžina sugeneruotą paveikslėlį
        /// </returns>
        public Image BinaryToImage(string _binaryString)
        {
            List<Byte> byteList = new List<Byte>();

            for (int position = 0; position < Constants.HeaderBytes; position++)
            {
                byteList.Add(ImageHeader[position]);
            }

            for (int position = Constants.HeaderBytes * 8; position < _binaryString.Length; position += 8)
            {
                byteList.Add(Convert.ToByte(_binaryString.Substring(position, 8), 2));
            }

            using (MemoryStream memoryStream = new MemoryStream(byteList.ToArray()))
            {
                return Image.FromStream(memoryStream);
            }
        }

        /// <summary>
        /// "bool" tipo eilę paverčia į tekstą 
        /// </summary>
        /// <param name="_binaryQueue">
        /// Eilė, kuri savyje saugo true arba false reikšmes
        /// </param>
        /// <returns>
        /// Grąžina dvejetainę informaciją teksto pavidalu 
        /// </returns>
        public string BinaryQueueToString(Queue<bool> _binaryQueue)
        {
            char[] charArray = new char[_binaryQueue.Count];
            bool bit;
            char binaryValue;

            for (int position = 0; position < _binaryQueue.Count; position++)
            {
                bit = _binaryQueue.Peek();
                _binaryQueue.Dequeue();
                _binaryQueue.Enqueue(bit);
                binaryValue = bit ? '1' : '0';
                charArray[position] = binaryValue;
            }

            return new string(charArray);
        }

        /// <summary>
        /// Atliekami konvertavimo, dekodavimo ir siuntimo per kanalą veiksmai paveikslėliui.
        /// </summary>
        /// <param name="_image">
        /// Paveikslėlis, kurį reikia apdoroti
        /// </param>
        public void RunImage(Image _image)
        {
            Queue<bool> originalImageQueue = new Queue<bool>();
            Queue<bool> encodedImageQueue = new Queue<bool>();
            Queue<bool> decodedImageQueue = new Queue<bool>();
            Queue<bool> imageWithErrorQueue = new Queue<bool>();
            ConvolutionalDecoder decoder = new ConvolutionalDecoder();
            ConvolutionalEncoder encoder = new ConvolutionalEncoder();

            originalImageQueue = this.BinaryStringToQueue(this.ImageToBinary(_image, _image.RawFormat));

            encoder.EncodeQueue(originalImageQueue, encodedImageQueue);
            imageWithErrorQueue = Channel.SendData(encodedImageQueue);
            decodedImageQueue = decoder.DecodeQueue(imageWithErrorQueue);
            DecodedImage = this.BinaryToImage(this.BinaryQueueToString(decodedImageQueue));

            imageWithErrorQueue = Channel.SendData(originalImageQueue);
            ImageWithErrors = this.BinaryToImage(this.BinaryQueueToString(imageWithErrorQueue));
        }

        /// <summary>
        /// Atliekami kodavimo, dekodavimo, siuntimo per kanalą ir konvertavimo veiksmai su vektoriumi
        /// </summary>
        /// <param name="_binaryVector">
        /// Vektorius, kurį reikia apdoroti
        /// </param>
        public void RunVector(string _binaryVector)
        {
            Queue<bool> originalVectorQueue = new Queue<bool>();
            Queue<bool> encodedVectorQueue = new Queue<bool>();
            Queue<bool> decodedVectorQueue = new Queue<bool>();
            Queue<bool> vectorWithErrorsQueue = new Queue<bool>();
            ConvolutionalEncoder encoder = new ConvolutionalEncoder();
            ConvolutionalDecoder decoder = new ConvolutionalDecoder();

            originalVectorQueue = this.BinaryStringToQueue(_binaryVector);
            encoder.EncodeQueue(originalVectorQueue, encodedVectorQueue);
            vectorWithErrorsQueue = Channel.SendData(encodedVectorQueue);
            decodedVectorQueue = decoder.DecodeQueue(vectorWithErrorsQueue);
        
            ErrorPositions = Channel.ErrorPositions;
            EncodedVector = this.BinaryQueueToString(encodedVectorQueue);
            EncodedAndSentVector = this.BinaryQueueToString(vectorWithErrorsQueue);
            DecodedVector = this.BinaryQueueToString(decodedVectorQueue);
        }

        /// <summary>
        /// Atliekami kodavimo, deodavimo, konvertavimo ir siuntimo per kanalą veiksmai su paprastu tekstu
        /// </summary>
        /// <param name="_input">
        /// Tekstas , kurį reikia apdoroti
        /// </param>
        public void RunString(string _input)
        {
            Queue<bool> originalStringQueue = new Queue<bool>();
            Queue<bool> encodedStringQueue = new Queue<bool>();
            Queue<bool> decodedStringQueue = new Queue<bool>();
            Queue<bool> stringWithErrorsQueue = new Queue<bool>();
            ConvolutionalEncoder encoder = new ConvolutionalEncoder();
            ConvolutionalDecoder decoder = new ConvolutionalDecoder();

            originalStringQueue = this.BinaryStringToQueue(this.StringToBinary(_input));


            encoder.EncodeQueue(originalStringQueue, encodedStringQueue);
            stringWithErrorsQueue = Channel.SendData(encodedStringQueue);
            decodedStringQueue = decoder.DecodeQueue(stringWithErrorsQueue);

            DecodedVector = this.BinaryToString(this.BinaryQueueToString(decodedStringQueue));

            stringWithErrorsQueue.Clear();
            stringWithErrorsQueue = Channel.SendData(originalStringQueue);
            EncodedAndSentVector = this.BinaryToString(this.BinaryQueueToString(originalStringQueue));
        }

    }
}
