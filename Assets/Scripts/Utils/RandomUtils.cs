using System;

namespace Utils
{
    public static class RandomUtils
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            return s_random.Next(min, max + 1);
        }

        public static float GetFloatRandomNumber()
        {
            return (float)s_random.NextDouble();
        }
    }
}