using System;
using System.Text;

namespace mathTasks
{
    public class ValueHelper
    {


        public static int GetInt(string message, int min, int max, ValueType type)
        {
            while (true)
            {
                Console.WriteLine(message);
                var text = Console.ReadLine();
                var convertedResult = Verification(text, min, max, type);
                if (convertedResult.IsFailure)
                {
                    Console.WriteLine(convertedResult.Message);
                    continue;
                }

                var nConverted = convertedResult.Value;
                return nConverted;
            }
        }


        private static VerificationResult<int> Verification(string text, int minValue, int maxValue, ValueType type)
        {
            if (!int.TryParse(text, out var value))
            {
                return new VerificationResult<int>().Fail("Только цифры!");
            }

            var result = new StringBuilder() { };
            var isValidValue = true;
            if (value < minValue || value > maxValue)
            {
                result.Append($"Число должно быть в диапазоне ОТ {minValue} ДО {maxValue}");
                isValidValue = false;
            }

            switch (type)
            {
                case ValueType.Odd when value % 2 == 0:
                    result.Append("\nЧисло должно быть НЕЧЕТНЫМ");
                    isValidValue = false;
                    break;
                case ValueType.Even when value % 2 != 0:
                    result.Append("\nЧисло должно быть ЧЕТНЫМ");
                    isValidValue = false;
                    break;
            }

            return isValidValue
                ? new VerificationResult<int>().Success(value)
                : new VerificationResult<int>().Fail(result.ToString());
        }
    }

    public class VerificationResult<T>
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public string Message { get; private set; }
        public T? Value { get; private set; }

        public VerificationResult<T> Success(T result) =>
            new VerificationResult<T>() {Value = result, IsSuccess = true, Message = string.Empty};

        public VerificationResult<T> Fail(string message) =>
            new VerificationResult<T>() {Value = default(T), IsSuccess = false, Message = message};
    }
    public enum ValueType
    {
        All,
        Odd,
        Even
    }
}