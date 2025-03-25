using System.Runtime.InteropServices;

namespace _250325_개인실습
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 테스트 과정
            // 1. 새로운 트레이너를 생성 2. 현재 보유중인 포켓몬들 출력
            // 3. 6종류의 새 포켓몬 생성 4. 6종류의 새 포켓몬을 추가
            // 5. 출격할 포켓몬 숫자를 1~6 사이에 입력한다 6. 해당 포켓몬 출력
            // 7. 프로그램 종료(일단)
            // 고려사항.
            // 5. 1~6 의외의 정수나 아예 글자가 입력하는 경우 강제종료를 하지 않게 한다.
            Trainer trainer = new Trainer("철수");
            trainer.Print();
            Pikachu pikachu = new();
            Squritle squritle = new();
            Charmander charmander = new();
            Pideotto pideotto = new();
            Jigglypuff jigglypuff = new();
            Snorlax snorlax = new();
            Console.WriteLine("-----------------------------------------");
            // 추가 방법 1. 일일이 추가한다..
            //trainer.Add(pikachu);
            //trainer.Add(squritle);
            //trainer.Add(charmander);
            //trainer.Add(pideotto);
            //trainer.Add(jigglypuff);
            //trainer.Add(snorlax);

            // 추가 방법 2. 포켓몬이라는 부모 클래스의 자식들이기에 하나의 배열로 모아서 foreach 반복문을 통해 추가한다.
            Pokemon[] pokemons = new Pokemon[6] { pikachu, squritle, charmander, pideotto, jigglypuff, snorlax };
            foreach (var pokemon in pokemons)
            {
                trainer.Add(pokemon);
            }
            Console.WriteLine("-----------------------------------------");
            // 전체 포켓몬을 출력하고 출전할 포켓몬을 선택한다.
            trainer.Print();
            Console.Write("등장시킬 포켓몬을 고르시오 : ");
            trainer.Pick(Util.Input());
        }
        // 유틸리티성 함수들의 모음집
        // 1. 포켓몬을 부르기 위한 입력 함수 구현
        static public class Util
        {
            // int.TryParse가 bool값을 반환한다는 것을 참고, 우선 정수가 입력됬는지 체크한다.
            // 이후 result가 정상적으로 입력되면 그 값이 1~6사이의 값인지까지 확인
            // 둘중에 하나라도 false일 경우 조건문 전체가 false가 됨
            // while 반복문의 수행 조건이 조건식이 참이여야 이기에 조건문 전체에 !을 추가함으로 조건문을 반전시킨다.
            // 무엇이 문제인지 플레이어도 알 수 있게 입력값의 범위를 출력한다.
            static public int Input()
            {
                int result = 0;
                while (!(int.TryParse(Console.ReadLine(), out result) && (1 <= result && result <= 6)))
                {
                    Console.WriteLine("1~6 사이의 값을 입력해주세요~");
                }
                return result;
            }
        }
        // 트레이너 클래스
        // 필요 변수
        // - 트레이너 이름
        // - 포켓몬 보관소 6칸
        // 필요 기능
        // - 포켓몬 추가
        // - 포켓몬 선택
        // - 포켓몬 전체 출력
        public class Trainer
        {
            // 트레이너 이름, 포켓몬 보관소 6칸
            public string name;
            public Pokemon[] pokemons = new Pokemon[6];
            public Trainer(string name)
            {
                this.name = name;
            }
            // 트레이너가 포켓몬을 추가하는 함수
            // 매개변수 : 포켓몬 클래스
            // 보관소 전체를 돌면서 빈 자리가 있을 경우 그 자리에 포켓몬을 추가
            // 자리가 없을 경우 = 배열 끝까지 돌았음에도 반복문이 강제 종료되지 않았을 때
            // 반복문이 끝까지 갔을때 추가할 자리가 없음을 출력
            public void Add(Pokemon pokemon)
            {
                for (int i = 0; i < pokemons.Length; i++)
                {
                    if (pokemons[i] == null)
                    {
                        pokemons[i] = pokemon;
                        Console.WriteLine($"{pokemon.name}이/가 {i + 1}번에 추가되었습니다");
                        break;
                    }
                    if (i == pokemons.Length - 1)
                    {
                        Console.WriteLine("추가할 자리가 없습니다");
                    }
                }
            }
            // 트레이너가 포켓몬을 선택하는 함수
            // 인덱스 값을 받아 해당하는 배열의 포켓몬을 출력한다.
            // 문제사항 : 해당 위치에 포켓몬이 없을 경우?
            // 해결방법 : index위치를 찾아보고 null일 경우 빈자리임을 출력
            public void Pick(int index)
            {
                if (pokemons[index] != null)
                {
                    Console.WriteLine($"{index}번째 포켓몬을 꺼냅니다");
                    Console.WriteLine($"가라! {pokemons[index].name}");
                }
                else
                {
                    Console.WriteLine("빈 자리입니다.");
                }
            }
            // 트레이너가 가진 포켓몬 목록을 전부 출력하는 함수
            // 배열을 순회하면서 빈자리가 아닐 경우 이름, 스킬을 출력
            // 빈 자리일경우 n번째 포켓몬 자리는 비었음을 알려준다.
            public void Print()
            {
                int count = 1;
                foreach (var pokemon in pokemons)
                {
                    if (pokemon != null)
                    {
                        Console.WriteLine($"{count}번 포켓몬 이름 : {pokemon.name} 스킬 : {pokemon.skill}");
                    }
                    else
                    {
                        Console.WriteLine($"{count}번째 포켓몬은 비었습니다.");
                    }
                    count++;
                }
            }
        }
        // 포켓몬 추상 클래스
        // 공격 기능은 무조건 존재해야 하나 상세한건 미정
        // 공통된 이름, 스킬은 보유
        // 자식 클래스에서 무조건 구현하게 abstract으로 구성
        public abstract class Pokemon
        {
            public string name;
            public string skill;
            public abstract void Attack();
        }
        // 피카츄는 포켓몬이다.
        // 생성자로 이름과 스킬을 햘당해준다.
        // 각각 공격에 대해 이름과 스킬에 대해 출력한다.
        // 이후 상세한 스킬이 구현될때 각각에 맞는 스킬을 넣는다.
        public class Pikachu : Pokemon
        {
            public Pikachu()
            {
                name = "피카츄";
                skill = "백만 볼트";
            }
            public override void Attack()
            {
                Console.WriteLine($"{name}의 {skill} 공격!");
                Console.WriteLine("매우 효과적이였다");
            }
        }
        public class Squritle : Pokemon
        {
            public Squritle()
            {
                name = "꼬부기";
                skill = "물대포";
            }
            public override void Attack()
            {
                Console.WriteLine($"{name}의 {skill} 공격!");
                Console.WriteLine("효과적이였다");
            }
        }
        public class Charmander : Pokemon
        {
            public Charmander()
            {
                name = "파이리";
                skill = "불대문자";
            }
            public override void Attack()
            {
                Console.WriteLine($"{name}의 {skill} 공격!");
                Console.WriteLine("치명적이였다");
            }
        }
        public class Pideotto : Pokemon
        {
            public Pideotto()
            {
                name = "피죤";
                skill = "전광석화";
            }
            public override void Attack()
            {
                Console.WriteLine($"{name}의 {skill} 공격!");
                Console.WriteLine("효과가 부족했다...");
            }
        }
        public class Jigglypuff : Pokemon
        {
            public Jigglypuff()
            {
                name = "푸린";
                skill = "노래부르기";
            }
            public override void Attack()
            {
                Console.WriteLine($"{name}의 {skill} 공격!");
                Console.WriteLine("적이 잠들어버렸다!");
            }
        }
        public class Snorlax : Pokemon
        {
            public Snorlax()
            {
                name = "잠만보";
                skill = "몸통박치기";
            }
            public override void Attack()
            {
                Console.WriteLine($"{name}의 {skill} 공격!");
                Console.WriteLine("적이 뒤로 밀려나버렸다!");
            }
        }
    }
}
