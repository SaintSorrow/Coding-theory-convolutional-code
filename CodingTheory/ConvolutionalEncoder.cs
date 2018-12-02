using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTheory
{
    /// <summary>
    /// LT - Klasė skirta užkoduoti informaciją sąsukos code.
    /// EN - A class for encoding information with convolutional code.
    /// </summary>
    class ConvolutionalEncoder
    {
        private bool[] register = new bool[Constants.RegisterLength];

        /// <summary>
        /// LT - Šis metodas užkoduoja bitą dviem bitais, pirmas bitas yra įvedamas bitas, o antras bitas gaunamas atliekant xor sumą.
        /// EN - This method encodes a single bit into two bits. First bit is and input bit, second one is xor of register fields and input bit.
        /// </summary>
        /// <param name="_output">
        /// LT - Eilė, kuri toliau bus naudojama dekodavimui
        /// EN - Queue for further decoding
        /// </param>
        /// <param name="_bit">
        /// LT - Įvesties bitas.
        /// EN - Input bit
        /// </param>
        private void EncodeBit(Queue<bool> _output, bool _bit)
        {
            bool encodedBit = _bit 
                            ^ register[Constants.RegisterPositionOne] 
                            ^ register[Constants.RegisterPositionTwo] 
                            ^ register[Constants.RegisterPositionThree];
            _output.Enqueue(_bit);
            _output.Enqueue(encodedBit);
            ShiftRegister(_bit);
        }

        /// <summary>
        /// LT - Šis metodas užkoduoja informaciją sąsukos kodu
        /// EN - This method encodes data using convolutional code
        /// </summary>
        /// <param name="_inputQueue"></param>
        /// LT - Įeinanti informacija, neužkoduota
        /// EN - Input data, not encoded
        /// <param name="_outputQueue">
        /// LT - Išeinanti informacija, užkoduota
        /// EN - output data, encoded
        /// </param>
        public void EncodeQueue(Queue<bool> _inputQueue, Queue<bool> _outputQueue)
        {
            foreach (bool bit in _inputQueue)
            {
                EncodeBit(_outputQueue, bit);
            }

            for (int position = 0; position < Constants.RegisterLength; position++)
            {
                EncodeBit(_outputQueue, false);
            }
        }

        /// <summary>
        /// LT - Šis metodas paslenka visus registro bitus per vieną žingnį.
        /// EN - This method shifts register bits by one step
        /// </summary>
        /// <param name="_bit">
        /// LT - bitas, kuris naudojamas paslenkant registrą per vieną žingsnį
        /// EN - bit for shifting register by one step
        /// </param>
        private void ShiftRegister(bool _bit)
        {
            for (int position = register.Length - 1; position > 0; position--)
            {
                register[position] = register[position - 1];
            }

            register[0] = _bit;
        }
    }
}
