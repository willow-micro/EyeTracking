// Target: .NET Standard 2.0
// Default
using System;
// Additional
using System.Numerics;
// Third-party
using Tobii.Research;


namespace EyeTracking
{
    /// <summary>
    /// A driver for Tobii screen-based eye trackers
    /// </summary>
    public sealed class TobiiSBEyeTracker
    {
        #region Fields
        /// <summary>
        /// Tobii.Research eye tracker object
        /// </summary>
        private readonly IEyeTracker device;
        /// <summary>
        /// Screen width
        /// </summary>
        private readonly double screenWidth;
        /// <summary>
        /// Screen height
        /// </summary>
        private readonly double screenHeight;
        /// <summary>
        /// Horizontal pixel pitch
        /// </summary>
        private readonly double horizontalPixelPitch;
        /// <summary>
        /// Vertical pixel pitch
        /// </summary>
        private readonly double verticalPixelPitch;
        /// <summary>
        /// Gaze angular velocity calculation type
        /// </summary>
        private VelocityCalcType velocityCalcType;
        /// <summary>
        /// Angular velocity threshold [rad/s] for classifying eye movement, fixation or saccade
        /// </summary>
        private int fixationAngularVelocityThreshold;
        /// <summary>
        /// [Left Eye] Previous gaze point
        /// </summary>
        private GazePoint prevLeftGazePoint;
        /// <summary>
        /// [Left Eye] Previous gaze origin
        /// </summary>
        private GazeOrigin prevLeftGazeOrigin;
        /// <summary>
        /// [Right Eye] Previous gaze point
        /// </summary>
        private GazePoint prevRightGazePoint;
        /// <summary>
        /// [Right Eye] Previous gaze origin
        /// </summary>
        private GazeOrigin prevRightGazeOrigin;
        /// <summary>
        /// Previous System time stamp [us]
        /// </summary>
        private long prevSystemTimeStamp;
        /// <summary>
        /// [Left Eye] Not a saccade time duration in ms. For fixation detection.
        /// </summary>
        private int leftEyeNotASaccadeDurationMs;
        /// <summary>
        /// [Right Eye] Not a saccade time duration in ms. For fixation detection.
        /// </summary>
        private int rightEyeNotASaccadeDurationMs;
        /// <summary>
        /// Not a saccade time duration threshold in ms. For fixation detection.
        /// </summary>
        private int notASaccadeDurationThresholdMs;
        /// <summary>
        /// Check if the eye tracking is started or not
        /// </summary>
        private bool isEyeTrackingStarted;
        #endregion

        #region Delegates
        /// <summary>
        /// Delegate for the event <see cref="E:EyeTracking.TobiiSBEyeTracker.OnGazeData"/>
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments <seealso cref="EyeTracking.OnGazeDataEventArgs"/></param>
        public delegate void OnGazeDataEventHandler(object sender, OnGazeDataEventArgs e);
        #endregion

