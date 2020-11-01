namespace TestLib
{
    public static class StaticWithExtensions
    {
        private static int a = 0;

        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }

    struct StructTest
    {
        private int a;
        public int A { get; set; }

        public int TestMethod(int a)
        {
            return -a;
        }
    }
}
