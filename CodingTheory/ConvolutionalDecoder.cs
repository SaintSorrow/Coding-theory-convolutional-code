using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTheory
{
    class ConvolutionalDecoder
    {
        private bool[] primaryRegister = new bool[Constants.RegisterLength];
        private bool[] secondaryRegister = new bool[Constants.RegisterLength];

        private void ShiftRegister(bool[] _register, bool _bit)
        {
            for (int position = _register.Length - 1; position > 0; position--)
            {
                _register[position] = _register[position - 1];
            }

            _register[0] = _bit;
        }

        /// <summary>
        /// MDE - Majority decision element
        /// </summary>
        /// <param name="_bit1"></param>
        /// <param name="_bit2"></param>
        /// <param name="_bit3"></param>
        /// <param name="_bit4"></param>
        /// <returns></returns>
        private bool ProcessMDE(bool _bit1, bool _bit2, bool _bit3, bool _bit4)
        {
            bool value;

            if ((!_bit1 && _bit2 && _bit3 && _bit4)
              || (_bit1 && !_bit2 && _bit3 && _bit4)
              || (_bit1 && _bit2 && !_bit3 && _bit4)
              || (_bit1 && _bit2 && _bit3 && !_bit4))
            {
                value = true;
            }
            else
            {
                value = false;
            }

            return value;
        }

        public Queue<bool> DecodeQueue(Queue<bool> _inputQueue)
        {
            Queue<bool> output = new Queue<bool>();
            bool primaryRegisterXor;
            bool xor1;
            bool xor2;
            bool xor3;
            bool[] bitArray = _inputQueue.ToArray();
            bool decodedBit;
            bool mde;

            for (int position = 0; position < bitArray.Length; position += 2)
            {
                primaryRegisterXor = bitArray[position]
                                   ^ bitArray[position + 1]
                                   ^ primaryRegister[Constants.RegisterPositionOne]
                                   ^ primaryRegister[Constants.RegisterPositionTwo]
                                   ^ primaryRegister[Constants.RegisterPositionThree];
                mde = ProcessMDE(primaryRegisterXor,
                                 secondaryRegister[Constants.SecondaryRegisterPositionOne],
                                 secondaryRegister[Constants.SecondaryRegisterPositionTwo],
                                 secondaryRegister[Constants.SecondaryRegisterPositionThree]);
                xor1 = primaryRegisterXor ^ mde;
                xor2 = secondaryRegister[Constants.SecondaryRegisterPositionOne] ^ mde;
                xor3 = secondaryRegister[Constants.SecondaryRegisterPositionTwo] ^ mde;
                decodedBit = primaryRegister[Constants.RegisterPositionThree] ^ mde;

                secondaryRegister[5] = secondaryRegister[4];
                secondaryRegister[4] = xor3;
                secondaryRegister[3] = secondaryRegister[2];
                secondaryRegister[2] = secondaryRegister[1];
                secondaryRegister[1] = xor2;
                secondaryRegister[0] = xor1;

                ShiftRegister(primaryRegister, bitArray[position]);
                output.Enqueue(decodedBit);
            }

            return output;
        }
    }
}
