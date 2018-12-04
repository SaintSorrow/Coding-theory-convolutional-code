using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTheory
{
    /// <summary>
    /// klasė skirta simuliuoti nepatikimą kanalą su tam tikra klaidos tikimybe
    /// </summary>
    public class Channel
    {
        public double ErrorProbability { get; set; }
        public int ErrorCount { get; private set; }
        public int[] ErrorPositions { get; private set; }
        private Random Random = new Random();

        public Channel(double _errorProbability)
        {
            ErrorProbability = _errorProbability;
        }

        /// <summary>
        /// Metodas, kuris simuliuoja informacijos siuntimą nepatikimu kanalu
        /// </summary>
        /// <param name="_inputQueue">
        /// Eilė, kurią norime iškraipyti
        /// </param>
        /// <returns>
        /// Grąžina jau išskraipytą informaciją
        /// </returns>
        public Queue<bool> SendData(Queue<bool> _inputQueue)
        {
            Queue<bool> outputQueue = new Queue<bool>();
            Queue<int> errors = new Queue<int>();
            ErrorCount = 0;

            for (int i = 0; i < _inputQueue.Count; i++)
            {
                bool bit = _inputQueue.Peek();

                if (this.SendBit())
                {
                    bit = !bit;
                    errors.Enqueue(i + 1);
                }

                _inputQueue.Enqueue(bit);
                _inputQueue.Dequeue();
                outputQueue.Enqueue(bit);
            }

            ErrorPositions = errors.ToArray();
            return outputQueue;
        }

        /// <summary>
        /// Simuliuojame vieno bito siuntimą kanalu
        /// </summary>
        /// <returns>
        /// true - bitas buvo iškraipytas
        /// false - bitas nebuvo iškraipytas
        /// </returns>
        private bool SendBit()
        {
            if (Random.NextDouble() < ErrorProbability)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
