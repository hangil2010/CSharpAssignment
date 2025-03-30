using System.Security.Authentication.ExtendedProtection;

namespace _250328_과제
{
    
    // 기본 크기를 10으로 하는 MyStack 클래스 생성
    // 클래스 생성시 값을 입력하면 원하는 크기로 설정하게 함.
    public class MyStack<T>(int size = 10)
    {
        // 스택의 역할을 대신할 size 크기의 배열 stacks를 생성
        // Stack 처럼 추가, 제거하기 위한 인덱스값 index 
        public T[] stacks = new T[size];
        private int index = 0;
        // 값을 추가하는 방식
        // index가 stacks의 길이보다 길어지는 경우 배열의 크기를 2배로 하고 추가
        // 예시) index = 11 , stacks.Length = 10 일 경우 추가가 되지 않는다
        // 그렇기 때문에 stacks의 길이를 2배인 20으로 늘린 이후 추가한다.
        // 추가 배열을 생성해서 복사하는 것보다 기존 배열의 크기를 그대로 2배로 늘리는 방식을 채택
        // 기존 Array.Resize(바꿀 배열, 바꿀 길이) 함수를 활용
        public void Push(T element)
        {
            if(index >= stacks.Length)
            {
                Console.WriteLine("공간이 가득 찼습니다!, 2배로 확장합니다");
                Array.Resize(ref stacks, stacks.Length * 2);
                Console.WriteLine($"바뀐 배열의 길이 : {stacks.Length}");
            }
            stacks[index] = element;
            index++;
            Console.WriteLine($"{element}를 {index - 1}번째 위치에 추가, 다음 추가 위치 : {index}");
        }
        // index가 다음 추가할 값의 위치를 나타내기 때문에 Pop, Peek 둘다 index 값을 하나 빼고 함수를 수행
        // 우선 값을 반환할 result 변수를 선언 하고 최근 추가된 값을 저장
        // Pop는 실제 값을 제거하기 때문에 최근 추가된 값을 기본형(default)로 바꾸는 방식을 채택
        // index를 왼쪽으로 옮겨 다음 추가될 위치를 재설정.
        public T Pop()
        {
            T result = stacks[index - 1];
            Console.WriteLine($"{index - 1}번째 위치의 값 {result}를 반환 및 제거");
            stacks[index - 1] = default;
            index--;
            return result;
        }
        public T Peek()
        {
            return stacks[index - 1];
        }
        // 배열의 내부 요소들을 초기화하는 Array.Clear(배열)을 활용
        // 인덱스 값을 초기화하여 다음 값이 추가할 위치를 재설정.
        public void Clear()
        {
            Array.Clear(stacks);
            index = 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            myStack.Push(6);
            myStack.Push(7);
            myStack.Push(8);
            myStack.Push(9);
            myStack.Push(10);
            myStack.Pop();
            myStack.Push(10);
            Console.WriteLine($"수제 스택의 가장 위의 값 반환: {myStack.Pop()}");
            Console.WriteLine($"수제 스택의 가장 위의 값 참조: {myStack.Peek()}");
            myStack.Pop();
            myStack.Clear();
            myStack.Push(4);
        }
    }
}
