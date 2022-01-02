// .NET Standard 2.0
using System;


namespace EyeTracking
{
    /// <summary>
    /// Struct type for pupil data processing
    /// </summary>
    public struct PupilDataForProcess
    {
        /// <summary>
        /// Initializer for pupil data
        /// </summary>
        /// <param name="diameter">Pupil diameter</param>
        /// <param name="isvalid">Pupil data validity</param>
        public PupilDataForProcess(float diameter, bool isvalid)
        {
            Diameter = diameter;
            IsValid = isvalid;
        }

        /// <summary>
        /// Pupil diameter
        /// </summary>
        public float Diameter;
        /// <summary>
        /// Pupil data validity
        /// </summary>
        public bool IsValid;
    }

    /// <summary>
    /// Struct type for representation of frequency range
    /// </summary>
    public struct FrequencyRange
    {
        /// <summary>
        /// Initializer for freq range
        /// </summary>
        /// <param name="min">Min freq</param>
        /// <param name="max">Max freq</param>
        public FrequencyRange(float min, float max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Min freq
        /// </summary>
        public float Min;
        /// <summary>
        /// Max freq
        /// </summary>
        public float Max;
    }

    /// <summary>
    /// Enum type for states of lfhf computer
    /// </summary>
    public enum LFHFComputeStatus
    {
        /// <summary>
        /// In progress of processing
        /// </summary>
        Processing,
        /// <summary>
        /// Ready for get latest lfhf ratio
        /// </summary>
        Ready,
        /// <summary>
        /// An error was occurred
        /// </summary>
        Error
    }

    /// <summary>
    /// Enum type for window functions
    /// </summary>
    /// <see>https://numerics.mathdotnet.com/api/MathNet.Numerics/Window.htm</see>
    public enum WindowFunction
    {
        /// <summary>
        /// BartlettHann
        /// </summary>
        BartlettHann,
        /// <summary>
        /// Blackman
        /// </summary>
        Blackman,
        /// <summary>
        /// BlackmanHarris
        /// </summary>
        BlackmanHarris,
        /// <summary>
        /// BlackmanNuttall
        /// </summary>
        BlackmanNuttall,
        /// <summary>
        /// Flattop
        /// </summary>
        FlatTop,
        /// <summary>
        /// Hamming
        /// </summary>
        Hamming,
        /// <summary>
        /// HammingPeriodic
        /// </summary>
        /// <remarks>
        /// Recommended for fft purposes than normal Hamming
        /// </remarks>
        HammingPeriodic,
        /// <summary>
        /// Hann
        /// </summary>
        Hann,
        /// <summary>
        /// HannPeriodic
        /// </summary>
        /// <remarks>
        /// Recommended for fft purposes than normal Hann
        /// </remarks>
        HannPeriodic,
        /// <summary>
        /// Lanczos
        /// </summary>
        Lanczos,
        /// <summary>
        /// LanczosPeriodic
        /// </summary>
        /// <remarks>
        /// Recommended for fft purposes than normal Lanczos
        /// </remarks>
        LanczosPeriodic,
        /// <summary>
        /// Nuttall
        /// </summary>
        Nuttall,
        /// <summary>
        /// Rectangle
        /// </summary>
        /// <remarks>
        /// aka Dirichlet
        /// </remarks>
        Rectangle
    }

    /// <summary>
    /// Enum type for states of lerp process
    /// </summary>
    public enum LerpStatus
    {
        /// <summary>
        /// Valid data is existing, no lerp needed
        /// </summary>
        NoInterpolationNecessary,
        /// <summary>
        /// Interpolating invalid data
        /// </summary>
        Interpolating
    }
}