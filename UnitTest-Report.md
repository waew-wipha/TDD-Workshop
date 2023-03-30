# Unit Test Report

1. HTML Test Report

   ```sh
   dotnet test --logger "html;logfilename=testResults.html"
   ```

2. JUnit Report

   - Install JUnitXml.TestLogger

     ```sh
     dotnet add package JunitXml.TestLogger
     ```

   - Run JUnit Report(ไม่ระบุ path)

     ```sh
     dotnet test --logger:junit
     ```

   - Run JUnit Report(ระบุ path)

     ```sh
     dotnet test --logger:"junit;LogFilePath=junit/test-result.xml"
     ```

## Code Coverage Report

1. Cobertura Report

   - Default format(cobertura)

     ```sh
     dotnet test --collect:"XPlat Code Coverage"
     ```

   - Multiple formats

     ```sh
     dotnet test --collect:"XPlat Code Coverage;Format=json,lcov,cobertura"
     ```

2. HTML Code Coverage Report

   - Install dotnet-reportgenerator-globaltool

     ```sh
     dotnet tool install -g dotnet-reportgenerator-globaltool
     ```

   - Install dotnet-reportgenerator-globaltool for Mac m1/m2

     ```sh
     dotnet tool install -g dotnet-reportgenerator-globaltool -a arm64
     ```

   - Generate html report

     ```sh
     reportgenerator -reports:"Path/To/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
     ```

---

## References:

1. [https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage)
2. [https://github.com/coverlet-coverage/coverlet](https://github.com/coverlet-coverage/coverlet)
3. [https://github.com/danielpalme/ReportGenerator](https://github.com/danielpalme/ReportGenerator)
4. [https://learn.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-coverage](https://learn.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-coverage)