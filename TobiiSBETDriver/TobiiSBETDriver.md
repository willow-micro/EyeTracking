<a name='assembly'></a>
# TobiiSBETDriver

## Contents

- [EyeMovementType](#T-EyeTracking-EyeMovementType 'EyeTracking.EyeMovementType')
  - [Fixation](#F-EyeTracking-EyeMovementType-Fixation 'EyeTracking.EyeMovementType.Fixation')
  - [NotASaccade](#F-EyeTracking-EyeMovementType-NotASaccade 'EyeTracking.EyeMovementType.NotASaccade')
  - [Saccade](#F-EyeTracking-EyeMovementType-Saccade 'EyeTracking.EyeMovementType.Saccade')
  - [Unknown](#F-EyeTracking-EyeMovementType-Unknown 'EyeTracking.EyeMovementType.Unknown')
- [EyeTrackerIdentification](#T-EyeTracking-EyeTrackerIdentification 'EyeTracking.EyeTrackerIdentification')
  - [DeviceName](#F-EyeTracking-EyeTrackerIdentification-DeviceName 'EyeTracking.EyeTrackerIdentification.DeviceName')
  - [FirmwareVersion](#F-EyeTracking-EyeTrackerIdentification-FirmwareVersion 'EyeTracking.EyeTrackerIdentification.FirmwareVersion')
  - [Model](#F-EyeTracking-EyeTrackerIdentification-Model 'EyeTracking.EyeTrackerIdentification.Model')
  - [RuntimeVersion](#F-EyeTracking-EyeTrackerIdentification-RuntimeVersion 'EyeTracking.EyeTrackerIdentification.RuntimeVersion')
  - [SerialNumber](#F-EyeTracking-EyeTrackerIdentification-SerialNumber 'EyeTracking.EyeTrackerIdentification.SerialNumber')
- [OnGazeDataEventArgs](#T-EyeTracking-OnGazeDataEventArgs 'EyeTracking.OnGazeDataEventArgs')
  - [DeviceTimeStamp](#F-EyeTracking-OnGazeDataEventArgs-DeviceTimeStamp 'EyeTracking.OnGazeDataEventArgs.DeviceTimeStamp')
  - [IsLeftPDValid](#F-EyeTracking-OnGazeDataEventArgs-IsLeftPDValid 'EyeTracking.OnGazeDataEventArgs.IsLeftPDValid')
  - [IsLeftValid](#F-EyeTracking-OnGazeDataEventArgs-IsLeftValid 'EyeTracking.OnGazeDataEventArgs.IsLeftValid')
  - [IsRightPDValid](#F-EyeTracking-OnGazeDataEventArgs-IsRightPDValid 'EyeTracking.OnGazeDataEventArgs.IsRightPDValid')
  - [IsRightValid](#F-EyeTracking-OnGazeDataEventArgs-IsRightValid 'EyeTracking.OnGazeDataEventArgs.IsRightValid')
  - [LeftEyeMovementType](#F-EyeTracking-OnGazeDataEventArgs-LeftEyeMovementType 'EyeTracking.OnGazeDataEventArgs.LeftEyeMovementType')
  - [LeftGazeAngularVelocity](#F-EyeTracking-OnGazeDataEventArgs-LeftGazeAngularVelocity 'EyeTracking.OnGazeDataEventArgs.LeftGazeAngularVelocity')
  - [LeftPD](#F-EyeTracking-OnGazeDataEventArgs-LeftPD 'EyeTracking.OnGazeDataEventArgs.LeftPD')
  - [LeftX](#F-EyeTracking-OnGazeDataEventArgs-LeftX 'EyeTracking.OnGazeDataEventArgs.LeftX')
  - [LeftY](#F-EyeTracking-OnGazeDataEventArgs-LeftY 'EyeTracking.OnGazeDataEventArgs.LeftY')
  - [RightEyeMovementType](#F-EyeTracking-OnGazeDataEventArgs-RightEyeMovementType 'EyeTracking.OnGazeDataEventArgs.RightEyeMovementType')
  - [RightGazeAngularVelocity](#F-EyeTracking-OnGazeDataEventArgs-RightGazeAngularVelocity 'EyeTracking.OnGazeDataEventArgs.RightGazeAngularVelocity')
  - [RightPD](#F-EyeTracking-OnGazeDataEventArgs-RightPD 'EyeTracking.OnGazeDataEventArgs.RightPD')
  - [RightX](#F-EyeTracking-OnGazeDataEventArgs-RightX 'EyeTracking.OnGazeDataEventArgs.RightX')
  - [RightY](#F-EyeTracking-OnGazeDataEventArgs-RightY 'EyeTracking.OnGazeDataEventArgs.RightY')
  - [SystemTimeStamp](#F-EyeTracking-OnGazeDataEventArgs-SystemTimeStamp 'EyeTracking.OnGazeDataEventArgs.SystemTimeStamp')
  - [SystemTimeStampInterval](#F-EyeTracking-OnGazeDataEventArgs-SystemTimeStampInterval 'EyeTracking.OnGazeDataEventArgs.SystemTimeStampInterval')
- [OnGazeDataEventHandler](#T-EyeTracking-TobiiSBEyeTracker-OnGazeDataEventHandler 'EyeTracking.TobiiSBEyeTracker.OnGazeDataEventHandler')
- [TobiiSBEyeTracker](#T-EyeTracking-TobiiSBEyeTracker 'EyeTracking.TobiiSBEyeTracker')
  - [#ctor(screenWidth,screenHeight,vCalcType,fixationVelocityThresh,fixationDurationThresh)](#M-EyeTracking-TobiiSBEyeTracker-#ctor-System-Double,System-Double,EyeTracking-VelocityCalcType,System-Int32,System-Int32- 'EyeTracking.TobiiSBEyeTracker.#ctor(System.Double,System.Double,EyeTracking.VelocityCalcType,System.Int32,System.Int32)')
  - [#ctor(identificationType,identificationString,screenWidth,screenHeight,vCalcType,fixationVelocityThresh,fixationDurationThresh)](#M-EyeTracking-TobiiSBEyeTracker-#ctor-EyeTracking-EyeTrackerIdentification,System-String,System-Double,System-Double,EyeTracking-VelocityCalcType,System-Int32,System-Int32- 'EyeTracking.TobiiSBEyeTracker.#ctor(EyeTracking.EyeTrackerIdentification,System.String,System.Double,System.Double,EyeTracking.VelocityCalcType,System.Int32,System.Int32)')
  - [device](#F-EyeTracking-TobiiSBEyeTracker-device 'EyeTracking.TobiiSBEyeTracker.device')
  - [fixationAngularVelocityThreshold](#F-EyeTracking-TobiiSBEyeTracker-fixationAngularVelocityThreshold 'EyeTracking.TobiiSBEyeTracker.fixationAngularVelocityThreshold')
  - [horizontalPixelPitch](#F-EyeTracking-TobiiSBEyeTracker-horizontalPixelPitch 'EyeTracking.TobiiSBEyeTracker.horizontalPixelPitch')
  - [isEyeTrackingStarted](#F-EyeTracking-TobiiSBEyeTracker-isEyeTrackingStarted 'EyeTracking.TobiiSBEyeTracker.isEyeTrackingStarted')
  - [leftEyeNotASaccadeDurationMs](#F-EyeTracking-TobiiSBEyeTracker-leftEyeNotASaccadeDurationMs 'EyeTracking.TobiiSBEyeTracker.leftEyeNotASaccadeDurationMs')
  - [notASaccadeDurationThresholdMs](#F-EyeTracking-TobiiSBEyeTracker-notASaccadeDurationThresholdMs 'EyeTracking.TobiiSBEyeTracker.notASaccadeDurationThresholdMs')
  - [prevLeftGazeOrigin](#F-EyeTracking-TobiiSBEyeTracker-prevLeftGazeOrigin 'EyeTracking.TobiiSBEyeTracker.prevLeftGazeOrigin')
  - [prevLeftGazePoint](#F-EyeTracking-TobiiSBEyeTracker-prevLeftGazePoint 'EyeTracking.TobiiSBEyeTracker.prevLeftGazePoint')
  - [prevRightGazeOrigin](#F-EyeTracking-TobiiSBEyeTracker-prevRightGazeOrigin 'EyeTracking.TobiiSBEyeTracker.prevRightGazeOrigin')
  - [prevRightGazePoint](#F-EyeTracking-TobiiSBEyeTracker-prevRightGazePoint 'EyeTracking.TobiiSBEyeTracker.prevRightGazePoint')
  - [prevSystemTimeStamp](#F-EyeTracking-TobiiSBEyeTracker-prevSystemTimeStamp 'EyeTracking.TobiiSBEyeTracker.prevSystemTimeStamp')
  - [rightEyeNotASaccadeDurationMs](#F-EyeTracking-TobiiSBEyeTracker-rightEyeNotASaccadeDurationMs 'EyeTracking.TobiiSBEyeTracker.rightEyeNotASaccadeDurationMs')
  - [screenHeight](#F-EyeTracking-TobiiSBEyeTracker-screenHeight 'EyeTracking.TobiiSBEyeTracker.screenHeight')
  - [screenWidth](#F-EyeTracking-TobiiSBEyeTracker-screenWidth 'EyeTracking.TobiiSBEyeTracker.screenWidth')
  - [velocityCalcType](#F-EyeTracking-TobiiSBEyeTracker-velocityCalcType 'EyeTracking.TobiiSBEyeTracker.velocityCalcType')
  - [verticalPixelPitch](#F-EyeTracking-TobiiSBEyeTracker-verticalPixelPitch 'EyeTracking.TobiiSBEyeTracker.verticalPixelPitch')
  - [CalcAngularVelocityFrom(timeInterval,currentGazePoint,currentGazeOrigin,prevGazePoint,prevGazeOrigin)](#M-EyeTracking-TobiiSBEyeTracker-CalcAngularVelocityFrom-System-Int32,Tobii-Research-GazePoint,Tobii-Research-GazeOrigin,Tobii-Research-GazePoint,Tobii-Research-GazeOrigin- 'EyeTracking.TobiiSBEyeTracker.CalcAngularVelocityFrom(System.Int32,Tobii.Research.GazePoint,Tobii.Research.GazeOrigin,Tobii.Research.GazePoint,Tobii.Research.GazeOrigin)')
  - [CalcMillimetersFromPixels(pixels,useHorizontalPitch)](#M-EyeTracking-TobiiSBEyeTracker-CalcMillimetersFromPixels-System-Double,System-Boolean- 'EyeTracking.TobiiSBEyeTracker.CalcMillimetersFromPixels(System.Double,System.Boolean)')
  - [CalcPixelPitch(calcHorizontalPitch)](#M-EyeTracking-TobiiSBEyeTracker-CalcPixelPitch-System-Boolean- 'EyeTracking.TobiiSBEyeTracker.CalcPixelPitch(System.Boolean)')
  - [CalcPixelsFromMillimeters(millimeters,useHorizontalPitch)](#M-EyeTracking-TobiiSBEyeTracker-CalcPixelsFromMillimeters-System-Double,System-Boolean- 'EyeTracking.TobiiSBEyeTracker.CalcPixelsFromMillimeters(System.Double,System.Boolean)')
  - [ChangeFixationDurationThresh(fixationDurationThresh)](#M-EyeTracking-TobiiSBEyeTracker-ChangeFixationDurationThresh-System-Int32- 'EyeTracking.TobiiSBEyeTracker.ChangeFixationDurationThresh(System.Int32)')
  - [ChangeFixationVelocityThresh(fixationVelocityThresh)](#M-EyeTracking-TobiiSBEyeTracker-ChangeFixationVelocityThresh-System-Int32- 'EyeTracking.TobiiSBEyeTracker.ChangeFixationVelocityThresh(System.Int32)')
  - [ChangeVCalcType(vCalcType)](#M-EyeTracking-TobiiSBEyeTracker-ChangeVCalcType-EyeTracking-VelocityCalcType- 'EyeTracking.TobiiSBEyeTracker.ChangeVCalcType(EyeTracking.VelocityCalcType)')
  - [GazeDataReceived(sender,e)](#M-EyeTracking-TobiiSBEyeTracker-GazeDataReceived-System-Object,Tobii-Research-GazeDataEventArgs- 'EyeTracking.TobiiSBEyeTracker.GazeDataReceived(System.Object,Tobii.Research.GazeDataEventArgs)')
  - [GetDeviceName()](#M-EyeTracking-TobiiSBEyeTracker-GetDeviceName 'EyeTracking.TobiiSBEyeTracker.GetDeviceName')
  - [GetDisplayArea()](#M-EyeTracking-TobiiSBEyeTracker-GetDisplayArea 'EyeTracking.TobiiSBEyeTracker.GetDisplayArea')
  - [GetFirmwareVersion()](#M-EyeTracking-TobiiSBEyeTracker-GetFirmwareVersion 'EyeTracking.TobiiSBEyeTracker.GetFirmwareVersion')
  - [GetFrequency()](#M-EyeTracking-TobiiSBEyeTracker-GetFrequency 'EyeTracking.TobiiSBEyeTracker.GetFrequency')
  - [GetModel()](#M-EyeTracking-TobiiSBEyeTracker-GetModel 'EyeTracking.TobiiSBEyeTracker.GetModel')
  - [GetRuntimeVersion()](#M-EyeTracking-TobiiSBEyeTracker-GetRuntimeVersion 'EyeTracking.TobiiSBEyeTracker.GetRuntimeVersion')
  - [GetScreenHeightInMillimeters()](#M-EyeTracking-TobiiSBEyeTracker-GetScreenHeightInMillimeters 'EyeTracking.TobiiSBEyeTracker.GetScreenHeightInMillimeters')
  - [GetScreenHeightInPixels()](#M-EyeTracking-TobiiSBEyeTracker-GetScreenHeightInPixels 'EyeTracking.TobiiSBEyeTracker.GetScreenHeightInPixels')
  - [GetScreenWidthInMillimeters()](#M-EyeTracking-TobiiSBEyeTracker-GetScreenWidthInMillimeters 'EyeTracking.TobiiSBEyeTracker.GetScreenWidthInMillimeters')
  - [GetScreenWidthInPixels()](#M-EyeTracking-TobiiSBEyeTracker-GetScreenWidthInPixels 'EyeTracking.TobiiSBEyeTracker.GetScreenWidthInPixels')
  - [GetSerialNumber()](#M-EyeTracking-TobiiSBEyeTracker-GetSerialNumber 'EyeTracking.TobiiSBEyeTracker.GetSerialNumber')
  - [StartReceivingGazeData()](#M-EyeTracking-TobiiSBEyeTracker-StartReceivingGazeData 'EyeTracking.TobiiSBEyeTracker.StartReceivingGazeData')
  - [StopReceivingGazeData()](#M-EyeTracking-TobiiSBEyeTracker-StopReceivingGazeData 'EyeTracking.TobiiSBEyeTracker.StopReceivingGazeData')
- [VelocityCalcType](#T-EyeTracking-VelocityCalcType 'EyeTracking.VelocityCalcType')
  - [PixelPitchAndUCSDistance](#F-EyeTracking-VelocityCalcType-PixelPitchAndUCSDistance 'EyeTracking.VelocityCalcType.PixelPitchAndUCSDistance')
  - [UCSGazeVector](#F-EyeTracking-VelocityCalcType-UCSGazeVector 'EyeTracking.VelocityCalcType.UCSGazeVector')

<a name='T-EyeTracking-EyeMovementType'></a>
## EyeMovementType `type`

##### Namespace

EyeTracking

##### Summary

Enum to describe eye movement

<a name='F-EyeTracking-EyeMovementType-Fixation'></a>
### Fixation `constants`

##### Summary

Fixation

<a name='F-EyeTracking-EyeMovementType-NotASaccade'></a>
### NotASaccade `constants`

##### Summary

Not a saccade, not a fixation

<a name='F-EyeTracking-EyeMovementType-Saccade'></a>
### Saccade `constants`

##### Summary

Saccade

<a name='F-EyeTracking-EyeMovementType-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown

<a name='T-EyeTracking-EyeTrackerIdentification'></a>
## EyeTrackerIdentification `type`

##### Namespace

EyeTracking

##### Summary

Way to specify eyetrackers at overloaded `EyeTracker` constructor.

##### See Also

- [EyeTracking.TobiiSBEyeTracker.#ctor](#M-EyeTracking-TobiiSBEyeTracker-#ctor-EyeTracking-EyeTrackerIdentification,System-String,System-Double,System-Double,EyeTracking-VelocityCalcType,System-Int32,System-Int32- 'EyeTracking.TobiiSBEyeTracker.#ctor(EyeTracking.EyeTrackerIdentification,System.String,System.Double,System.Double,EyeTracking.VelocityCalcType,System.Int32,System.Int32)')

<a name='F-EyeTracking-EyeTrackerIdentification-DeviceName'></a>
### DeviceName `constants`

##### Summary

Device Name of the device.

<a name='F-EyeTracking-EyeTrackerIdentification-FirmwareVersion'></a>
### FirmwareVersion `constants`

##### Summary

Firmware Version of the device.

<a name='F-EyeTracking-EyeTrackerIdentification-Model'></a>
### Model `constants`

##### Summary

Model of the device.

<a name='F-EyeTracking-EyeTrackerIdentification-RuntimeVersion'></a>
### RuntimeVersion `constants`

##### Summary

Runtime Version of the device.

<a name='F-EyeTracking-EyeTrackerIdentification-SerialNumber'></a>
### SerialNumber `constants`

##### Summary

Serial Number of the device.

<a name='T-EyeTracking-OnGazeDataEventArgs'></a>
## OnGazeDataEventArgs `type`

##### Namespace

EyeTracking

##### Summary

EventArgs for [](#E-EyeTracking-TobiiSBEyeTracker-OnGazeData 'EyeTracking.TobiiSBEyeTracker.OnGazeData')

<a name='F-EyeTracking-OnGazeDataEventArgs-DeviceTimeStamp'></a>
### DeviceTimeStamp `constants`

##### Summary

Device Time Stamp.

<a name='F-EyeTracking-OnGazeDataEventArgs-IsLeftPDValid'></a>
### IsLeftPDValid `constants`

##### Summary

If the Left eye pupil diameter is invalid, it becomes false.

<a name='F-EyeTracking-OnGazeDataEventArgs-IsLeftValid'></a>
### IsLeftValid `constants`

##### Summary

If the Left eye is closed or couldn't get valid data, it becomes false.

<a name='F-EyeTracking-OnGazeDataEventArgs-IsRightPDValid'></a>
### IsRightPDValid `constants`

##### Summary

If the Right eye pupil diameter is invalid, it becomes false.

<a name='F-EyeTracking-OnGazeDataEventArgs-IsRightValid'></a>
### IsRightValid `constants`

##### Summary

If the Right eye is closed or couldn't get valid data, it becomes false.

<a name='F-EyeTracking-OnGazeDataEventArgs-LeftEyeMovementType'></a>
### LeftEyeMovementType `constants`

##### Summary

[Left Eye] Movement Type (Saccade, Not A Saccade, Fixation, Unknown)

<a name='F-EyeTracking-OnGazeDataEventArgs-LeftGazeAngularVelocity'></a>
### LeftGazeAngularVelocity `constants`

##### Summary

Angular Velocity for Left Gaze in deg/s

<a name='F-EyeTracking-OnGazeDataEventArgs-LeftPD'></a>
### LeftPD `constants`

##### Summary

[Left Eye] Pupil Diameter [mm]

<a name='F-EyeTracking-OnGazeDataEventArgs-LeftX'></a>
### LeftX `constants`

##### Summary

X Coordinate of the Left eye gaze in the user display area. 
`0.0` is the left edge, `1.0` or `screenWidth` is the right edge of the screen.

<a name='F-EyeTracking-OnGazeDataEventArgs-LeftY'></a>
### LeftY `constants`

##### Summary

Y Coordinate of the Left eye gaze in the user display area. 
`0.0` is the top edge, `1.0` or `screenHeight` is the bottom edge of the screen.

<a name='F-EyeTracking-OnGazeDataEventArgs-RightEyeMovementType'></a>
### RightEyeMovementType `constants`

##### Summary

[Left Eye] Movement Type (Saccade, Not A Saccade, Fixation, Unknown)

<a name='F-EyeTracking-OnGazeDataEventArgs-RightGazeAngularVelocity'></a>
### RightGazeAngularVelocity `constants`

##### Summary

Angular Velocity for Right Gaze in deg/s

<a name='F-EyeTracking-OnGazeDataEventArgs-RightPD'></a>
### RightPD `constants`

##### Summary

[Right Eye] Pupil Diameter [mm]

<a name='F-EyeTracking-OnGazeDataEventArgs-RightX'></a>
### RightX `constants`

##### Summary

X Coordinate of the Right eye gaze in the user display area. 
`0.0` is the left edge, `1.0` or `screenWidth` is the right edge of the screen.

<a name='F-EyeTracking-OnGazeDataEventArgs-RightY'></a>
### RightY `constants`

##### Summary

Y Coordinate of the Right eye gaze in the user display area. 
`0.0` is the top edge, `1.0` or `screenHeight` is the bottom edge of the screen.

<a name='F-EyeTracking-OnGazeDataEventArgs-SystemTimeStamp'></a>
### SystemTimeStamp `constants`

##### Summary

System Time Stamp.

<a name='F-EyeTracking-OnGazeDataEventArgs-SystemTimeStampInterval'></a>
### SystemTimeStampInterval `constants`

##### Summary

Interval between the previous system time stamp and the latest system time stamp

<a name='T-EyeTracking-TobiiSBEyeTracker-OnGazeDataEventHandler'></a>
## OnGazeDataEventHandler `type`

##### Namespace

EyeTracking.TobiiSBEyeTracker

##### Summary

Delegate for the event [](#E-EyeTracking-TobiiSBEyeTracker-OnGazeData 'EyeTracking.TobiiSBEyeTracker.OnGazeData')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:EyeTracking.TobiiSBEyeTracker.OnGazeDataEventHandler](#T-T-EyeTracking-TobiiSBEyeTracker-OnGazeDataEventHandler 'T:EyeTracking.TobiiSBEyeTracker.OnGazeDataEventHandler') | Event sender |

<a name='T-EyeTracking-TobiiSBEyeTracker'></a>
## TobiiSBEyeTracker `type`

##### Namespace

EyeTracking

##### Summary

A driver for Tobii screen-based eye trackers

<a name='M-EyeTracking-TobiiSBEyeTracker-#ctor-System-Double,System-Double,EyeTracking-VelocityCalcType,System-Int32,System-Int32-'></a>
### #ctor(screenWidth,screenHeight,vCalcType,fixationVelocityThresh,fixationDurationThresh) `constructor`

##### Summary

Constructor. Use the first eye tracker in the `Tobii.Research.EyeTrackerCollection`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| screenWidth | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Screen width in pixels. (Max value of gaze x positions in [](#E-EyeTracking-TobiiSBEyeTracker-OnGazeData 'EyeTracking.TobiiSBEyeTracker.OnGazeData')) |
| screenHeight | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Screen height in pixels. (Max value of gaze y positions in [](#E-EyeTracking-TobiiSBEyeTracker-OnGazeData 'EyeTracking.TobiiSBEyeTracker.OnGazeData')) |
| vCalcType | [EyeTracking.VelocityCalcType](#T-EyeTracking-VelocityCalcType 'EyeTracking.VelocityCalcType') | Calculation type for gaze angular velocity |
| fixationVelocityThresh | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Angular velocity threshold [rad/s] for classifying eye movements, saccade or not a saccade |
| fixationDurationThresh | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Time duration threshold [ms] for classifying eye movements, not a saccade or fixation |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Provided screen dimension is invalid |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Eye tracker(s) not found |

<a name='M-EyeTracking-TobiiSBEyeTracker-#ctor-EyeTracking-EyeTrackerIdentification,System-String,System-Double,System-Double,EyeTracking-VelocityCalcType,System-Int32,System-Int32-'></a>
### #ctor(identificationType,identificationString,screenWidth,screenHeight,vCalcType,fixationVelocityThresh,fixationDurationThresh) `constructor`

##### Summary

Overloaded constructor. Use the eye tracker which has `identificationString` for `identificationType` in the `Tobii.Research.EyeTrackerCollection`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| identificationType | [EyeTracking.EyeTrackerIdentification](#T-EyeTracking-EyeTrackerIdentification 'EyeTracking.EyeTrackerIdentification') | The way to specify the eye tracker. |
| identificationString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string for specify the eye tracker. |
| screenWidth | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Screen width in pixels. (Max value of gaze x positions in [](#E-EyeTracking-TobiiSBEyeTracker-OnGazeData 'EyeTracking.TobiiSBEyeTracker.OnGazeData')) |
| screenHeight | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Screen height in pixels. (Max value of gaze y positions in [](#E-EyeTracking-TobiiSBEyeTracker-OnGazeData 'EyeTracking.TobiiSBEyeTracker.OnGazeData')) |
| vCalcType | [EyeTracking.VelocityCalcType](#T-EyeTracking-VelocityCalcType 'EyeTracking.VelocityCalcType') | Calculation type for gaze angular velocity |
| fixationVelocityThresh | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Angular velocity threshold [rad/s] for classifying eye movements, saccade or not a saccade |
| fixationDurationThresh | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Time duration threshold [ms] for classifying eye movements, not a saccade or fixation |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Provided screen dimension is invalid |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Eye Tracker(s) not found |

<a name='F-EyeTracking-TobiiSBEyeTracker-device'></a>
### device `constants`

##### Summary

Tobii.Research eye tracker object

<a name='F-EyeTracking-TobiiSBEyeTracker-fixationAngularVelocityThreshold'></a>
### fixationAngularVelocityThreshold `constants`

##### Summary

Angular velocity threshold [rad/s] for classifying eye movement, fixation or saccade

<a name='F-EyeTracking-TobiiSBEyeTracker-horizontalPixelPitch'></a>
### horizontalPixelPitch `constants`

##### Summary

Horizontal pixel pitch

<a name='F-EyeTracking-TobiiSBEyeTracker-isEyeTrackingStarted'></a>
### isEyeTrackingStarted `constants`

##### Summary

Check if the eye tracking is started or not

<a name='F-EyeTracking-TobiiSBEyeTracker-leftEyeNotASaccadeDurationMs'></a>
### leftEyeNotASaccadeDurationMs `constants`

##### Summary

[Left Eye] Not a saccade time duration in ms. For fixation detection.

<a name='F-EyeTracking-TobiiSBEyeTracker-notASaccadeDurationThresholdMs'></a>
### notASaccadeDurationThresholdMs `constants`

##### Summary

Not a saccade time duration threshold in ms. For fixation detection.

<a name='F-EyeTracking-TobiiSBEyeTracker-prevLeftGazeOrigin'></a>
### prevLeftGazeOrigin `constants`

##### Summary

[Left Eye] Previous gaze origin

<a name='F-EyeTracking-TobiiSBEyeTracker-prevLeftGazePoint'></a>
### prevLeftGazePoint `constants`

##### Summary

[Left Eye] Previous gaze point

<a name='F-EyeTracking-TobiiSBEyeTracker-prevRightGazeOrigin'></a>
### prevRightGazeOrigin `constants`

##### Summary

[Right Eye] Previous gaze origin

<a name='F-EyeTracking-TobiiSBEyeTracker-prevRightGazePoint'></a>
### prevRightGazePoint `constants`

##### Summary

[Right Eye] Previous gaze point

<a name='F-EyeTracking-TobiiSBEyeTracker-prevSystemTimeStamp'></a>
### prevSystemTimeStamp `constants`

##### Summary

Previous System time stamp [us]

<a name='F-EyeTracking-TobiiSBEyeTracker-rightEyeNotASaccadeDurationMs'></a>
### rightEyeNotASaccadeDurationMs `constants`

##### Summary

[Right Eye] Not a saccade time duration in ms. For fixation detection.

<a name='F-EyeTracking-TobiiSBEyeTracker-screenHeight'></a>
### screenHeight `constants`

##### Summary

Screen height

<a name='F-EyeTracking-TobiiSBEyeTracker-screenWidth'></a>
### screenWidth `constants`

##### Summary

Screen width

<a name='F-EyeTracking-TobiiSBEyeTracker-velocityCalcType'></a>
### velocityCalcType `constants`

##### Summary

Gaze angular velocity calculation type

<a name='F-EyeTracking-TobiiSBEyeTracker-verticalPixelPitch'></a>
### verticalPixelPitch `constants`

##### Summary

Vertical pixel pitch

<a name='M-EyeTracking-TobiiSBEyeTracker-CalcAngularVelocityFrom-System-Int32,Tobii-Research-GazePoint,Tobii-Research-GazeOrigin,Tobii-Research-GazePoint,Tobii-Research-GazeOrigin-'></a>
### CalcAngularVelocityFrom(timeInterval,currentGazePoint,currentGazeOrigin,prevGazePoint,prevGazeOrigin) `method`

##### Summary

Calculate Angular Velocity from interval and gaze point/origin data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| timeInterval | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Time interval in usec. |
| currentGazePoint | [Tobii.Research.GazePoint](#T-Tobii-Research-GazePoint 'Tobii.Research.GazePoint') | Current gaze point with Tobii.Reseach.GazePoint |
| currentGazeOrigin | [Tobii.Research.GazeOrigin](#T-Tobii-Research-GazeOrigin 'Tobii.Research.GazeOrigin') | Current gaze origin with Tobii.Reseach.GazeOrigin |
| prevGazePoint | [Tobii.Research.GazePoint](#T-Tobii-Research-GazePoint 'Tobii.Research.GazePoint') | Previous gaze point with Tobii.Reseach.GazePoint |
| prevGazeOrigin | [Tobii.Research.GazeOrigin](#T-Tobii-Research-GazeOrigin 'Tobii.Research.GazeOrigin') | Previous gaze origin with Tobii.Reseach.GazeOrigin |

<a name='M-EyeTracking-TobiiSBEyeTracker-CalcMillimetersFromPixels-System-Double,System-Boolean-'></a>
### CalcMillimetersFromPixels(pixels,useHorizontalPitch) `method`

##### Summary

Calculate millimeters from pixels. To use this method, you must specify a screen dimension in the constructor.

##### Returns

millimeters (dependent on the dimensions set in the constructor) or NaN

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pixels | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Length in pixels |
| useHorizontalPitch | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | if false, use vertical pixel pitch |

<a name='M-EyeTracking-TobiiSBEyeTracker-CalcPixelPitch-System-Boolean-'></a>
### CalcPixelPitch(calcHorizontalPitch) `method`

##### Summary

Calculate the pixel pitch. To use this method, you must specify a screen dimension in the constructor.

##### Returns

A horizontal or vertical pixel pitch or NaN

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| calcHorizontalPitch | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If false, calculate a vertical pixel pitch |

<a name='M-EyeTracking-TobiiSBEyeTracker-CalcPixelsFromMillimeters-System-Double,System-Boolean-'></a>
### CalcPixelsFromMillimeters(millimeters,useHorizontalPitch) `method`

##### Summary

Calculate pixels from millimeters. To use this method, you must specify a screen dimension in the constructor.

##### Returns

pixels (based on the dimensions set in the constructor) or NaN

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| millimeters | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Length in millimeters |
| useHorizontalPitch | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | if false, use vertical pixel pitch |

<a name='M-EyeTracking-TobiiSBEyeTracker-ChangeFixationDurationThresh-System-Int32-'></a>
### ChangeFixationDurationThresh(fixationDurationThresh) `method`

##### Summary

Change fixation duration threshold

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fixationDurationThresh | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Time duration threshold [ms] for classifying eye movements, not a saccade or fixation |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | EyeTracking is not started. Cannot change parameters now. |

<a name='M-EyeTracking-TobiiSBEyeTracker-ChangeFixationVelocityThresh-System-Int32-'></a>
### ChangeFixationVelocityThresh(fixationVelocityThresh) `method`

##### Summary

Change fixation velocity threshold

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fixationVelocityThresh | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Angular velocity threshold [rad/s] for classifying eye movements, saccade or not a saccade |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | EyeTracking is not started. Cannot change parameters now. |

<a name='M-EyeTracking-TobiiSBEyeTracker-ChangeVCalcType-EyeTracking-VelocityCalcType-'></a>
### ChangeVCalcType(vCalcType) `method`

##### Summary

Change velocity calculation type

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vCalcType | [EyeTracking.VelocityCalcType](#T-EyeTracking-VelocityCalcType 'EyeTracking.VelocityCalcType') | Calculation type for gaze angular velocity |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | EyeTracking is not started. Cannot change parameters now. |

<a name='M-EyeTracking-TobiiSBEyeTracker-GazeDataReceived-System-Object,Tobii-Research-GazeDataEventArgs-'></a>
### GazeDataReceived(sender,e) `method`

##### Summary

Internal gaze data receive handler for `Tobii.Research.IEyeTracker.GazeDataReceived`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Event sender |
| e | [Tobii.Research.GazeDataEventArgs](#T-Tobii-Research-GazeDataEventArgs 'Tobii.Research.GazeDataEventArgs') | Event arguments |

<a name='M-EyeTracking-TobiiSBEyeTracker-GetDeviceName'></a>
### GetDeviceName() `method`

##### Summary

Get the Device Name for the eye tracker.

##### Returns

Device Name (if there is no device, returns null)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetDisplayArea'></a>
### GetDisplayArea() `method`

##### Summary

Get the display area of the eye tracker.

##### Returns

Tobii.Research.DisplayArea (if there is no device, returns null)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetFirmwareVersion'></a>
### GetFirmwareVersion() `method`

##### Summary

Get the Firmware Version for the eye tracker.

##### Returns

Firmware Version (if there is no device, returns null)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetFrequency'></a>
### GetFrequency() `method`

##### Summary

Get the frequency of the eye tracker.

##### Returns

float (if there is no device, returns null)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetModel'></a>
### GetModel() `method`

##### Summary

Get the Model for the eye tracker.

##### Returns

Model (if there is no device, returns null)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetRuntimeVersion'></a>
### GetRuntimeVersion() `method`

##### Summary

Get the Runtime Version for the eye tracker.

##### Returns

Runtime Version (if there is no device, returns null)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetScreenHeightInMillimeters'></a>
### GetScreenHeightInMillimeters() `method`

##### Summary

Get the screen height in millimeters

##### Returns

Screen height in millimeters (if there is no eye tracker, returns NaN)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetScreenHeightInPixels'></a>
### GetScreenHeightInPixels() `method`

##### Summary

Get the screen height in pixels (same as constructor's screenHeight)

##### Returns

Screen height in pixels

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetScreenWidthInMillimeters'></a>
### GetScreenWidthInMillimeters() `method`

##### Summary

Get the screen width in millimeters

##### Returns

Screen width in millimeters (if there is no eye tracker, returns NaN)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetScreenWidthInPixels'></a>
### GetScreenWidthInPixels() `method`

##### Summary

Get the screen width in pixels (same as constructor's screenWidth)

##### Returns

Screen width in pixels

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-GetSerialNumber'></a>
### GetSerialNumber() `method`

##### Summary

Get the Serial Number for the eye tracker.

##### Returns

Serial Number (if there is no device, returns null)

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-TobiiSBEyeTracker-StartReceivingGazeData'></a>
### StartReceivingGazeData() `method`

##### Summary

Start for receiving gaze data. Before calling it, you must set [](#E-EyeTracking-TobiiSBEyeTracker-OnGazeData 'EyeTracking.TobiiSBEyeTracker.OnGazeData')

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | TobiiEyeTracker.OnGazeData is null |

<a name='M-EyeTracking-TobiiSBEyeTracker-StopReceivingGazeData'></a>
### StopReceivingGazeData() `method`

##### Summary

Stop for receiving gaze data. Before calling it, you must set [](#E-EyeTracking-TobiiSBEyeTracker-OnGazeData 'EyeTracking.TobiiSBEyeTracker.OnGazeData')

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | TobiiSBEyeTracker.OnGazeData is null |

<a name='T-EyeTracking-VelocityCalcType'></a>
## VelocityCalcType `type`

##### Namespace

EyeTracking

##### Summary

Enum to specify gaze angular velocity calculation type

<a name='F-EyeTracking-VelocityCalcType-PixelPitchAndUCSDistance'></a>
### PixelPitchAndUCSDistance `constants`

##### Summary

Calculate velocity using the pixel pitch and the distance from gaze origin to gaze point.

<a name='F-EyeTracking-VelocityCalcType-UCSGazeVector'></a>
### UCSGazeVector `constants`

##### Summary

Calculate velocity using UCS gaze vectors from gaze origin to gaze point.
