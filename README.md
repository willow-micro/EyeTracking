# EyeTracking
Eye tracking utilities for .NET

## EyeTracking.PupilDataProcessor
Process pupil data (diameter & validity) and compute LF/HF ratio and more.

### NuGet Package (pre-release)
[NuGet Gallery | PupilDataProcessor 0.0.1-beta.1](https://www.nuget.org/packages/PupilDataProcessor/)

### Features
- Device-independent (Screen-based eye trackers or HMD-based eye trackers)
- Real-time pupil data processing (Add pupil data one by one)
- LF/HF calculation with FFT (Selectable frequency, FFT window size, FFT window function)
- Also Average/Min/Max pupil diameter calculation is available
- Strict exception throwing
- .NET Standard 2.0

## EyeTracking.TobiiSBETDriver
A simplified driver library for Tobii screen-based eye trackers. Requires x64 CPU.

### NuGet Package (pre-release)
[NuGet Gallery | TobiiSBETDriver 0.0.1-beta.1](https://www.nuget.org/packages/TobiiSBETDriver/)

### Features
- Simplified wrapper library for Tobii screen-based eye trackers
- Fixation detection with a angular velocity and time duration filter (Selectable threshold parameters)
- Strict exception throwing
- .NET Standard 2.0
