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

        public string StringToBinary(string _text)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in _text.ToCharArray())
            {
                stringBuilder.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            return stringBuilder.ToString();
        }

        public string BinaryToString(string _text)
        {
            List<Byte> byteList = new List<byte>();

            for (int i = 0; i < _text.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(_text.Substring(i, 8), 2));
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public string ImageToBinary(Image _image, ImageFormat _imageFormat)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                _image.Save(memoryStream, _imageFormat);
                byte[] tmpArray = memoryStream.ToArray();

                for (int position = 0; position < Constants.HeaderBytes; position++)
                {
                    ImageHeader[position] = tmpArray[position];
                }

                foreach (byte bit in memoryStream.ToArray())
                {
                    stringBuilder.Append(Convert.ToString(bit, 2).PadLeft(8, '0'));
                }
            }

            return stringBuilder.ToString();
        }

        public Queue<bool> BinaryStringToQueue(string _binaryString)
        {
            Queue<bool> binaryQueue = new Queue<bool>();
            binaryQueue.Clear();

            foreach (char c in _binaryString)
            {
                bool result = (c == '1') ? true : false;
                binaryQueue.Enqueue(result);
            }

            return binaryQueue;
        }


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

        public string BinaryQueueToString(Queue<bool> _binaryQueue)
        {
            char[] charArray = new char[_binaryQueue.Count];
            bool bit;
            char binaryValue;

            for (int i = 0; i < _binaryQueue.Count; i++)
            {
                bit = _binaryQueue.Peek();
                _binaryQueue.Dequeue();
                _binaryQueue.Enqueue(bit);

                binaryValue = bit ? '1' : '0';
                charArray[i] = binaryValue;
            }

            return new string(charArray);
        }

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

        public void RunString(string _input)
        {
            Queue<bool> originalStringQueue = new Queue<bool>();
            Queue<bool> encodedStringQueue = new Queue<bool>();
            Queue<bool> decodedStringQueue = new Queue<bool>();
            Queue<bool> stringWithErrorsQueue = new Queue<bool>();
            ConvolutionalEncoder encoder = new ConvolutionalEncoder();
            ConvolutionalDecoder decoder = new ConvolutionalDecoder();

            originalStringQueue = this.BinaryStringToQueue(this.StringToBinary(_input));
            stringWithErrorsQueue = Channel.SendData(originalStringQueue);
            EncodedAndSentVector = this.BinaryToString(this.BinaryQueueToString(originalStringQueue));
            encoder.EncodeQueue(originalStringQueue, encodedStringQueue);
            stringWithErrorsQueue = Channel.SendData(encodedStringQueue);
            decodedStringQueue = decoder.DecodeQueue(stringWithErrorsQueue);

            EncodedVector = this.BinaryToString(this.BinaryQueueToString(encodedStringQueue));
            DecodedVector = this.BinaryToString(this.BinaryQueueToString(decodedStringQueue));
        }

    }
}
