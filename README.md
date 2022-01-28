# EyeTracking
Eye tracking utilities for .NET

## Licensing
MIT License

## EyeTracking.PupilDataProcessor
Process pupil data (diameter & validity) and compute LF/HF ratio and more.

### NuGet Package (pre-release)
[NuGet Gallery | PupilDataProcessor](https://www.nuget.org/packages/PupilDataProcessor/)

### Features
- Device-independent (Screen-based eye trackers or HMD-based eye trackers)
- Real-time pupil data processing (Add pupil data one by one)
- LF/HF calculation with FFT (Selectable frequency, FFT window size, FFT window function)
- Also Average/Min/Max pupil diameter calculation is available
- Strict exception throwing
- .NET Standard 2.0

### API References
- Auto-generated markdown via vsxmd is found here: [EyeTracking/PupilDataProcessor.md](https://github.com/willow-micro/EyeTracking/blob/master/PupilDataProcessor/PupilDataProcessor.md)

## EyeTracking.TobiiSBETDriver
A simplified driver library for Tobii screen-based eye trackers. Requires x64 CPU.

### NuGet Package (pre-release)
[NuGet Gallery | TobiiSBETDriver](https://www.nuget.org/packages/TobiiSBETDriver/)

### Features
- Simplified wrapper library for Tobii screen-based eye trackers
- Fixation detection with a angular velocity and time duration filter (Selectable threshold parameters)
- Strict exception throwing
- .NET Standard 2.0

### API References
- Auto-generated markdown via vsxmd is found here: [EyeTracking/TobiiSBETDriver.md](https://github.com/willow-micro/EyeTracking/blob/master/TobiiSBETDriver/TobiiSBETDriver.md)
