# Solution

1. Create Solution: solution name FizzBuzz

    ```sh
    dotnet new sln -o <solution-name>
    ```

    eg.

    ```sh
    dotnet new sln -o FizzBuzz
    ```

2. Change Directory to FizzBuzz

    ```sh
    cd FizzBuzzs
    ```

3. Create Test Project

    ```sh
    dotnet new xunit -o <projectname>
    ```

    eg.

    ```sh
    dotnet new xunit -o FizzBuzz.Test
    ```

4. Create Production Project

    ```sh
    dotnet new classlib -o <projectname>
    ```

    eg.

    ```sh
    dotnet new classlib -o FizzBuzz
    ```

5. Add Reference to Test Project

    ```sh
    dotnet add <test project> reference <reference project>
    ```

    eg.

    ```sh
    dotnet add FizzBuzz.Test reference FizzBuzz
    ```