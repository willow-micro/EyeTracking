<a name='assembly'></a>
# PupilDataProcessor

## Contents

- [FIFO\`1](#T-EyeTracking-FIFO`1 'EyeTracking.FIFO`1')
  - [#ctor(bufferSize)](#M-EyeTracking-FIFO`1-#ctor-System-Int32- 'EyeTracking.FIFO`1.#ctor(System.Int32)')
  - [#ctor(previousFIFO)](#M-EyeTracking-FIFO`1-#ctor-EyeTracking-FIFO{`0}- 'EyeTracking.FIFO`1.#ctor(EyeTracking.FIFO{`0})')
  - [availableCount](#F-EyeTracking-FIFO`1-availableCount 'EyeTracking.FIFO`1.availableCount')
  - [buffer](#F-EyeTracking-FIFO`1-buffer 'EyeTracking.FIFO`1.buffer')
  - [getIndex](#F-EyeTracking-FIFO`1-getIndex 'EyeTracking.FIFO`1.getIndex')
  - [hasPutIndexReachedMax](#F-EyeTracking-FIFO`1-hasPutIndexReachedMax 'EyeTracking.FIFO`1.hasPutIndexReachedMax')
  - [putIndex](#F-EyeTracking-FIFO`1-putIndex 'EyeTracking.FIFO`1.putIndex')
  - [Clear()](#M-EyeTracking-FIFO`1-Clear 'EyeTracking.FIFO`1.Clear')
  - [GetAvailableDataCount()](#M-EyeTracking-FIFO`1-GetAvailableDataCount 'EyeTracking.FIFO`1.GetAvailableDataCount')
  - [GetBufferSize()](#M-EyeTracking-FIFO`1-GetBufferSize 'EyeTracking.FIFO`1.GetBufferSize')
  - [GetData()](#M-EyeTracking-FIFO`1-GetData 'EyeTracking.FIFO`1.GetData')
  - [PeekAllDataMixed()](#M-EyeTracking-FIFO`1-PeekAllDataMixed 'EyeTracking.FIFO`1.PeekAllDataMixed')
  - [PeekAllDataOrdered()](#M-EyeTracking-FIFO`1-PeekAllDataOrdered 'EyeTracking.FIFO`1.PeekAllDataOrdered')
  - [PeekData()](#M-EyeTracking-FIFO`1-PeekData 'EyeTracking.FIFO`1.PeekData')
  - [PutData(data)](#M-EyeTracking-FIFO`1-PutData-`0- 'EyeTracking.FIFO`1.PutData(`0)')
  - [op_Addition(fifo,data)](#M-EyeTracking-FIFO`1-op_Addition-EyeTracking-FIFO{`0},`0- 'EyeTracking.FIFO`1.op_Addition(EyeTracking.FIFO{`0},`0)')
- [FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange')
  - [#ctor(min,max)](#M-EyeTracking-FrequencyRange-#ctor-System-Single,System-Single- 'EyeTracking.FrequencyRange.#ctor(System.Single,System.Single)')
  - [Max](#F-EyeTracking-FrequencyRange-Max 'EyeTracking.FrequencyRange.Max')
  - [Min](#F-EyeTracking-FrequencyRange-Min 'EyeTracking.FrequencyRange.Min')
- [LFHFComputeStatus](#T-EyeTracking-LFHFComputeStatus 'EyeTracking.LFHFComputeStatus')
  - [Error](#F-EyeTracking-LFHFComputeStatus-Error 'EyeTracking.LFHFComputeStatus.Error')
  - [Processing](#F-EyeTracking-LFHFComputeStatus-Processing 'EyeTracking.LFHFComputeStatus.Processing')
  - [Ready](#F-EyeTracking-LFHFComputeStatus-Ready 'EyeTracking.LFHFComputeStatus.Ready')
- [LFHFComputer](#T-EyeTracking-LFHFComputer 'EyeTracking.LFHFComputer')
  - [#ctor(processFrequency,lfRange,hfRange,windowSize)](#M-EyeTracking-LFHFComputer-#ctor-System-Int32,EyeTracking-FrequencyRange,EyeTracking-FrequencyRange,System-Int32- 'EyeTracking.LFHFComputer.#ctor(System.Int32,EyeTracking.FrequencyRange,EyeTracking.FrequencyRange,System.Int32)')
  - [#ctor(processFrequency,lfRange,hfRange,windowSize,windowFunction)](#M-EyeTracking-LFHFComputer-#ctor-System-Int32,EyeTracking-FrequencyRange,EyeTracking-FrequencyRange,System-Int32,EyeTracking-WindowFunction- 'EyeTracking.LFHFComputer.#ctor(System.Int32,EyeTracking.FrequencyRange,EyeTracking.FrequencyRange,System.Int32,EyeTracking.WindowFunction)')
  - [window](#F-EyeTracking-LFHFComputer-window 'EyeTracking.LFHFComputer.window')
  - [FrequencyResolution](#P-EyeTracking-LFHFComputer-FrequencyResolution 'EyeTracking.LFHFComputer.FrequencyResolution')
  - [HFRange](#P-EyeTracking-LFHFComputer-HFRange 'EyeTracking.LFHFComputer.HFRange')
  - [LFRange](#P-EyeTracking-LFHFComputer-LFRange 'EyeTracking.LFHFComputer.LFRange')
  - [WindowSize](#P-EyeTracking-LFHFComputer-WindowSize 'EyeTracking.LFHFComputer.WindowSize')
  - [ApplyWindow(floatArray)](#M-EyeTracking-LFHFComputer-ApplyWindow-System-Single[]- 'EyeTracking.LFHFComputer.ApplyWindow(System.Single[])')
  - [ComputeLFHFFrom(pupilDataArray,pupilDiameterAverage)](#M-EyeTracking-LFHFComputer-ComputeLFHFFrom-EyeTracking-PupilDataForProcess[],System-Single- 'EyeTracking.LFHFComputer.ComputeLFHFFrom(EyeTracking.PupilDataForProcess[],System.Single)')
  - [ComputeLFHFFrom(pupilDataArray)](#M-EyeTracking-LFHFComputer-ComputeLFHFFrom-EyeTracking-PupilDataForProcess[]- 'EyeTracking.LFHFComputer.ComputeLFHFFrom(EyeTracking.PupilDataForProcess[])')
  - [ExecuteFFT(floatArray)](#M-EyeTracking-LFHFComputer-ExecuteFFT-System-Single[]- 'EyeTracking.LFHFComputer.ExecuteFFT(System.Single[])')
  - [LerpPupilDiameter(pupilDataArray,validAverage)](#M-EyeTracking-LFHFComputer-LerpPupilDiameter-EyeTracking-PupilDataForProcess[],System-Single- 'EyeTracking.LFHFComputer.LerpPupilDiameter(EyeTracking.PupilDataForProcess[],System.Single)')
- [LerpStatus](#T-EyeTracking-LerpStatus 'EyeTracking.LerpStatus')
  - [Interpolating](#F-EyeTracking-LerpStatus-Interpolating 'EyeTracking.LerpStatus.Interpolating')
  - [NoInterpolationNecessary](#F-EyeTracking-LerpStatus-NoInterpolationNecessary 'EyeTracking.LerpStatus.NoInterpolationNecessary')
- [PupilDataForProcess](#T-EyeTracking-PupilDataForProcess 'EyeTracking.PupilDataForProcess')
  - [#ctor(diameter,isvalid)](#M-EyeTracking-PupilDataForProcess-#ctor-System-Single,System-Boolean- 'EyeTracking.PupilDataForProcess.#ctor(System.Single,System.Boolean)')
  - [Diameter](#F-EyeTracking-PupilDataForProcess-Diameter 'EyeTracking.PupilDataForProcess.Diameter')
  - [IsValid](#F-EyeTracking-PupilDataForProcess-IsValid 'EyeTracking.PupilDataForProcess.IsValid')
- [PupilDataProcessor](#T-EyeTracking-PupilDataProcessor 'EyeTracking.PupilDataProcessor')
  - [#ctor(eyeTrackingFrequency,lfRange,hfRange,lfhfWindowSize,lfhfHopSize,windowFunction)](#M-EyeTracking-PupilDataProcessor-#ctor-System-Int32,EyeTracking-FrequencyRange,EyeTracking-FrequencyRange,System-Int32,System-Int32,EyeTracking-WindowFunction- 'EyeTracking.PupilDataProcessor.#ctor(System.Int32,EyeTracking.FrequencyRange,EyeTracking.FrequencyRange,System.Int32,System.Int32,EyeTracking.WindowFunction)')
  - [#ctor(eyeTrackingFrequency,lfRange,hfRange,lfhfIdealFrequencyResolution,lfhfComputeSpanInSec)](#M-EyeTracking-PupilDataProcessor-#ctor-System-Int32,EyeTracking-FrequencyRange,EyeTracking-FrequencyRange,System-Single,System-Single- 'EyeTracking.PupilDataProcessor.#ctor(System.Int32,EyeTracking.FrequencyRange,EyeTracking.FrequencyRange,System.Single,System.Single)')
  - [dataBuffer](#F-EyeTracking-PupilDataProcessor-dataBuffer 'EyeTracking.PupilDataProcessor.dataBuffer')
  - [hasDataBufferFilledOnce](#F-EyeTracking-PupilDataProcessor-hasDataBufferFilledOnce 'EyeTracking.PupilDataProcessor.hasDataBufferFilledOnce')
  - [hopCount](#F-EyeTracking-PupilDataProcessor-hopCount 'EyeTracking.PupilDataProcessor.hopCount')
  - [lfhfComputer](#F-EyeTracking-PupilDataProcessor-lfhfComputer 'EyeTracking.PupilDataProcessor.lfhfComputer')
  - [validPupilDiameterCount](#F-EyeTracking-PupilDataProcessor-validPupilDiameterCount 'EyeTracking.PupilDataProcessor.validPupilDiameterCount')
  - [HopSize](#P-EyeTracking-PupilDataProcessor-HopSize 'EyeTracking.PupilDataProcessor.HopSize')
  - [LatestAverageValidDiameter](#P-EyeTracking-PupilDataProcessor-LatestAverageValidDiameter 'EyeTracking.PupilDataProcessor.LatestAverageValidDiameter')
  - [LatestLFHF](#P-EyeTracking-PupilDataProcessor-LatestLFHF 'EyeTracking.PupilDataProcessor.LatestLFHF')
  - [LatestMaxDiameter](#P-EyeTracking-PupilDataProcessor-LatestMaxDiameter 'EyeTracking.PupilDataProcessor.LatestMaxDiameter')
  - [LatestMinDiameter](#P-EyeTracking-PupilDataProcessor-LatestMinDiameter 'EyeTracking.PupilDataProcessor.LatestMinDiameter')
  - [WindowSize](#P-EyeTracking-PupilDataProcessor-WindowSize 'EyeTracking.PupilDataProcessor.WindowSize')
  - [UpdateWith(pupilData)](#M-EyeTracking-PupilDataProcessor-UpdateWith-EyeTracking-PupilDataForProcess- 'EyeTracking.PupilDataProcessor.UpdateWith(EyeTracking.PupilDataForProcess)')
- [WindowFunction](#T-EyeTracking-WindowFunction 'EyeTracking.WindowFunction')
  - [BartlettHann](#F-EyeTracking-WindowFunction-BartlettHann 'EyeTracking.WindowFunction.BartlettHann')
  - [Blackman](#F-EyeTracking-WindowFunction-Blackman 'EyeTracking.WindowFunction.Blackman')
  - [BlackmanHarris](#F-EyeTracking-WindowFunction-BlackmanHarris 'EyeTracking.WindowFunction.BlackmanHarris')
  - [BlackmanNuttall](#F-EyeTracking-WindowFunction-BlackmanNuttall 'EyeTracking.WindowFunction.BlackmanNuttall')
  - [FlatTop](#F-EyeTracking-WindowFunction-FlatTop 'EyeTracking.WindowFunction.FlatTop')
  - [Hamming](#F-EyeTracking-WindowFunction-Hamming 'EyeTracking.WindowFunction.Hamming')
  - [HammingPeriodic](#F-EyeTracking-WindowFunction-HammingPeriodic 'EyeTracking.WindowFunction.HammingPeriodic')
  - [Hann](#F-EyeTracking-WindowFunction-Hann 'EyeTracking.WindowFunction.Hann')
  - [HannPeriodic](#F-EyeTracking-WindowFunction-HannPeriodic 'EyeTracking.WindowFunction.HannPeriodic')
  - [Lanczos](#F-EyeTracking-WindowFunction-Lanczos 'EyeTracking.WindowFunction.Lanczos')
  - [LanczosPeriodic](#F-EyeTracking-WindowFunction-LanczosPeriodic 'EyeTracking.WindowFunction.LanczosPeriodic')
  - [Nuttall](#F-EyeTracking-WindowFunction-Nuttall 'EyeTracking.WindowFunction.Nuttall')
  - [Rectangle](#F-EyeTracking-WindowFunction-Rectangle 'EyeTracking.WindowFunction.Rectangle')

<a name='T-EyeTracking-FIFO`1'></a>
## FIFO\`1 `type`

##### Namespace

EyeTracking

##### Summary

A FIFO Buffer Implementation for Visual C# using Generics.

<a name='M-EyeTracking-FIFO`1-#ctor-System-Int32-'></a>
### #ctor(bufferSize) `constructor`

##### Summary

Default Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bufferSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Buffer Size |

<a name='M-EyeTracking-FIFO`1-#ctor-EyeTracking-FIFO{`0}-'></a>
### #ctor(previousFIFO) `constructor`

##### Summary

Copy Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| previousFIFO | [EyeTracking.FIFO{\`0}](#T-EyeTracking-FIFO{`0} 'EyeTracking.FIFO{`0}') |  |

<a name='F-EyeTracking-FIFO`1-availableCount'></a>
### availableCount `constants`

##### Summary

Current available data count

<a name='F-EyeTracking-FIFO`1-buffer'></a>
### buffer `constants`

##### Summary

Buffer

<a name='F-EyeTracking-FIFO`1-getIndex'></a>
### getIndex `constants`

##### Summary

Current Get Index

<a name='F-EyeTracking-FIFO`1-hasPutIndexReachedMax'></a>
### hasPutIndexReachedMax `constants`

##### Summary

When the put index reached the length of the buffer, it will be true

<a name='F-EyeTracking-FIFO`1-putIndex'></a>
### putIndex `constants`

##### Summary

Current Put Index

<a name='M-EyeTracking-FIFO`1-Clear'></a>
### Clear() `method`

##### Summary

Clear the buffer

##### Parameters

This method has no parameters.

##### Remarks

Actually, it only initializes indexes.

<a name='M-EyeTracking-FIFO`1-GetAvailableDataCount'></a>
### GetAvailableDataCount() `method`

##### Summary

Get Available Data Count

##### Returns

Data Count

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-FIFO`1-GetBufferSize'></a>
### GetBufferSize() `method`

##### Summary

Get Buffer Size specified in the constructor

##### Returns

Buffer size

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-FIFO`1-GetData'></a>
### GetData() `method`

##### Summary

Get a data from the buffer

##### Returns

Generic Data

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-FIFO`1-PeekAllDataMixed'></a>
### PeekAllDataMixed() `method`

##### Summary

Get all data in the buffer, Mixed-up

##### Returns

Data Array

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-FIFO`1-PeekAllDataOrdered'></a>
### PeekAllDataOrdered() `method`

##### Summary

Get all data in the buffer, Ordered from oldest to newest

##### Returns

Data Array

##### Parameters

This method has no parameters.

<a name='M-EyeTracking-FIFO`1-PeekData'></a>
### PeekData() `method`

##### Summary

Get a data from the buffer (Don't touch indexes)

##### Returns

Generic Data

##### Parameters

This method has no parameters.

##### Remarks

If you call this twice, same data will be delivered.

<a name='M-EyeTracking-FIFO`1-PutData-`0-'></a>
### PutData(data) `method`

##### Summary

Put a data to the buffer

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [\`0](#T-`0 '`0') | Generic Data |

##### Remarks

When the buffer is full, it OVERWRITES existing data.

<a name='M-EyeTracking-FIFO`1-op_Addition-EyeTracking-FIFO{`0},`0-'></a>
### op_Addition(fifo,data) `method`

##### Summary

Operator overload for "+=" operator

##### Returns

New FIFO

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fifo | [EyeTracking.FIFO{\`0}](#T-EyeTracking-FIFO{`0} 'EyeTracking.FIFO{`0}') | Destination FIFO |
| data | [\`0](#T-`0 '`0') | Put data(Generic) |

<a name='T-EyeTracking-FrequencyRange'></a>
## FrequencyRange `type`

##### Namespace

EyeTracking

##### Summary

Struct type for representation of frequency range

<a name='M-EyeTracking-FrequencyRange-#ctor-System-Single,System-Single-'></a>
### #ctor(min,max) `constructor`

##### Summary

Initializer for freq range

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| min | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Min freq |
| max | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Max freq |

<a name='F-EyeTracking-FrequencyRange-Max'></a>
### Max `constants`

##### Summary

Max freq

<a name='F-EyeTracking-FrequencyRange-Min'></a>
### Min `constants`

##### Summary

Min freq

<a name='T-EyeTracking-LFHFComputeStatus'></a>
## LFHFComputeStatus `type`

##### Namespace

EyeTracking

##### Summary

Enum type for states of lfhf computer

<a name='F-EyeTracking-LFHFComputeStatus-Error'></a>
### Error `constants`

##### Summary

An error was occurred

<a name='F-EyeTracking-LFHFComputeStatus-Processing'></a>
### Processing `constants`

##### Summary

In progress of processing

<a name='F-EyeTracking-LFHFComputeStatus-Ready'></a>
### Ready `constants`

##### Summary

Ready for get latest lfhf ratio

<a name='T-EyeTracking-LFHFComputer'></a>
## LFHFComputer `type`

##### Namespace

EyeTracking

##### Summary

A Class for computing lfhf ratio from pupil data array

##### Remarks

Use "power spectrum" ratio as result

<a name='M-EyeTracking-LFHFComputer-#ctor-System-Int32,EyeTracking-FrequencyRange,EyeTracking-FrequencyRange,System-Int32-'></a>
### #ctor(processFrequency,lfRange,hfRange,windowSize) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| processFrequency | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | [int] Frequency for processing pupil data |
| lfRange | [EyeTracking.FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange') | [FrequencyRange] Frequency range of LF |
| hfRange | [EyeTracking.FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange') | [FrequencyRange] Frequency range of HF |
| windowSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | [int] Window size, Length of pupil data array. (2^0 to 2^16) |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | The given processFrequency or windowSize is incorrect |

<a name='M-EyeTracking-LFHFComputer-#ctor-System-Int32,EyeTracking-FrequencyRange,EyeTracking-FrequencyRange,System-Int32,EyeTracking-WindowFunction-'></a>
### #ctor(processFrequency,lfRange,hfRange,windowSize,windowFunction) `constructor`

##### Summary

Overloaded constructor for select window function.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| processFrequency | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | [int] Frequency for processing pupil data |
| lfRange | [EyeTracking.FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange') | [FrequencyRange] Frequency range of LF |
| hfRange | [EyeTracking.FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange') | [FrequencyRange] Frequency range of HF |
| windowSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | [int] Window size, Length of pupil data array. (2^0 to 2^16) |
| windowFunction | [EyeTracking.WindowFunction](#T-EyeTracking-WindowFunction 'EyeTracking.WindowFunction') | [WindowFunction] Window Function |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | The given processFrequency or windowSize is incorrect |

<a name='F-EyeTracking-LFHFComputer-window'></a>
### window `constants`

##### Summary

Window for applying

<a name='P-EyeTracking-LFHFComputer-FrequencyResolution'></a>
### FrequencyResolution `property`

##### Summary

Frequency resolution

<a name='P-EyeTracking-LFHFComputer-HFRange'></a>
### HFRange `property`

##### Summary

Frequency range of hf

<a name='P-EyeTracking-LFHFComputer-LFRange'></a>
### LFRange `property`

##### Summary

Frequency range of lf

<a name='P-EyeTracking-LFHFComputer-WindowSize'></a>
### WindowSize `property`

##### Summary

Window size

<a name='M-EyeTracking-LFHFComputer-ApplyWindow-System-Single[]-'></a>
### ApplyWindow(floatArray) `method`

##### Summary

Apply specified window in the constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| floatArray | [System.Single[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single[] 'System.Single[]') | Data for windowing |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Array is too long or too short |

<a name='M-EyeTracking-LFHFComputer-ComputeLFHFFrom-EyeTracking-PupilDataForProcess[],System-Single-'></a>
### ComputeLFHFFrom(pupilDataArray,pupilDiameterAverage) `method`

##### Summary

Compute LF/HF ratio from the given pupil data array

##### Returns

[float] LF/HF ratio

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pupilDataArray | [EyeTracking.PupilDataForProcess[]](#T-EyeTracking-PupilDataForProcess[] 'EyeTracking.PupilDataForProcess[]') | [PupilDataForProcess[]] Pupil data array |
| pupilDiameterAverage | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | [float] Average of valid pupil diameters |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Pupil data array is too long or too short |

##### Remarks

Use the given average if the first or last diameter is invalid, so lighter than the other one.

<a name='M-EyeTracking-LFHFComputer-ComputeLFHFFrom-EyeTracking-PupilDataForProcess[]-'></a>
### ComputeLFHFFrom(pupilDataArray) `method`

##### Summary

[Overload] Compute LF/HF ratio from the given pupil data array

##### Returns

[float] LF/HF ratio

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pupilDataArray | [EyeTracking.PupilDataForProcess[]](#T-EyeTracking-PupilDataForProcess[] 'EyeTracking.PupilDataForProcess[]') | [PupilDataForProcess[]] Pupil data array |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Pupil data array is too long or too short |

##### Remarks

Calculate the average of all valid pupil diameters automatically.

<a name='M-EyeTracking-LFHFComputer-ExecuteFFT-System-Single[]-'></a>
### ExecuteFFT(floatArray) `method`

##### Summary

Execute FFT

##### Returns

[Complex[]] Array of fourier spectrums

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| floatArray | [System.Single[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single[] 'System.Single[]') | Data for convert |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Array is too long or too short |

<a name='M-EyeTracking-LFHFComputer-LerpPupilDiameter-EyeTracking-PupilDataForProcess[],System-Single-'></a>
### LerpPupilDiameter(pupilDataArray,validAverage) `method`

##### Summary

Linear Interpolate pupil diameters, if necessary.
If the first or last data is invalid (need for interpolate), replace it by the given average of valid diameters.

##### Returns

[float[]] Interpolated pupil diameters

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pupilDataArray | [EyeTracking.PupilDataForProcess[]](#T-EyeTracking-PupilDataForProcess[] 'EyeTracking.PupilDataForProcess[]') | [PupilDataForProcess[]] Pupil data array |
| validAverage | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | [float] Average of all valid pupil dimeters |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Pupil data array is too long or too short |

<a name='T-EyeTracking-LerpStatus'></a>
## LerpStatus `type`

##### Namespace

EyeTracking

##### Summary

Enum type for states of lerp process

<a name='F-EyeTracking-LerpStatus-Interpolating'></a>
### Interpolating `constants`

##### Summary

Interpolating invalid data

<a name='F-EyeTracking-LerpStatus-NoInterpolationNecessary'></a>
### NoInterpolationNecessary `constants`

##### Summary

Valid data is existing, no lerp needed

<a name='T-EyeTracking-PupilDataForProcess'></a>
## PupilDataForProcess `type`

##### Namespace

EyeTracking

##### Summary

Struct type for pupil data processing

<a name='M-EyeTracking-PupilDataForProcess-#ctor-System-Single,System-Boolean-'></a>
### #ctor(diameter,isvalid) `constructor`

##### Summary

Initializer for pupil data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| diameter | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Pupil diameter |
| isvalid | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Pupil data validity |

<a name='F-EyeTracking-PupilDataForProcess-Diameter'></a>
### Diameter `constants`

##### Summary

Pupil diameter

<a name='F-EyeTracking-PupilDataForProcess-IsValid'></a>
### IsValid `constants`

##### Summary

Pupil data validity

<a name='T-EyeTracking-PupilDataProcessor'></a>
## PupilDataProcessor `type`

##### Namespace

EyeTracking

##### Summary

Main Class

##### Remarks

All floating point variables are float.

<a name='M-EyeTracking-PupilDataProcessor-#ctor-System-Int32,EyeTracking-FrequencyRange,EyeTracking-FrequencyRange,System-Int32,System-Int32,EyeTracking-WindowFunction-'></a>
### #ctor(eyeTrackingFrequency,lfRange,hfRange,lfhfWindowSize,lfhfHopSize,windowFunction) `constructor`

##### Summary

Constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eyeTrackingFrequency | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Frequency of eye tracking |
| lfRange | [EyeTracking.FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange') | LF range |
| hfRange | [EyeTracking.FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange') | HF range |
| lfhfWindowSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Window size (points) for fft (2^0 to 2^16) |
| lfhfHopSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Hop size (points - overlap) for fft |
| windowFunction | [EyeTracking.WindowFunction](#T-EyeTracking-WindowFunction 'EyeTracking.WindowFunction') | Window function for fft |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | The given eyeTrackingFrequency or windowSize is out of range |

<a name='M-EyeTracking-PupilDataProcessor-#ctor-System-Int32,EyeTracking-FrequencyRange,EyeTracking-FrequencyRange,System-Single,System-Single-'></a>
### #ctor(eyeTrackingFrequency,lfRange,hfRange,lfhfIdealFrequencyResolution,lfhfComputeSpanInSec) `constructor`

##### Summary

Overloaded constructor, smart version

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eyeTrackingFrequency | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Frequency of eye tracking |
| lfRange | [EyeTracking.FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange') | LF range |
| hfRange | [EyeTracking.FrequencyRange](#T-EyeTracking-FrequencyRange 'EyeTracking.FrequencyRange') | HF range |
| lfhfIdealFrequencyResolution | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Ideal frequency resolution for fft. Acutual resolution is same or smaller. |
| lfhfComputeSpanInSec | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Time span for computing LF/HF ratio. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | The given eyeTrackingFrequency or lfhfIdealFrequencyResolution is incorrect |

<a name='F-EyeTracking-PupilDataProcessor-dataBuffer'></a>
### dataBuffer `constants`

##### Summary

Pupil data buffer

<a name='F-EyeTracking-PupilDataProcessor-hasDataBufferFilledOnce'></a>
### hasDataBufferFilledOnce `constants`

##### Summary

If the data buffer is filled with pupil data once, be true

<a name='F-EyeTracking-PupilDataProcessor-hopCount'></a>
### hopCount `constants`

##### Summary

Hop count (new data count) for LFHF

<a name='F-EyeTracking-PupilDataProcessor-lfhfComputer'></a>
### lfhfComputer `constants`

##### Summary

LFHF Computer instance

<a name='F-EyeTracking-PupilDataProcessor-validPupilDiameterCount'></a>
### validPupilDiameterCount `constants`

##### Summary

Valid pupil diameter count for average calculation

<a name='P-EyeTracking-PupilDataProcessor-HopSize'></a>
### HopSize `property`

##### Summary

Hop size (points - overlap) for LFHF fft

<a name='P-EyeTracking-PupilDataProcessor-LatestAverageValidDiameter'></a>
### LatestAverageValidDiameter `property`

##### Summary

Latest average of all valid diameters

<a name='P-EyeTracking-PupilDataProcessor-LatestLFHF'></a>
### LatestLFHF `property`

##### Summary

Latest LFHF ratio

<a name='P-EyeTracking-PupilDataProcessor-LatestMaxDiameter'></a>
### LatestMaxDiameter `property`

##### Summary

Latest maximum diameter

<a name='P-EyeTracking-PupilDataProcessor-LatestMinDiameter'></a>
### LatestMinDiameter `property`

##### Summary

Latest minimum diameter

<a name='P-EyeTracking-PupilDataProcessor-WindowSize'></a>
### WindowSize `property`

##### Summary

Window size (points) for LFHF fft

<a name='M-EyeTracking-PupilDataProcessor-UpdateWith-EyeTracking-PupilDataForProcess-'></a>
### UpdateWith(pupilData) `method`

##### Summary

Update with an pupil data

##### Returns

[LFHFComputeStatus] The status after the new data was added

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pupilData | [EyeTracking.PupilDataForProcess](#T-EyeTracking-PupilDataForProcess 'EyeTracking.PupilDataForProcess') | a new pupil data |

##### Example

This shows how to use this method:

```
private void AMethodCalledEveryCycle(float leftPD, float rightPD, bool validity)
{
    PupilDataForProcess newData;
    newData.PupilDiameter = (leftPD + rightPD) / 2.0f;
    newData.Validity = validity;
    if(this.processor.UpdateWith(newData) == LFHFComputeStatus.Ready)
    {
        float lfhf = this.processor.LatestLFHF;
        Debug.Print($"LFHF: {lfhf}");
    }
}
```

<a name='T-EyeTracking-WindowFunction'></a>
## WindowFunction `type`

##### Namespace

EyeTracking

##### Summary

Enum type for window functions

<a name='F-EyeTracking-WindowFunction-BartlettHann'></a>
### BartlettHann `constants`

##### Summary

BartlettHann

<a name='F-EyeTracking-WindowFunction-Blackman'></a>
### Blackman `constants`

##### Summary

Blackman

<a name='F-EyeTracking-WindowFunction-BlackmanHarris'></a>
### BlackmanHarris `constants`

##### Summary

BlackmanHarris

<a name='F-EyeTracking-WindowFunction-BlackmanNuttall'></a>
### BlackmanNuttall `constants`

##### Summary

BlackmanNuttall

<a name='F-EyeTracking-WindowFunction-FlatTop'></a>
### FlatTop `constants`

##### Summary

Flattop

<a name='F-EyeTracking-WindowFunction-Hamming'></a>
### Hamming `constants`

##### Summary

Hamming

<a name='F-EyeTracking-WindowFunction-HammingPeriodic'></a>
### HammingPeriodic `constants`

##### Summary

HammingPeriodic

##### Remarks

Recommended for fft purposes than normal Hamming

<a name='F-EyeTracking-WindowFunction-Hann'></a>
### Hann `constants`

##### Summary

Hann

<a name='F-EyeTracking-WindowFunction-HannPeriodic'></a>
### HannPeriodic `constants`

##### Summary

HannPeriodic

##### Remarks

Recommended for fft purposes than normal Hann

<a name='F-EyeTracking-WindowFunction-Lanczos'></a>
### Lanczos `constants`

##### Summary

Lanczos

<a name='F-EyeTracking-WindowFunction-LanczosPeriodic'></a>
### LanczosPeriodic `constants`

##### Summary

LanczosPeriodic

##### Remarks

Recommended for fft purposes than normal Lanczos

<a name='F-EyeTracking-WindowFunction-Nuttall'></a>
### Nuttall `constants`

##### Summary

Nuttall

<a name='F-EyeTracking-WindowFunction-Rectangle'></a>
### Rectangle `constants`

##### Summary

Rectangle

##### Remarks

aka Dirichlet
