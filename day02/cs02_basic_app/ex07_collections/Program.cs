using System.Collections;
using System.Runtime.InteropServices;

namespace ex07_collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5]; // 1. 초기화
            // Console.WriteLine(int.MaxValue); // C#에 각 타입의 최대값, 최소값
            array[0] = 80;
            array[1] = 81;
            array[2] = 100;
            array[3] = 34;
            array[4] = 98;
            // array[5] = 100;

            // 2. 초기화 선언하면서 값을 바로 지정
            int[] score = new int[5] { 80, 74, 81, 90, 34 };
            // 3. 초기화 배열의 크기를 생략
            string[] names = new string[] { "hello", "world", "C#!" };
            // 4. 초기화 그냥 다 생략
            float[] points = { 3.14f, 5.5f, 4.4f, 10.8f };   
                
            // 타입확인
            Console.WriteLine($"배열 타입 : {score.GetType()}");
            Console.WriteLine($"배열 기본타입 : {score.GetType().BaseType}");

            foreach (var item in names)
            {
                Console.WriteLine($"문자열은, {item}");
            }

            Console.WriteLine(score.Length);

            Array.Sort(score); // 정렬

            foreach (var item in score)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine("");

            Console.WriteLine(Array.BinarySearch(score, 90)); // 4 인덱스 4에 90이 존재한다
            Console.WriteLine(Array.IndexOf(score, 90)); // 4 인덱스 4에 90이 존재한다

            // 배열분할. C# 8.0부터 파이썬 배열 슬라이스기능 도입
            char[] array2 = new char[26]; // ['Z' - 'A' + 1];  90 - 65 + 1
            for (int i = 0; i < array2.Length; i++) 
                array2[i] = (char)('A' + i); // ABCDEF...Z

            foreach (var item in array2)
            {
                Console.Write(item);
            }
            Console.WriteLine(); // 굳이 이렇게 복잡하게 출력할 필요없음

            // 배열 분할 전
            Console.WriteLine(array2);
            // 배열 분할 - 시작인덱스..종료인덱스+1
            Console.WriteLine(array2[..]); // System.Range
            Console.WriteLine(array2[5..]); // System.Range
            Console.WriteLine(array2[5..11]); // System.Range

            // 2차원배열, 3차원배열, 가변배열 등 C++와 동일.

            /* 컬렉션
             * 
             */
            // ArrayList
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add(array2);
            arrayList.Add(true);
            arrayList.Add("Hi");

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(arrayList.Count); // ArrayList의 길이
            arrayList.RemoveAt(1); // ArrayList에서 인덱스 1번의 값을 삭제
            arrayList.Insert(2, 25); // 2번 인덱스에 25를 추가

            // Stack, Queue Python 자료구조에 배웠던 스택, 큐랑 차이없음!
            Stack stack = new Stack();
            stack.Push(1);
            stack.Pop();

            Queue que = new Queue();
            que.Enqueue(1);
            que.Dequeue();

            // Hashtable == Dictionary
            Hashtable ht = new Hashtable();
            ht["book"] = "책";
            ht["cook"] = "요리사";
            ht["programmer"] = "프로그래머";

            Console.WriteLine(ht["programmer"]);

            // foreach 가 가능한 객체 만들기
            var obj = new CustomEnumerator();
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
    }

    class CustomEnumerator 
    {
        int[] numbers = { 1, 2, 3, 4 }; // 임의로 마치 반복문(foreach)를 못쓴다고 가정

        // foreach로 사용할 수 없는 객체를 반복문을 쓸 수있도록 만들어주는 것
        public IEnumerator GetEnumerator() 
        {
            // 일반 return은 return문을 만나면 메서드를 빠져나감
            // yield return은 return문을 실행한 뒤 멈춰있음. 다음 yield return문을 실행하기 전까지
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break; // 모든 로직을 빠져나감.
            yield return numbers[3];
        }
    }
}
