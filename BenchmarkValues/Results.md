
BenchmarkDotNet = v0.13.1, OS = Windows 10.0.18363.2274(1909 / November2019Update / 19H2)
Intel Core i7-10850H CPU 2.70GHz, 1 CPU, 12 logical and 6 physical cores
[Host]     : .NET Core 3.1.22 (CoreCLR 4.700.21.56803, CoreFX 4.700.21.57101), X64 RyuJIT



    |                   Method |      Mean |    Error  |    StdDev  | Rank  |  Gen 0  | Allocated  |
    |------------------------- |----------:| ---------:| ----------:| -----:| -------:| ----------:|
    | GetYearFromDateSpan      | 20.89 ns  | 0.439 ns  | 0.556 ns   | 1     | -       | -          |
    | GetYearFromDateSubString | 27.22 ns  | 0.220 ns  | 0.184 ns   | 2     | 0.0051  | 32 B       |
    | GetYearFromDateSplit     | 87.60 ns  | 1.612 ns  | 2.648 ns   | 3     | 0.0254  | 160 B      |
    | GetYear                  | 310.79 ns | 6.238 ns  | 11.248 ns  | 4     | -       | -          |