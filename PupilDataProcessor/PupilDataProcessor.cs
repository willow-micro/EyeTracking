// Target: .NET Standard 2.0

// Default
using System;
// Additional
// Third-party


namespace EyeTracking
{
    /// <summary>
    /// Main Class
    /// </summary>
    /// <remarks>
    /// All floating point variables are float.
    /// </remarks>
    public class PupilDataProcessor
    {
        #region Properties
        /// <summary>
        /// Window size (points) for LFHF fft
        /// </summary>
        public int WindowSize { get; }
        /// <summary>
        /// Hop size (points - overlap) for LFHF fft
        /// </summary>
        public int HopSize { get; }
        /// <summary>
        /// Latest LFHF ratio
        /// </summary>
        public float LatestLFHF { get; private set; }
        /// <summary>
        /// Latest minimum diameter
        /// </summary>
        public float LatestMinDiameter { get; private set; }
        /// <summary>
        /// Latest maximum diameter
        /// </summary>
        public float LatestMaxDiameter { get; private set; }
        /// <summary>
        /// Latest average of all valid diameters
        /// </summary>
        public float LatestAverageValidDiameter { get; private set; }
        #endregion

        #region Fields
        /// <summary>
        /// LFHF Computer instance
        /// </summary>
        private readonly LFHFComputer lfhfComputer;
        /// <summary>
        /// Pupil data buffer
        /// </summary>
        private readonly FIFO<PupilDataForProcess> dataBuffer;
        /// <summary>
        /// Hop count (new data count) for LFHF
        /// </summary>
        private int hopCount;
        /// <summary>
        /// If the data buffer is filled with pupil data once, be true
        /// </summary>
        private bool hasDataBufferFilledOnce;
        /// <summary>
        /// Valid pupil diameter count for average calculation
        /// </summary>
        private long validPupilDiameterCount;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eyeTrackingFrequency">Frequency of eye tracking</param>
        /// <param name="lfRange">LF range</param>
        /// <param name="hfRange">HF range</param>
        /// <param name="lfhfWindowSize">Window size (points) for fft (2^0 to 2^16)</param>
        /// <param name="lfhfHopSize">Hop size (points - overlap) for fft</param>
        /// <param name="windowFunction">Window function for fft</param>
        /// <exception cref="ArgumentOutOfRangeException">The given eyeTrackingFrequency or windowSize is out of range</exception>
        public PupilDataProcessor(int eyeTrackingFrequency, FrequencyRange lfRange, FrequencyRange hfRange, int lfhfWindowSize, int lfhfHopSize, WindowFunction windowFunction)
        {
            // Check if not freq is zero or negative
            if (eyeTrackingFrequency <= 0)
            {
                throw new ArgumentOutOfRangeException("PupilDataProcessor: The given eyeTrackingFrequency is zero or negative");
            }

            // Check if windowSize is power of 2 and within the range
            if ((lfhfWindowSize != 0) && ((lfhfWindowSize & (lfhfWindowSize - 1)) == 0) &&
                (lfhfWindowSize <= (1 << 16)))
            {
                this.WindowSize = lfhfWindowSize;
                this.HopSize = lfhfHopSize;
                this.LatestLFHF = 0.0f;
                this.LatestMinDiameter = float.MaxValue;
                this.LatestMaxDiameter = 0.0f;
                this.LatestAverageValidDiameter = 0.0f;

                this.hopCount = 0;
                this.hasDataBufferFilledOnce = false;
                this.validPupilDiameterCount = 0;

                try
                {
                    this.lfhfComputer = new LFHFComputer(eyeTrackingFrequency, lfRange, hfRange, this.WindowSize, windowFunction);
                }
                catch(InvalidOperationException e)
                {
                    throw new InvalidOperationException(e.Message);
                }
                this.dataBuffer = new FIFO<PupilDataForProcess>(this.WindowSize);
            }
            else
            {
                throw new ArgumentOutOfRangeException("PupilDataProcessor: The given windowSize is out of range");
            }
        }

