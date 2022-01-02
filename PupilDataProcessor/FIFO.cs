// .NET Standard 2.0
using System;


namespace EyeTracking
{
    /// <summary>
    /// A FIFO Buffer Implementation for Visual C# using Generics.
    /// </summary>
    class FIFO<T>
        where T : struct
    {
        /// <summary>
        /// Buffer
        /// </summary>
        private readonly T[] buffer;
        /// <summary>
        /// Current Get Index
        /// </summary>
        private int getIndex;
        /// <summary>
        /// Current Put Index
        /// </summary>
        private int putIndex;
        /// <summary>
        /// Current available data count
        /// </summary>
        private int availableCount;
        /// <summary>
        /// When the put index reached the length of the buffer, it will be true
        /// </summary>
        private bool hasPutIndexReachedMax;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="bufferSize">Buffer Size</param>
        public FIFO(int bufferSize)
        {
            this.buffer = new T[bufferSize];
            this.getIndex = 0;
            this.putIndex = 0;
            this.availableCount = 0;
            this.hasPutIndexReachedMax = false;
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="previousFIFO"></param>
        public FIFO(FIFO<T> previousFIFO)
        {
            this.buffer = new T[previousFIFO.buffer.Length];
            Array.Copy(previousFIFO.buffer, this.buffer, previousFIFO.buffer.Length);
            this.getIndex = previousFIFO.getIndex;
            this.putIndex = previousFIFO.putIndex;
            this.availableCount = previousFIFO.availableCount;
            this.hasPutIndexReachedMax = previousFIFO.hasPutIndexReachedMax;
        }

        /// <summary>
        /// Clear the buffer
        /// </summary>
        /// <remarks>
        /// Actually, it only initializes indexes.
        /// </remarks>
        public void Clear()
        {
            this.getIndex = 0;
            this.putIndex = 0;
            this.availableCount = 0;
            this.hasPutIndexReachedMax = false;
        }

        /// <summary>
        /// Get Buffer Size specified in the constructor
        /// </summary>
        /// <returns>Buffer size</returns>
        public int GetBufferSize()
        {
            return this.buffer.Length;
        }

        /// <summary>
        /// Get a data from the buffer
        /// </summary>
        /// <returns>Generic Data</returns>
        public T GetData()
        {
            if (this.availableCount <= 0)
            {
                // If the buffer is empty
                return default;
            }

            T data;
            data = this.buffer[this.getIndex++];
            if (this.getIndex >= this.buffer.Length)
            {
                this.getIndex = 0;
            }
            this.availableCount--;

            return data;
        }

        /// <summary>
        /// Get a data from the buffer (Don't touch indexes)
        /// </summary>
        /// <remarks>
        /// If you call this twice, same data will be delivered.
        /// </remarks>
        /// <returns>Generic Data</returns>
        public T PeekData()
        {
            if (this.availableCount <= 0)
            {
                // If the buffer is empty
                return default;
            }
            T data;
            data = this.buffer[this.getIndex];
            return data;
        }

        /// <summary>
        /// Put a data to the buffer
        /// </summary>
        /// <remarks>
        /// When the buffer is full, it OVERWRITES existing data.
        /// </remarks>
        /// <param name="data">Generic Data</param>
        public void PutData(T data)
        {
            this.buffer[this.putIndex++] = data;
            if (this.putIndex >= this.buffer.Length)
            {
                this.putIndex = 0;
                this.hasPutIndexReachedMax = true;
            }
            if (this.availableCount < this.buffer.Length)
            {
                this.availableCount++;
            }
        }

        /// <summary>
        /// Get Available Data Count
        /// </summary>
        /// <returns>Data Count</returns>
        public int GetAvailableDataCount()
        {
            return this.availableCount;
        }

        /// <summary>
        /// Get all data in the buffer, Mixed-up
        /// </summary>
        /// <returns>Data Array</returns>
        public T[] PeekAllDataMixed()
        {
            T[] allData = new T[this.buffer.Length];
            Array.Copy(this.buffer, allData, this.buffer.Length);
            return allData;
        }

        /// <summary>
        /// Get all data in the buffer, Ordered from oldest to newest
        /// </summary>
        /// <returns>Data Array</returns>
        public T[] PeekAllDataOrdered()
        {
            T[] allData = new T[this.buffer.Length];
            if (this.hasPutIndexReachedMax)
            {
                Array.Copy(this.buffer, this.putIndex, allData, 0, this.buffer.Length - this.putIndex);
                if (this.putIndex > 0)
                {
                    Array.Copy(this.buffer, 0, allData, this.buffer.Length - this.putIndex, this.putIndex);
                }
            }
            else
            {
                // Index 0 is the oldest
                Array.Copy(this.buffer, allData, this.buffer.Length);
            }
            return allData;
        }

        /// <summary>
        /// Operator overload for "+=" operator
        /// </summary>
        /// <param name="fifo">Destination FIFO</param>
        /// <param name="data">Put data(Generic)</param>
        /// <returns>New FIFO</returns>
        public static FIFO<T> operator +(FIFO<T> fifo, T data)
        {
            FIFO<T> newFIFO = new FIFO<T>(fifo);
            newFIFO.PutData(data);
            return newFIFO;
        }

    }
}
