using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTheory
{
    /// <summary>
    /// Klasė, kuri dekoduoja informaciją, papildomai naudoja grįžtąmąjį ryšį
    /// </summary>
    class ConvolutionalDecoder
    {
        /// <summary>
        /// Du registrai skirti dekodavimo veiksmams
        /// </summary>
        private bool[] primaryRegister = new bool[Constants.RegisterLength];
        private bool[] secondaryRegister = new bool[Constants.RegisterLength];

        /// <summary>
        /// Registro laukai yra pastumiami per vieną poziciją į dešinę
        /// </summary>
        /// <param name="_register">
        /// Registras, kuris bus pastumtas
        /// </param>
        /// <param name="_bit">
        /// Bitas, kuris bus įdedamas į registro pradžią
        /// </param>
        private void ShiftPrimaryRegister(bool _bit)
        {
            for (int position = primaryRegister.Length - 1; position > 0; position--)
            {
                primaryRegister[position] = primaryRegister[position - 1];
            }

            primaryRegister[0] = _bit;
        }

        /// <summary>
        /// MDE - Majority decision element
        /// Paskaičiuoja ar dauguma bitų yra lygūs 1.
        /// </summary>
        /// <param name="_bit1"></param>
        /// <param name="_bit2"></param>
        /// <param name="_bit3"></param>
        /// <param name="_bit4"></param>
        /// <returns>
        /// Grąžina apskaičiuotą reikšmę, 0 arba 1.
        /// Jeigu 3 arba 4 bitai yra true metodas gražina true, priešingu atveju grąžina false.
        /// </returns>
        private bool ProcessMDE(bool _bit1, bool _bit2, bool _bit3, bool _bit4)
        {
            int count = 0;
            bool value;

            if (_bit1)
                count++;

            if (_bit2)
                count++;

            if (_bit3)
                count++;

            if (_bit4)
                count++;

            if (count >= 3)
            {
                value = true;
            }
            else
            {
                value = false;
            }

            return value;
        }

        /// <summary>
        /// Dekoduojama eilė
        /// </summary>
        /// <param name="_inputQueue">
        /// Paduodama eilė, kurią reikės dekoduoti.
        /// </param>
        /// <returns>
        /// Grąžinama jau dekoduota eilė.
        /// </returns>
        public Queue<bool> DecodeQueue(Queue<bool> _inputQueue)
        {
            Queue<bool> output = new Queue<bool>();
            bool xor1, xor2, xor3, decodedBit, mde, primaryRegisterXor;
            bool[] bitArray = _inputQueue.ToArray();

            for (int position = 0; position < bitArray.Length; position += 2)
            {
                primaryRegisterXor = this.ProcessPrimaryRegister(bitArray[position], bitArray[position + 1]);
                mde = ProcessMDE(primaryRegisterXor,
                                 secondaryRegister[Constants.SecondaryRegisterPositionOne],
                                 secondaryRegister[Constants.SecondaryRegisterPositionTwo],
                                 secondaryRegister[Constants.SecondaryRegisterPositionThree]);

                xor1 = primaryRegisterXor ^ mde;
                xor2 = secondaryRegister[Constants.SecondaryRegisterPositionOne] ^ mde;
                xor3 = secondaryRegister[Constants.SecondaryRegisterPositionTwo] ^ mde;
                decodedBit = primaryRegister[Constants.RegisterPositionThree] ^ mde;

                ShiftSecondaryRegister(xor1, xor2, xor3);
                ShiftPrimaryRegister(bitArray[position]);

                if (position >= 6 * 2)
                    output.Enqueue(decodedBit);
            }

            return output;
        }

        /// <summary>
        /// Apskaičiuoja pirmojo XOR reikšmes, pagrindinai naudojant pirmojo registro laukus
        /// </summary>
        /// <param name="_bit1"></param>
        /// <param name="_bit2"></param>
        /// <returns>
        /// Gražina apskaičiuotą true arba false reikšmę
        /// </returns>
        private bool ProcessPrimaryRegister(bool _bit1, bool _bit2)
        {
            bool value = _bit1
                       ^ _bit2
                       ^ primaryRegister[Constants.RegisterPositionOne]
                       ^ primaryRegister[Constants.RegisterPositionTwo]
                       ^ primaryRegister[Constants.RegisterPositionThree];

            return value;
        }

        /// <summary>
        /// Šis metodas paslenka antrojo registro reikšmes į dešinę pusę
        /// </summary>
        /// <param name="_xor1"></param>
        /// <param name="_xor2"></param>
        /// <param name="_xor3"></param>
        private void ShiftSecondaryRegister(bool _xor1, bool _xor2, bool _xor3)
        {
            secondaryRegister[5] = secondaryRegister[4];
            secondaryRegister[4] = _xor3;
            secondaryRegister[3] = secondaryRegister[2];
            secondaryRegister[2] = secondaryRegister[1];
            secondaryRegister[1] = _xor2;
            secondaryRegister[0] = _xor1;
        }
    }
}
