using System.Diagnostics;

namespace ex08_generics
{
    internal class Program
    {
        // 배열 복사 기능 -> 일반화 프로그래밍
        // 메서드 뒤에 <T>, 매개변수의 타입대신 T로 변경
        static void CopyArray<T>(T[] src, T[] dest)
        {
            for (int i = 0; i < src.Length; i++)
                dest[i] = src[i]; 
        }

        //static void CopyArray(float[] src, float[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //        dest[i] = src[i];
        //}

        //static void CopyArray(string[] src, string[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //        dest[i] = src[i];
        //}

        //static void CopyArray(double[] src, double[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //        dest[i] = src[i];
        //}

        //static void CopyArray(bool[] src, bool[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //        dest[i] = src[i];
        //}

        //static void CopyArray(int[] src, float[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //        dest[i] = (float) src[i];
        //}

        static void Main(string[] args)
        {
            int[] array1 = { 10, 20, 30, 50, 70 };
            int[] array2 = new int[array1.Length];

            CopyArray<int>(array1, array2);
            Console.WriteLine(array2[4]);

            float[] array3 = { 3.4f, 2.2f, 7.7f };
            float[] array4 = new float[array3.Length];

            CopyArray<float>(array3, array4);
            Console.WriteLine(array4[0]);

            string[] array5 = { "H", "B", "C", "D", "E" };
            string[] array6 = new string[array5.Length];

            CopyArray<string>(array5, array6);

            double[] array7 = { 11.4, 5.6, 7.8, 9.9 };
            double[] array8 = new double[array7.Length];

            CopyArray<double>(array7, array8);

            bool[] array9 = { true, false, };
            bool[] array10 = new bool[array9.Length];

            CopyArray<bool>(array9, array10);

            int[] array11 = { 1, 2, 3, 4, };
            float[] array12 = new float[array11.Length];

            // CopyArray(array11, array12);
        }
    }
}
