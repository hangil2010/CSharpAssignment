namespace _250313_개인실습2
{
    //과제 4. 별찍기 기능 구현
    // 중첩반복문을 활용하여 아래 그림처럼 출력하는 네가지 프로그램을 각각 작성하여 보자.
    // Tip : Console.Write(" "); 를 쓰면 빈 공백 하나를, Console.Write("*");을 쓰면 별 하나를 출력할 수 있다.
    // 피라미드를 만들자
    // 1. 좌측정렬 1~5개, 2. 우측정렬 1~5개, 3. 좌측정렬 5~1개, 4. 우측정렬 1~5개
    // 1-4와 2-3이 서로 반전이라 1, 4번을 한다음 조건만 뒤집으면 될 것 같음
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1번 좌측정렬 1~5개 별 그리기.
            Console.WriteLine("1번 피라미드");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j <= i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            
            // 2번 우측정렬 1~5개 별 그리기.
            Console.WriteLine("2번 피라미드");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 4; j >= 0; j--)
                {
                    if (j <= i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            // 3번 좌측정렬 5~1개 별 그리기, 2번 피라미드의 출력 방식을 바꾸면 끝?
            Console.WriteLine("3번 피라미드");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 4; j >= 0; j--)
                {
                    if (j < i)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }

            // 4번 우측정렬 5~1개 별 그리기, 1번 피라미드의 출력 방식만 바꾸면 바로 된다.
            Console.WriteLine("4번 피라미드");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j < i)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
