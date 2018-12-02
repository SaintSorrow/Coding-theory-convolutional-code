using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTheory
{
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

        private bool SendBit()
        {
            return (ErrorProbability > Random.NextDouble()) ? true : false;
        }
    }
}
