# BenchmarkDotNet Demo

## Init Workspace

    ```sh
    dotnet new sln -o ConcatBench
    cd ConcatBench
    dotnet new classlib -o Concat
    dotnet new console -o Concat.Bench
    dotnet sln add Concat
    dotnet sln add Concat.Bench
    dotnet add Concat.Bench reference Concat
    dotnet add Concat.Bench package BenchmarkDotNet 
    ```

## Implement Concat
    
    ```csharp
    using System.Text;
    
    namespace Concat;
    
    public class Simple
    {
        public string Concat(int range)
        {
            string result = String.Empty;
            for (int i = 0; i < range; i++)
            {
                result += i;
            }
            return result;
        }
    }
    
    public class Builder
    {
        public string Concat(int range)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < range; i++)
            {
                builder.Append(i);
            }
            
            return builder.ToString();
        }
    }
    ```

## Implement Concat.Bench
    
    ```csharp
    
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    
    namespace Concat.Bench;
    
    public class ConcatBenchmark
    {
        [Benchmark]
        public void BenchSimple()
        {
            Simple simple = new Simple();
            simple.Concat(1000);
        }
    
        [Benchmark]
        public void BenchBuilder()
        {
            Builder builder = new Builder();
            builder.Concat(1000);
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ConcatBenchmark>();
        }
    }
    ```

- [MemoryDiagnoser]
- [RPlotExporter]

## Run Benchmark
    
    ```sh
    dotnet run -c RELEASE
    ```