        #region Events
        /// <summary>
        /// EventHandler for make gaze data available from user
        /// </summary>
        /// <remarks>
        /// If you specify a screen dimension in the constructor, that changes max values for gaze positions.
        /// </remarks>
        public event OnGazeDataEventHandler OnGazeData;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor. Use the first eye tracker in the <c>Tobii.Research.EyeTrackerCollection</c>.
        /// </summary>
        /// <param name="screenWidth">Screen width in pixels. (Max value of gaze x positions in <see cref="E:EyeTracking.TobiiSBEyeTracker.OnGazeData"/>)</param>
        /// <param name="screenHeight">Screen height in pixels. (Max value of gaze y positions in <see cref="E:EyeTracking.TobiiSBEyeTracker.OnGazeData"/>)</param>
        /// <param name="vCalcType">Calculation type for gaze angular velocity</param>
        /// <param name="fixationVelocityThresh">Angular velocity threshold [rad/s] for classifying eye movements, saccade or not a saccade</param>
        /// <param name="fixationDurationThresh">Time duration threshold [ms] for classifying eye movements, not a saccade or fixation</param>
        /// <exception cref="ArgumentOutOfRangeException">Provided screen dimension is invalid</exception>
        /// <exception cref="InvalidOperationException">Eye tracker(s) not found</exception>
        public TobiiSBEyeTracker(double screenWidth, double screenHeight, VelocityCalcType vCalcType = VelocityCalcType.UCSGazeVector, int fixationVelocityThresh = 30, int fixationDurationThresh = 150)
        {
            velocityCalcType = vCalcType;
            fixationAngularVelocityThreshold = fixationVelocityThresh;
            leftEyeNotASaccadeDurationMs = 0;
            rightEyeNotASaccadeDurationMs = 0;
            notASaccadeDurationThresholdMs = fixationDurationThresh;
            isEyeTrackingStarted = false;

            EyeTrackerCollection eyeTrackers = EyeTrackingOperations.FindAllEyeTrackers();
            
            if (screenWidth <= 0 || screenHeight <= 0)
            {
                throw new ArgumentOutOfRangeException("Provided screen dimension is invalid.");
            }
            else if (eyeTrackers.Count > 0)
            {
                device = eyeTrackers[0];
                this.screenWidth = screenWidth;
                this.screenHeight = screenHeight;
                horizontalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Width / screenWidth);
                verticalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Height / screenHeight);
            }
            else
            {
                throw new InvalidOperationException("Eye Tracker(s) not found.");
            }
        }

        /// <summary>
        /// Overloaded constructor. Use the eye tracker which has <c>identificationString</c> for <c>identificationType</c> in the <c>Tobii.Research.EyeTrackerCollection</c>.
        /// </summary>
        /// <param name="identificationType">The way to specify the eye tracker. <seealso cref="T:EyeTracking.EyeTrackerIdentification"/></param>
        /// <param name="identificationString">The string for specify the eye tracker.</param>
        /// <param name="screenWidth">Screen width in pixels. (Max value of gaze x positions in <see cref="E:EyeTracking.TobiiSBEyeTracker.OnGazeData"/>)</param>
        /// <param name="screenHeight">Screen height in pixels. (Max value of gaze y positions in <see cref="E:EyeTracking.TobiiSBEyeTracker.OnGazeData"/>)</param>
        /// <param name="vCalcType">Calculation type for gaze angular velocity</param>
        /// <param name="fixationVelocityThresh">Angular velocity threshold [rad/s] for classifying eye movements, saccade or not a saccade</param>
        /// <param name="fixationDurationThresh">Time duration threshold [ms] for classifying eye movements, not a saccade or fixation</param>
        /// <exception cref="ArgumentOutOfRangeException">Provided screen dimension is invalid</exception>
        /// <exception cref="InvalidOperationException">Eye Tracker(s) not found</exception>
        public TobiiSBEyeTracker(EyeTrackerIdentification identificationType, string identificationString, double screenWidth, double screenHeight, VelocityCalcType vCalcType = VelocityCalcType.UCSGazeVector, int fixationVelocityThresh = 30, int fixationDurationThresh = 150)
        {
            velocityCalcType = vCalcType;
            fixationAngularVelocityThreshold = fixationVelocityThresh;
            leftEyeNotASaccadeDurationMs = 0;
            rightEyeNotASaccadeDurationMs = 0;
            notASaccadeDurationThresholdMs = fixationDurationThresh;
            isEyeTrackingStarted = false;

            EyeTrackerCollection eyeTrackers = EyeTrackingOperations.FindAllEyeTrackers();

            if (screenWidth <= 0 || screenHeight <= 0)
            {
                throw new ArgumentOutOfRangeException("Provided screen dimension is invalid.");
            }
            else if (eyeTrackers.Count > 0)
            {
                bool initialized = false;
                switch (identificationType)
                {
                    case EyeTrackerIdentification.DeviceName:
                        foreach (IEyeTracker eyeTracker in eyeTrackers)
                        {
                            if (eyeTracker.DeviceName == identificationString)
                            {
                                device = eyeTracker;
                                this.screenWidth = screenWidth;
                                this.screenHeight = screenHeight;
                                horizontalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Width / screenWidth);
                                verticalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Height / screenHeight);
                                initialized = true;
                                break;
                            }
                        }
                        if (!initialized)
                        {
                            throw new InvalidOperationException($"Eye Tracker not found with the Device Name: {identificationString}");
                        }
                        break;
                    case EyeTrackerIdentification.SerialNumber:
                        foreach (IEyeTracker eyeTracker in eyeTrackers)
                        {
                            if (eyeTracker.SerialNumber == identificationString)
                            {
                                device = eyeTracker;
                                this.screenWidth = screenWidth;
                                this.screenHeight = screenHeight;
                                horizontalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Width / screenWidth);
                                verticalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Height / screenHeight);
                                initialized = true;
                                break;
                            }
                        }
                        if (!initialized)
                        {
                            throw new InvalidOperationException($"Eye Tracker not found with the Serial Number: {identificationString}");
                        }
                        break;
                    case EyeTrackerIdentification.Model:
                        foreach (IEyeTracker eyeTracker in eyeTrackers)
                        {
                            if (eyeTracker.Model == identificationString)
                            {
                                device = eyeTracker;
                                this.screenWidth = screenWidth;
                                this.screenHeight = screenHeight;
                                horizontalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Width / screenWidth);
                                verticalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Height / screenHeight);
                                initialized = true;
                                break;
                            }
                        }
                        if (!initialized)
                        {
                            throw new InvalidOperationException($"Eye Tracker not found with the Model: {identificationString}");
                        }
                        break;
                    case EyeTrackerIdentification.FirmwareVersion:
                        foreach (IEyeTracker eyeTracker in eyeTrackers)
                        {
                            if (eyeTracker.FirmwareVersion == identificationString)
                            {
                                device = eyeTracker;
                                this.screenWidth = screenWidth;
                                this.screenHeight = screenHeight;
                                horizontalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Width / screenWidth);
                                verticalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Height / screenHeight);
                                initialized = true;
                                break;
                            }
                        }
                        if (!initialized)
                        {
                            throw new InvalidOperationException($"Eye Tracker not found with the Firmware Version: {identificationString}");
                        }
                        break;
                    case EyeTrackerIdentification.RuntimeVersion:
                        foreach (IEyeTracker eyeTracker in eyeTrackers)
                        {
                            if (eyeTracker.RuntimeVersion == identificationString)
                            {
                                device = eyeTracker;
                                this.screenWidth = screenWidth;
                                this.screenHeight = screenHeight;
                                horizontalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Width / screenWidth);
                                verticalPixelPitch = (double)(eyeTrackers[0].GetDisplayArea().Height / screenHeight);
                                initialized = true;
                                break;
                            }
                        }
                        if (!initialized)
                        {
                            throw new InvalidOperationException($"Eye Tracker not found with the Runtime Version: {identificationString}");
                        }
                        break;
                }
            }
            else
            {
                throw new InvalidOperationException("Eye Tracker(s) not found.");
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Get the Device Name for the eye tracker.
        /// </summary>
        /// <returns>Device Name (if there is no device, returns null)</returns>
        public string GetDeviceName()
        {
            return device?.DeviceName;
        }

        /// <summary>
        /// Get the Serial Number for the eye tracker.
        /// </summary>
        /// <returns>Serial Number (if there is no device, returns null)</returns>
        public string GetSerialNumber()
        {
            return device?.SerialNumber;
        }

        /// <summary>
        /// Get the Model for the eye tracker.
        /// </summary>
        /// <returns>Model (if there is no device, returns null)</returns>
        public string GetModel()
        {
            return device?.Model;
        }

        /// <summary>
        /// Get the Firmware Version for the eye tracker.
        /// </summary>
        /// <returns>Firmware Version (if there is no device, returns null)</returns>
        public string GetFirmwareVersion()
        {
            return device?.FirmwareVersion;
        }

        /// <summary>
        /// Get the Runtime Version for the eye tracker.
        /// </summary>
        /// <returns>Runtime Version (if there is no device, returns null)</returns>
        public string GetRuntimeVersion()
        {
            return device?.RuntimeVersion;
        }

        /// <summary>
        /// Get the display area of the eye tracker.
        /// </summary>
        /// <returns>Tobii.Research.DisplayArea (if there is no device, returns null)</returns>
        public DisplayArea GetDisplayArea()
        {
            return device?.GetDisplayArea();
        }

        /// <summary>
        /// Get the frequency of the eye tracker.
        /// </summary>
        /// <returns>float (if there is no device, returns null)</returns>
        public float GetFrequency()
        {
            return (float)(device?.GetGazeOutputFrequency());
        }

        /// <summary>
        /// Get the screen width in pixels (same as constructor's screenWidth)
        /// </summary>
        /// <returns>Screen width in pixels</returns>
        public double GetScreenWidthInPixels()
        {
            return screenWidth;
        }

        /// <summary>
        /// Get the screen height in pixels (same as constructor's screenHeight)
        /// </summary>
        /// <returns>Screen height in pixels</returns>
        public double GetScreenHeightInPixels()
        {
            return screenHeight;
        }

        /// <summary>
        /// Get the screen width in millimeters
        /// </summary>
        /// <returns>Screen width in millimeters (if there is no eye tracker, returns NaN)</returns>
        public double GetScreenWidthInMillimeters()
        {
            if (device == null)
            {
                return double.NaN;
            }
            return device.GetDisplayArea().Width;
        }

        /// <summary>
        /// Get the screen height in millimeters
        /// </summary>
        /// <returns>Screen height in millimeters (if there is no eye tracker, returns NaN)</returns>
        public double GetScreenHeightInMillimeters()
        {
            if (device == null)
            {
                return double.NaN;
            }
            return device.GetDisplayArea().Height;
        }

        /// <summary>
        /// Calculate the pixel pitch. To use this method, you must specify a screen dimension in the constructor.
        /// </summary>
        /// <param name="calcHorizontalPitch">If false, calculate a vertical pixel pitch</param>
        /// <returns>A horizontal or vertical pixel pitch or NaN</returns>
        public double CalcPixelPitch(bool calcHorizontalPitch = true)
        {
            if (device == null)
            {
                return double.NaN;
            }
            if (calcHorizontalPitch)
            {
                return horizontalPixelPitch;
            }
            else
            {
                return verticalPixelPitch;
            }
        }

        /// <summary>
        /// Calculate pixels from millimeters. To use this method, you must specify a screen dimension in the constructor.
        /// </summary>
        /// <param name="millimeters">Length in millimeters</param>
        /// <param name="useHorizontalPitch">if false, use vertical pixel pitch</param>
        /// <returns>pixels (based on the dimensions set in the constructor) or NaN</returns>
        public double CalcPixelsFromMillimeters(double millimeters, bool useHorizontalPitch = true)
        {
            if (device == null)
            {
                return double.NaN;
            }

            if (useHorizontalPitch)
            {
                return millimeters / horizontalPixelPitch;
            }
            else
            {
                return millimeters / verticalPixelPitch;
            }
        }

        /// <summary>
        /// Calculate millimeters from pixels. To use this method, you must specify a screen dimension in the constructor.
        /// </summary>
        /// <param name="pixels">Length in pixels</param>
        /// <param name="useHorizontalPitch">if false, use vertical pixel pitch</param>
        /// <returns>millimeters (dependent on the dimensions set in the constructor) or NaN</returns>
        public double CalcMillimetersFromPixels(double pixels, bool useHorizontalPitch = true)
        {
            if (device == null)
            {
                return double.NaN;
            }

            if (useHorizontalPitch)
            {
                return pixels * horizontalPixelPitch;
            }
            else
            {
                return pixels * verticalPixelPitch;
            }
        }

        /// <summary>
        /// Start for receiving gaze data. Before calling it, you must set <see cref="E:EyeTracking.TobiiSBEyeTracker.OnGazeData"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">TobiiEyeTracker.OnGazeData is null</exception>
        public void StartReceivingGazeData()
        {
            if (device != null && OnGazeData != null)
            {
                isEyeTrackingStarted = true;
                device.GazeDataReceived += GazeDataReceived;
            }
            else
            {
                throw new InvalidOperationException("TobiiSBEyeTracker.OnGazeData is null. Cannot Start.");
            }
        }

        /// <summary>
        /// Stop for receiving gaze data. Before calling it, you must set <see cref="E:EyeTracking.TobiiSBEyeTracker.OnGazeData"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">TobiiSBEyeTracker.OnGazeData is null</exception>
        public void StopReceivingGazeData()
        {
            if (device != null && OnGazeData != null)
            {
                isEyeTrackingStarted = false;
                device.GazeDataReceived -= GazeDataReceived;
            }
            else
            {
                throw new InvalidOperationException("TobiiSBEyeTracker.OnGazeData is null. Cannot Stop.");
            }
        }

        /// <summary>
        /// Change velocity calculation type
        /// </summary>
        /// <param name="vCalcType">Calculation type for gaze angular velocity</param>
        /// <exception cref="InvalidOperationException">EyeTracking is not started. Cannot change parameters now.</exception>
        public void ChangeVCalcType(VelocityCalcType vCalcType)
        {
            if (!isEyeTrackingStarted)
            {
                velocityCalcType = vCalcType;
            }
            else
            {
                throw new InvalidOperationException("EyeTracking is not started. Cannot change parameters now.");
            }
        }

        /// <summary>
        /// Change fixation velocity threshold
        /// </summary>
        /// <param name="fixationVelocityThresh">Angular velocity threshold [rad/s] for classifying eye movements, saccade or not a saccade</param>
        /// <exception cref="InvalidOperationException">EyeTracking is not started. Cannot change parameters now.</exception>
        public void ChangeFixationVelocityThresh(int fixationVelocityThresh)
        {
            if (!isEyeTrackingStarted)
            {
                fixationAngularVelocityThreshold = fixationVelocityThresh;
            }
            else
            {
                throw new InvalidOperationException("EyeTracking is not started. Cannot change parameters now.");
            }
        }

        /// <summary>
        /// Change fixation duration threshold
        /// </summary>
        /// <param name="fixationDurationThresh">Time duration threshold [ms] for classifying eye movements, not a saccade or fixation</param>
        /// <exception cref="InvalidOperationException">EyeTracking is not started. Cannot change parameters now.</exception>
        public void ChangeFixationDurationThresh(int fixationDurationThresh)
        {
            if (!isEyeTrackingStarted)
            {
                notASaccadeDurationThresholdMs = fixationDurationThresh;
            }
            else
            {
                throw new InvalidOperationException("EyeTracking is not started. Cannot change parameters now.");
            }
        }
        #endregion

        #region Private method
        /// <summary>
        /// Calculate Angular Velocity from interval and gaze point/origin data.
        /// </summary>
        /// <param name="timeInterval">Time interval in usec.</param>
        /// <param name="currentGazePoint">Current gaze point with Tobii.Reseach.GazePoint</param>
        /// <param name="currentGazeOrigin">Current gaze origin with Tobii.Reseach.GazeOrigin</param>
        /// <param name="prevGazePoint">Previous gaze point with Tobii.Reseach.GazePoint</param>
        /// <param name="prevGazeOrigin">Previous gaze origin with Tobii.Reseach.GazeOrigin</param>
        private double CalcAngularVelocityFrom(int timeInterval, GazePoint currentGazePoint, GazeOrigin currentGazeOrigin, GazePoint prevGazePoint, GazeOrigin prevGazeOrigin)
        {
            double thetaRad;
            double angularVelocity;

            if (timeInterval <= 0)
            {
                return double.NaN;
            }

            // UCS vector from tracker to point
            Vector3 gazePointUCSVector = new Vector3(currentGazePoint.PositionInUserCoordinates.X, currentGazePoint.PositionInUserCoordinates.Y, currentGazePoint.PositionInUserCoordinates.Z);
            // UCS vector from tracker to origin
            Vector3 gazeOriginUCSVector = new Vector3(currentGazeOrigin.PositionInUserCoordinates.X, currentGazeOrigin.PositionInUserCoordinates.Y, currentGazeOrigin.PositionInUserCoordinates.Z);

            if (velocityCalcType == VelocityCalcType.UCSGazeVector)
            {
                // Previous UCS vector from tracker to point
                Vector3 prevGazePointUCSVector = new Vector3(prevGazePoint.PositionInUserCoordinates.X, prevGazePoint.PositionInUserCoordinates.Y, prevGazePoint.PositionInUserCoordinates.Z);
                // Previous UCS vector from tracker to origin
                Vector3 prevGazeOriginUCSVector = new Vector3(prevGazeOrigin.PositionInUserCoordinates.X, prevGazeOrigin.PositionInUserCoordinates.Y, prevGazeOrigin.PositionInUserCoordinates.Z);
                // Gaze vectors
                Vector3 gazeUCSVector = Vector3.Subtract(gazePointUCSVector, gazeOriginUCSVector);
                Vector3 prevGazeUCSVector = Vector3.Subtract(prevGazePointUCSVector, prevGazeOriginUCSVector);
                // cos(theta)
                double cosineTheta = (double)(Vector3.Dot(prevGazeUCSVector, gazeUCSVector) / (prevGazeUCSVector.Length() * gazeUCSVector.Length()));
                // Radians
                thetaRad = Math.Acos(cosineTheta);
            }
            else if (velocityCalcType == VelocityCalcType.PixelPitchAndUCSDistance)
            {
                // Distance from origin to point
                double distanceFromOriginToPoint = (double)Vector3.Distance(gazeOriginUCSVector, gazePointUCSVector);
                // Gaze point difference from previous position
                double gazePointXInPixels = (double)(currentGazePoint.PositionOnDisplayArea.X * screenWidth);
                double gazePointYInPixels = (double)(currentGazePoint.PositionOnDisplayArea.Y * screenHeight);
                double gazePointXInMillimeters = CalcMillimetersFromPixels(gazePointXInPixels);
                double gazePointYInMillimeters = CalcMillimetersFromPixels(gazePointYInPixels);
                double prevGazePointXInPixels = (double)(prevGazePoint.PositionOnDisplayArea.X * screenWidth);
                double prevGazePointYInPixels = (double)(prevGazePoint.PositionOnDisplayArea.Y * screenHeight);
                double prevGazePointXInMillimeters = CalcMillimetersFromPixels(prevGazePointXInPixels);
                double prevGazePointYInMillimeters = CalcMillimetersFromPixels(prevGazePointYInPixels);
                double gazePointDifference = Math.Sqrt(Math.Pow(gazePointXInMillimeters - prevGazePointXInMillimeters, 2) + Math.Pow(gazePointYInMillimeters - prevGazePointYInMillimeters, 2));
                // Radians
                thetaRad = Math.Atan2(gazePointDifference, distanceFromOriginToPoint);
            }
            else
            {
                return double.NaN;
            }

            if (double.IsNaN(thetaRad))
            {
                return double.NaN;
            }

            // Degrees
            double thetaDeg = thetaRad * 180.0 / Math.PI;
            // Angular Velocity
            angularVelocity = thetaDeg * 1000000 / timeInterval;

            return angularVelocity;
        }

        /// <summary>
        /// Internal gaze data receive handler for <c>Tobii.Research.IEyeTracker.GazeDataReceived</c>
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void GazeDataReceived(object sender, GazeDataEventArgs e)
        {
            if (prevLeftGazePoint == null || prevLeftGazeOrigin == null || prevRightGazePoint == null || prevRightGazeOrigin == null)
            {
                prevLeftGazePoint = e.LeftEye.GazePoint;
                prevLeftGazeOrigin = e.LeftEye.GazeOrigin;
                prevRightGazePoint = e.RightEye.GazePoint;
                prevRightGazeOrigin = e.RightEye.GazeOrigin;
                prevSystemTimeStamp = e.SystemTimeStamp;
                return;
            }

            // Time stamp inteval
            int systemTimeStampInterval = (int)(e.SystemTimeStamp - prevSystemTimeStamp);
            if (systemTimeStampInterval < 0)
            {
                systemTimeStampInterval = 0;
            }

            // Validity
            bool isLeftValid = e.LeftEye.GazeOrigin.Validity == Validity.Valid && e.LeftEye.GazePoint.Validity == Validity.Valid;
            bool isRightValid = e.RightEye.GazeOrigin.Validity == Validity.Valid && e.RightEye.GazePoint.Validity == Validity.Valid;

            // Fixation
            double leftAngularVelocity;
            double rightAngularVelocity;
            EyeMovementType leftEyeMovementType;
            EyeMovementType rightEyeMovementType;

            if (fixationAngularVelocityThreshold > 0)
            {
                // If thresh is valid
                leftAngularVelocity = CalcAngularVelocityFrom(systemTimeStampInterval, e.LeftEye.GazePoint, e.LeftEye.GazeOrigin, prevLeftGazePoint, prevLeftGazeOrigin);
                rightAngularVelocity = CalcAngularVelocityFrom(systemTimeStampInterval, e.RightEye.GazePoint, e.RightEye.GazeOrigin, prevRightGazePoint, prevRightGazeOrigin);
                if (double.IsNaN(leftAngularVelocity))
                {
                    isLeftValid = false;
                    leftEyeMovementType = EyeMovementType.Unknown;
                }
                else
                {
                    leftEyeMovementType = (leftAngularVelocity > fixationAngularVelocityThreshold) ? EyeMovementType.Saccade : EyeMovementType.NotASaccade;
                    if (leftEyeMovementType == EyeMovementType.NotASaccade)
                    {
                        leftEyeNotASaccadeDurationMs += (int)(systemTimeStampInterval / 1000);
                    }
                    else
                    {
                        leftEyeNotASaccadeDurationMs = 0;
                    }
                    if (leftEyeNotASaccadeDurationMs >= notASaccadeDurationThresholdMs)
                    {
                        leftEyeMovementType = EyeMovementType.Fixation;
                    }
                }
                if (double.IsNaN(rightAngularVelocity))
                {
                    isRightValid = false;
                    rightEyeMovementType = EyeMovementType.Unknown;
                }
                else
                {
                    rightEyeMovementType = (rightAngularVelocity > fixationAngularVelocityThreshold) ? EyeMovementType.Saccade : EyeMovementType.NotASaccade;
                    if (rightEyeMovementType == EyeMovementType.NotASaccade)
                    {
                        rightEyeNotASaccadeDurationMs += (int)(systemTimeStampInterval / 1000);
                    }
                    else
                    {
                        rightEyeNotASaccadeDurationMs = 0;
                    }
                    if (rightEyeNotASaccadeDurationMs >= notASaccadeDurationThresholdMs)
                    {
                        rightEyeMovementType = EyeMovementType.Fixation;
                    }
                }
            }
            else
            {
                // If thresh is not valid
                leftAngularVelocity = double.NaN;
                rightAngularVelocity = double.NaN;
                leftEyeMovementType = EyeMovementType.Unknown;
                rightEyeMovementType = EyeMovementType.Unknown;
            }

            // Data to pass
            OnGazeDataEventArgs gazeDataUsingScreenDimension = new OnGazeDataEventArgs()
            {
                DeviceTimeStamp = e.DeviceTimeStamp,
                SystemTimeStamp = e.SystemTimeStamp,
                LeftX = (double)((e.LeftEye.GazePoint.PositionOnDisplayArea.X) * screenWidth),
                RightX = (double)((e.RightEye.GazePoint.PositionOnDisplayArea.X) * screenWidth),
                LeftY = (double)((e.LeftEye.GazePoint.PositionOnDisplayArea.Y) * screenHeight),
                RightY = (double)((e.RightEye.GazePoint.PositionOnDisplayArea.Y) * screenHeight),
                IsLeftValid = isLeftValid,
                IsRightValid = isRightValid,
                SystemTimeStampInterval = systemTimeStampInterval,
                LeftGazeAngularVelocity = leftAngularVelocity,
                RightGazeAngularVelocity = rightAngularVelocity,
                LeftEyeMovementType = leftEyeMovementType,
                RightEyeMovementType = rightEyeMovementType,
                IsLeftPDValid = e.LeftEye.Pupil.Validity == Validity.Valid,
                IsRightPDValid = e.RightEye.Pupil.Validity == Validity.Valid,
                LeftPD = e.LeftEye.Pupil.PupilDiameter,
                RightPD = e.RightEye.Pupil.PupilDiameter
            };
            OnGazeData?.Invoke(this, gazeDataUsingScreenDimension);

            // Update previous gaze data
            prevLeftGazePoint = e.LeftEye.GazePoint;
            prevLeftGazeOrigin = e.LeftEye.GazeOrigin;
            prevRightGazePoint = e.RightEye.GazePoint;
            prevRightGazeOrigin = e.RightEye.GazeOrigin;
            prevSystemTimeStamp = e.SystemTimeStamp;
        }
        #endregion
    }
}