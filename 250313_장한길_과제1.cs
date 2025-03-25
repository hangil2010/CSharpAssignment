namespace _250313_개인실습
{
    internal class Program
    {
        /*
        과제 1. 다수의 입력을 받아 연산하는 기능 구현, 사용자로부터 정수를 연속해서 입력 받아 수를 더하는 기능을 제작하시오
        1. "두 수 사이의 합을 구합니다. 시작할 작은 수를 입력하여주세요" 출력
        2. 시작할 수 입력 받기
        3. "끝 수를 입력해주세요" 출력
        4. 마지막 수 입력 받기
        5. 반복문을 통하여 시작부터 끝 수까지 합을 임의의 변수에 저장
        6. 반복문이 끝난 후 "n1과 n2 사이 숫자의 합은 n3입니다" 출력

        n~m까지의 합 : (n부터 m까지의 갯수) * (n+m) / 2 
        n~m까지의 합 : (( m - n + 1 ) * (n + m)) / 2, for 쓰는것보단 더 간단할 것으로 예상? 결과는 똑같다.
        */
        static void Main(string[] args)
        {
            int startValue;
            int endValue;
            int sumValue = 0;
            int sumValueTest = 0;
            bool inputErrorCheck = false;
            while (true)
            {
                Console.Write("두 수 사이의 합을 구합니다. 시작할 작은 수를 입력하여주세요 : ");
                inputErrorCheck = int.TryParse(Console.ReadLine(), out startValue);
                if (inputErrorCheck == false)
                {
                    Console.WriteLine("잘못된 값을 입력하였습니다. 다시 입력해주세요");
                }
                else break;
            }
            while (true)
            {
                Console.Write("끝 수를 입력해주세요 : ");
                inputErrorCheck = int.TryParse(Console.ReadLine(), out endValue);
                if (inputErrorCheck == false)
                {
                    Console.WriteLine("잘못된 값을 입력하였습니다. 다시 입력해주세요");
                }
                else if (endValue < startValue)
                {
                    Console.WriteLine("시작 값이 끝값보다 더 큽니다. 다시 입력해주세요");
                }
                else break;
            }
            // for(int i = startValue; i <= endValue; i++)
            // {
            //     sumValue += i;
            // }
            sumValueTest = ((endValue - startValue + 1) * (startValue + endValue)) / 2;

            // Console.WriteLine($"{startValue}과 {endValue}사이 숫자의 합은 {sumValue}입니다.");
            Console.WriteLine($"{startValue}과 {endValue}사이 숫자의 합은 {sumValueTest}입니다.");
        }
    }
}
