namespace _250314._기본실습
{
    internal class Program
    {
        // 이 변수는 Program class 내부의 값으로 모든 함수에 써먹을 수 있다.
        private static int _repeatCount = 0;

        static void Main(string[] args)
        {
            // Main 함수의 내용은 변경하지 않습니다.
            // Main 이외의 함수(IsZero, InputPlayerHealth, PrintPlayerHealth)를 완성하시면 됩니다.
            // playerHealth 변수는 Main 함수에만 존재하며 여기서만 써먹을 수 있다.
            int playerHealth;

            while (true)
            {
                _repeatCount++;

                playerHealth = InputPlayerHealth();

                PrintRepeatCount();

                if (IsZero(playerHealth))
                {
                    Console.WriteLine("Game Over - 게임 종료");
                    break;
                }
            }
        }

        static bool IsZero(int value)
        {
            // bool 타입의 데이터를 반환
            // 매개변수로 입력받은 데이터가 0 이하라면 true 반환
            // 매개변수로 입력받은 데이터가 0 초과라면 false 반환
            // 3항 연산자를 써보자 -> 조건 ? 맞을때 : 틀릴때 ;
            return (value <= 0) ? true : false;
        }

        static int InputPlayerHealth()
        {
            // Console.ReadLine()을 사용해 사용자 입력 받기
            // 0이상 100 이하의 숫자 외의 데이터가 입력된 경우 숫자를 입력받을 때 까지 반복해서 입력 받기
            // 숫자가 정상적으로 입력된 경우 int 타입으로 변환해 반환
            // 조건 1 : 정수가 입력되야 한다, 조건 2 : 0~100의 값이 입력되어야 한다
            bool inputCheck;
            int playerHealth;
            while (true)
            {
                Console.Write("0이상 100이하의 값을 입력해 주십시오 : ");
                inputCheck = int.TryParse(Console.ReadLine(), out playerHealth);
                if (inputCheck == false || (playerHealth < 0 || playerHealth > 100))
                {
                    Console.WriteLine("정수 의외의 값이나 0미만 100초과의 값이 입력되었습니다. 0이상 100 이하의 정수를 다시 입력해 주십시오.");
                }
                else if (inputCheck == true)
                {
                    break;
                }
            }
            return playerHealth;
        }

        static void PrintRepeatCount()
        {
            // 반복문이 몇 번 출력되었는지 출력한다
            // 출력 양식 : "반복문이 출력된 횟수는 {_repeatCount} 입니다."
            Console.WriteLine($"반복문이 출력된 횟수는 {_repeatCount} 입니다.");
        }
    }
}
