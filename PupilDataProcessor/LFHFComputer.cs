// .NET Standard 2.0
using System;
using System.Numerics;
// Third-party
using MathNet.Numerics;


namespace EyeTracking
{
    /// <summary>
    /// A Class for computing lfhf ratio from pupil data array
    /// </summary>
    /// <remarks>
    /// Use "power spectrum" ratio as result
    /// </remarks>
    public class LFHFComputer
    {
        #region Properties
        /// <summary>
        /// Frequency range of lf
        /// </summary>
        private FrequencyRange LFRange { get; }
        /// <summary>
        /// Frequency range of hf
        /// </summary>
        private FrequencyRange HFRange { get; }
        /// <summary>
        /// Window size
        /// </summary>
        private int WindowSize { get; }
        /// <summary>
        /// Frequency resolution
        /// </summary>
        private float FrequencyResolution { get; }
        #endregion

        #region Fields
        /// <summary>
        /// Window for applying
        /// </summary>
        private readonly double[] window;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="processFrequency">[int] Frequency for processing pupil data</param>
        /// <param name="lfRange">[FrequencyRange] Frequency range of LF</param>
        /// <param name="hfRange">[FrequencyRange] Frequency range of HF</param>
        /// <param name="windowSize">[int] Window size, Length of pupil data array. (2^0 to 2^16)</param>
        /// <exception cref="ArgumentOutOfRangeException">The given processFrequency or windowSize is incorrect</exception>
        /// <exception cref="InvalidOperationException">LFHFComputer: The given LFRange.Min is bigger than Frequency Resolution (processFrequency / WindowSize)</exception>
        public LFHFComputer(int processFrequency, FrequencyRange lfRange, FrequencyRange hfRange, int windowSize)
        {
            // Check if not freq is zero or negative
            if (processFrequency <= 0)
            {
                throw new ArgumentOutOfRangeException("LFHFComputer: The given processFrequency is zero or negative");
            }

            // Check if windowSize is power of 2 and within the range
            if ((windowSize != 0) && ((windowSize & (windowSize - 1)) == 0) &&
                (windowSize <= (1 << 16)))
            {
                this.LFRange = lfRange;
                this.HFRange = hfRange;
                this.WindowSize = windowSize;
                this.window = Window.HammingPeriodic(this.WindowSize);
                this.FrequencyResolution = (float)(processFrequency) / this.WindowSize;
                if (this.FrequencyResolution > lfRange.Min)
                {
                    throw new InvalidOperationException("LFHFComputer: The given LFRange.Min is bigger than Frequency Resolution (processFrequency / WindowSize)");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("LFHFComputer: The given windowSize is not power of 2");
            }
        }

        /// <summary>
        /// Overloaded constructor for select window function.
        /// </summary>
        /// <param name="processFrequency">[int] Frequency for processing pupil data</param>
        /// <param name="lfRange">[FrequencyRange] Frequency range of LF</param>
        /// <param name="hfRange">[FrequencyRange] Frequency range of HF</param>
        /// <param name="windowSize">[int] Window size, Length of pupil data array. (2^0 to 2^16)</param>
        /// <param name="windowFunction">[WindowFunction] Window Function</param>
        /// <exception cref="ArgumentOutOfRangeException">The given processFrequency or windowSize is incorrect</exception>
        /// <exception cref="InvalidOperationException">LFHFComputer: The given LFRange.Min is bigger than Frequency Resolution (processFrequency / WindowSize)</exception>
        public LFHFComputer(int processFrequency, FrequencyRange lfRange, FrequencyRange hfRange, int windowSize, WindowFunction windowFunction)
        {
            // Check if not freq is zero or negative
            if (processFrequency <= 0)
            {
                throw new ArgumentOutOfRangeException("LFHFComputer: The given processFrequency is zero or negative");
            }

            // Check if windowSize is power of 2 and within the range
            if ((windowSize != 0) && ((windowSize & (windowSize - 1)) == 0) &&
                (windowSize <= (1 << 16)))
            {
                this.LFRange = lfRange;
                this.HFRange = hfRange;
                this.WindowSize = windowSize;
                switch (windowFunction)
                {
                    case WindowFunction.BartlettHann:
                        this.window = Window.BartlettHann(this.WindowSize);
                        break;
                    case WindowFunction.Blackman:
                        this.window = Window.Blackman(this.WindowSize);
                        break;
                    case WindowFunction.BlackmanHarris:
                        this.window = Window.BlackmanHarris(this.WindowSize);
                        break;
                    case WindowFunction.BlackmanNuttall:
                        this.window = Window.BlackmanNuttall(this.WindowSize);
                        break;
                    case WindowFunction.FlatTop:
                        this.window = Window.FlatTop(this.WindowSize);
                        break;
                    case WindowFunction.Hamming:
                        this.window = Window.Hamming(this.WindowSize);
                        break;
                    case WindowFunction.HammingPeriodic:
                        this.window = Window.HammingPeriodic(this.WindowSize);
                        break;
                    case WindowFunction.Hann:
                        this.window = Window.Hann(this.WindowSize);
                        break;
                    case WindowFunction.HannPeriodic:
                        this.window = Window.HannPeriodic(this.WindowSize);
                        break;
                    case WindowFunction.Lanczos:
                        this.window = Window.Lanczos(this.WindowSize);
                        break;
                    case WindowFunction.LanczosPeriodic:
                        this.window = Window.LanczosPeriodic(this.WindowSize);
                        break;
                    case WindowFunction.Nuttall:
                        this.window = Window.Nuttall(this.WindowSize);
                        break;
                    case WindowFunction.Rectangle:
                        this.window = Window.Dirichlet(this.WindowSize);
                        break;
                    default:
                        this.window = Window.HammingPeriodic(this.WindowSize);
                        break;
                }
                this.FrequencyResolution = (float)(processFrequency) / this.WindowSize;
                if (this.FrequencyResolution > lfRange.Min)
                {
                    throw new InvalidOperationException("LFHFComputer: The given LFRange.Min is bigger than Frequency Resolution (processFrequency / WindowSize)");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("LFHFComputer: The given windowSize is not power of 2");
            }
        }
        #endregion

        #region Public methods     
        /// <summary>
        /// Compute LF/HF ratio from the given pupil data array
        /// </summary>
        /// <remarks>
        /// Use the given average if the first or last diameter is invalid, so lighter than the other one.
        /// </remarks>
        /// <param name="pupilDataArray">[PupilDataForProcess[]] Pupil data array</param>
        /// <param name="pupilDiameterAverage">[float] Average of valid pupil diameters</param>
        /// <returns>[float] LF/HF ratio</returns>
        /// <exception cref="ArgumentOutOfRangeException">Pupil data array is too long or too short</exception>
        public float ComputeLFHFFrom(PupilDataForProcess[] pupilDataArray, float pupilDiameterAverage)
        {
            if (pupilDataArray.Length != this.WindowSize)
            {
                throw new ArgumentOutOfRangeException("ComputeLFHFFrom: The given pupil data array is too long or too short");
            }

            // Interpolate pupil diameters
            float[] pupilDiameterArray = this.LerpPupilDiameter(pupilDataArray, pupilDiameterAverage);

            // Windowing
            this.ApplyWindow(pupilDiameterArray);

            // Fourier
            Complex[] fftResultArray = this.ExecuteFFT(pupilDiameterArray);

            // LF/HF
            float lfSum = 0.0f;
            float hfSum = 0.0f;
            for (int i = 0; i < fftResultArray.Length; i++)
            {
                float spectrumFrequency = i * this.FrequencyResolution;
                if (this.LFRange.Min <= spectrumFrequency && spectrumFrequency <= this.LFRange.Max)
                {
                    // Add power spectrum (ps = magnitude^2 = sqrt(a^2+b^2)^2 = a^2+b^2)
                    lfSum += (float)(fftResultArray[i].Real * fftResultArray[i].Real + fftResultArray[i].Imaginary * fftResultArray[i].Imaginary);
                }
                if (this.HFRange.Min <= spectrumFrequency && spectrumFrequency <= this.HFRange.Max)
                {
                    // Add power spectrum (ps = magnitude^2 = sqrt(a^2+b^2)^2 = a^2+b^2)
                    hfSum += (float)(fftResultArray[i].Real * fftResultArray[i].Real + fftResultArray[i].Imaginary * fftResultArray[i].Imaginary);
                }
            }

            return lfSum / hfSum;
        }

        /// <summary>
        /// [Overload] Compute LF/HF ratio from the given pupil data array
        /// </summary>
        /// <remarks>
        /// Calculate the average of all valid pupil diameters automatically.
        /// </remarks>
        /// <param name="pupilDataArray">[PupilDataForProcess[]] Pupil data array</param>
        /// <returns>[float] LF/HF ratio</returns>
        /// <exception cref="ArgumentOutOfRangeException">Pupil data array is too long or too short</exception>
        public float ComputeLFHFFrom(PupilDataForProcess[] pupilDataArray)
        {
            if (pupilDataArray.Length != this.WindowSize)
            {
                throw new ArgumentOutOfRangeException("ComputeLFHFFrom: The given pupil data array is too long or too short");
            }

            // Calculate the average of pupil diameters
            float pupilDiameterAverage = 0.0f;
            int validPupilDiameterCount = 0;
            for (int i = 0; i < this.WindowSize; i++)
            {
                if (pupilDataArray[i].IsValid)
                {
                    pupilDiameterAverage += (pupilDataArray[i].Diameter - pupilDiameterAverage) / (validPupilDiameterCount + 1);
                    validPupilDiameterCount++;
                }
            }

            return this.ComputeLFHFFrom(pupilDataArray, pupilDiameterAverage);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Linear Interpolate pupil diameters, if necessary.
        /// If the first or last data is invalid (need for interpolate), replace it by the given average of valid diameters.
        /// </summary>
        /// <param name="pupilDataArray">[PupilDataForProcess[]] Pupil data array</param>
        /// <param name="validAverage">[float] Average of all valid pupil dimeters</param>
        /// <returns>[float[]] Interpolated pupil diameters</returns>
        /// <exception cref="ArgumentOutOfRangeException">Pupil data array is too long or too short</exception>
        private float[] LerpPupilDiameter(PupilDataForProcess[] pupilDataArray, float validAverage)
        {
            if (pupilDataArray.Length != this.WindowSize)
            {
                throw new ArgumentOutOfRangeException("LerpPupilDiameter: The given pupil data array is too long or too short");
            }

            float[] floatArray = new float[this.WindowSize];
            LerpStatus state = LerpStatus.NoInterpolationNecessary;
            int lerpBegunIndex = 0;
            int lerpCount = 0;  // Count for data needed to lerp in a row

            // Check all pupil data in the array
            for (int i = 0; i < this.WindowSize; i++)
            {
                // Switch by lerp state
                switch (state)
                {
                    case LerpStatus.NoInterpolationNecessary:
                        if (pupilDataArray[i].IsValid)
                        {
                            // Previous: valid, current: valid
                            // Set the diameter, go next
                            floatArray[i] = pupilDataArray[i].Diameter;
                        }
                        else
                        {
                            if (i != 0)
                            {
                                // Previous: valid, current: invalid
                                // Begin interpolation from here
                                lerpBegunIndex = i;
                                lerpCount = 1;
                                state = LerpStatus.Interpolating;
                            }
                            else
                            {
                                // Previous: none, current (is the first): invalid
                                // Replace the first data by average
                                floatArray[i] = validAverage;
                                state = LerpStatus.NoInterpolationNecessary;
                            }
                        }
                        break;
                    case LerpStatus.Interpolating:
                        if (pupilDataArray[i].IsValid)
                        {
                            // Previous: invalid, current: valid
                            // End interpolation
                            float before = pupilDataArray[lerpBegunIndex - 1].Diameter; // the last valid diamter before
                            float after = pupilDataArray[i].Diameter;                   // the first valid diameter after
                            float delta = (after - before) / (lerpCount + 1);
                            int lerpNumber = 1;
                            // Invalid data in a row
                            for (int li = lerpBegunIndex; li < lerpBegunIndex + lerpCount; li++)
                            {
                                floatArray[li] = before + (lerpNumber * delta);
                                lerpNumber++;
                            }
                            // Reset variables
                            lerpBegunIndex = 0;
                            lerpCount = 0;
                            state = LerpStatus.NoInterpolationNecessary;

                            // Set valid diameter at current
                            floatArray[i] = pupilDataArray[i].Diameter;
                        }
                        else
                        {
                            if (i < this.WindowSize - 1)
                            {
                                // Previous: invalid, current: invalid
                                // Count data for interpolation
                                lerpCount++;
                            }
                            else
                            {
                                // Previous: invalid, current: invalid but it's the last
                                // If the last data is invalid when interpolating
                                // Replace the last data by average and force interpolation
                                // End interpolation
                                float before = pupilDataArray[lerpBegunIndex - 1].Diameter; // the last valid diamter before
                                float after = validAverage;                                 // the first valid diameter is not existing, use average instead
                                float delta = (after - before) / (lerpCount + 1);
                                int lerpNumber = 1;
                                // Invalid data in a row
                                for (int li = lerpBegunIndex; li < lerpBegunIndex + lerpCount; li++)
                                {
                                    floatArray[li] = before + (lerpNumber * delta);
                                    lerpNumber++;
                                }

                                // Set average diameter at current as last data
                                floatArray[i] = validAverage;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return floatArray;
        }

        /// <summary>
        /// Apply specified window in the constructor.
        /// </summary>
        /// <param name="floatArray">Data for windowing</param>
        /// <exception cref="ArgumentOutOfRangeException">Array is too long or too short</exception>
        private void ApplyWindow(float[] floatArray)
        {
            if (floatArray.Length != this.WindowSize)
            {
                throw new ArgumentOutOfRangeException("ApplyWindow: The given array is too long or too short");
            }

            // Apply window
            for (int i = 0; i < this.WindowSize; i++)
            {
                floatArray[i] = floatArray[i] * (float)(this.window[i]);
            }
        }

        /// <summary>
        /// Execute FFT
        /// </summary>
        /// <param name="floatArray">Data for convert</param>
        /// <returns>[Complex[]] Array of fourier spectrums</returns>
        /// <exception cref="ArgumentOutOfRangeException">Array is too long or too short</exception>
        private Complex[] ExecuteFFT(float[] floatArray)
        {
            if (floatArray.Length != this.WindowSize)
            {
                throw new ArgumentOutOfRangeException("FFT: The given array is too long or too short");
            }

            // Prepare complex array
            Complex[] complexArray = new Complex[this.WindowSize];
            for (int i = 0; i < this.WindowSize; i++)
            {
                complexArray[i] = (Complex)(floatArray[i]);     // Equivalent to "new Complex(floatArray[i], 0)"
            }

            // FFT (Normalize with 1/N scaling)
            MathNet.Numerics.IntegralTransforms.Fourier.Forward(complexArray, MathNet.Numerics.IntegralTransforms.FourierOptions.AsymmetricScaling);

            return complexArray;
        }
        #endregion
    }
}