        /// <summary>
        /// Overloaded constructor, smart version
        /// </summary>
        /// <param name="eyeTrackingFrequency">Frequency of eye tracking</param>
        /// <param name="lfRange">LF range</param>
        /// <param name="hfRange">HF range</param>
        /// <param name="lfhfIdealFrequencyResolution">Ideal frequency resolution for fft. Acutual resolution is same or smaller.</param>
        /// <param name="lfhfComputeSpanInSec">Time span for computing LF/HF ratio.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given eyeTrackingFrequency or lfhfIdealFrequencyResolution is incorrect</exception>
        public PupilDataProcessor(int eyeTrackingFrequency, FrequencyRange lfRange, FrequencyRange hfRange, float lfhfIdealFrequencyResolution, float lfhfComputeSpanInSec)
        {
            // Check if not freq is zero or negative
            if (eyeTrackingFrequency <= 0)
            {
                throw new ArgumentOutOfRangeException("PupilDataProcessor: The given eyeTrackingFrequency is zero or negative");
            }

            // Check if idealFreqRes is bigger than 0
            if (lfhfIdealFrequencyResolution > 0.0f)
            {
                this.WindowSize = (int)(eyeTrackingFrequency / lfhfIdealFrequencyResolution);
                if (this.WindowSize > (1 << 16))
                {
                    throw new ArgumentOutOfRangeException("PupilDataProcessor: The given lfhfIdealFrequencyResolution is too small");
                }
                // Rounding up window size to next power of 2
                this.WindowSize--;
                this.WindowSize |= this.WindowSize >> 1;
                this.WindowSize |= this.WindowSize >> 2;
                this.WindowSize |= this.WindowSize >> 4;
                this.WindowSize |= this.WindowSize >> 8;
                this.WindowSize |= this.WindowSize >> 16;
                this.WindowSize++;
                // End rounding up
                this.HopSize = (int)(Math.Ceiling(lfhfComputeSpanInSec * eyeTrackingFrequency));
                this.LatestLFHF = 0.0f;
                this.LatestMinDiameter = float.MaxValue;
                this.LatestMaxDiameter = 0.0f;
                this.LatestAverageValidDiameter = 0.0f;

                this.hopCount = 0;
                this.hasDataBufferFilledOnce = false;
                this.validPupilDiameterCount = 0;
                try
                {
                    this.lfhfComputer = new LFHFComputer(eyeTrackingFrequency, lfRange, hfRange, this.WindowSize, WindowFunction.HammingPeriodic);
                }
                catch (InvalidOperationException e)
                {
                    throw new InvalidOperationException(e.Message);
                }

                this.dataBuffer = new FIFO<PupilDataForProcess>(this.WindowSize);
            }
            else
            {
                throw new ArgumentOutOfRangeException("PupilDataProcessor: The given lfhfIdealFrequencyResolution is zero or negative");
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Update with an pupil data
        /// </summary>
        /// <param name="pupilData">a new pupil data</param>
        /// <returns>
        /// [LFHFComputeStatus] The status after the new data was added
        /// </returns>
        /// <example>
        /// This shows how to use this method:
        /// <code>
        /// private void AMethodCalledEveryCycle(float leftPD, float rightPD, bool validity)
        /// {
        ///     PupilDataForProcess newData;
        ///     newData.PupilDiameter = (leftPD + rightPD) / 2.0f;
        ///     newData.Validity = validity;
        ///     if(this.processor.UpdateWith(newData) == LFHFComputeStatus.Ready)
        ///     {
        ///         float lfhf = this.processor.LatestLFHF;
        ///         Debug.Print($"LFHF: {lfhf}");
        ///     }
        /// }
        /// </code>
        /// </example>
        public LFHFComputeStatus UpdateWith(PupilDataForProcess pupilData)
        {
            if (pupilData.IsValid)
            {
                // Min
                if (this.LatestMinDiameter > pupilData.Diameter)
                {
                    this.LatestMinDiameter = pupilData.Diameter;
                }

                // Max
                if (this.LatestMaxDiameter < pupilData.Diameter)
                {
                    this.LatestMaxDiameter = pupilData.Diameter;
                }

                // Average
                this.LatestAverageValidDiameter += (pupilData.Diameter - this.LatestAverageValidDiameter) / (this.validPupilDiameterCount + 1);
                validPupilDiameterCount++;
            }

            // LF/HF
            LFHFComputeStatus state = LFHFComputeStatus.Processing;

            if (!this.hasDataBufferFilledOnce)
            {
                // Until the buffer is filled with pupil data
                if (this.dataBuffer.GetAvailableDataCount() < this.WindowSize)
                {
                    this.dataBuffer.PutData(pupilData);
                }
                else
                {
                    this.hasDataBufferFilledOnce = true;    // Come here once
                    // First lfhf value
                    this.LatestLFHF = this.lfhfComputer.ComputeLFHFFrom(this.dataBuffer.PeekAllDataOrdered());
                    state = LFHFComputeStatus.Ready;
                }
            }
            else
            {
                // After the buffer is filled with data once
                if (this.hopCount < this.HopSize)
                {
                    this.dataBuffer.PutData(pupilData);
                    this.hopCount++;
                }
                else
                {
                    this.LatestLFHF = this.lfhfComputer.ComputeLFHFFrom(this.dataBuffer.PeekAllDataOrdered());
                    state = LFHFComputeStatus.Ready;
                    this.hopCount = 0;
                }
            }
            return state;
        }
        #endregion
    }
}
