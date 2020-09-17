using System;

namespace TestWebApp.TestModels
{
    public class SimpleTestClass
    {
        public int Summ(params int[] values)
        {
            int sum = 0;
            foreach (int value in values)
            {
                if (value <= 0)
                    continue;
                sum += value;
            }

            return sum;
        }
    }
}