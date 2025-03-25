using System.ComponentModel;

namespace _250324_기본실습
{
    internal class Program
    {
        // 1. Trainer 클래스
        // 필요 변수 : 트레이너 이름, 몬스터 클래스 배열 6개
        // 필요 기능 : 추가, 제거, 출력
        public class Trainer
        {
            // 트레이너 이름. Monster 6개 크기 배열 만들기. 
            public string name;
            public Monster[] monsters = new Monster[6];
            // 몬스터 추가하는 함수
            // 접근 방식:
            // 1. 우선 Monster 클래스 하나를 받아라 2. 빈 자리가 있는지 찾아라.
            // 3. 빈 자리가 있다면 거기에 넣어라. 4. 끝까지 없으면 아무것도 하지 않는다.(일단은)
            public void Add(Monster monster)
            {
                    for(int i = 0; i < monsters.Length; i++)
                    {
                        // 빈자리는 null을 사용해서 찾을 수 있음.
                        if (monsters[i] == null)
                        {
                        // 값 추가도 똑같은 클래스인 경우 세부 품목을 일일이 추가안해도 된다.
                            monsters[i] = monster;
                        // 모든 몬스터를 덮어씌우는 문제를 해결하기 위해 반복문 강제종료.
                            break;
                        }
                    }
            }
            // 몬스터 제거하는 함수
            // 접근 방식
            // 1. 우선 Monsters 클래스 하나를 받음 2. monsters배열과 monster가 일치하는 곳을 검색
            // 3. 찾았으면 삭제
            public void Remove(Monster monster)
            {
                for (int i = 0; i < monsters.Length; i++)
                {
                    if (monsters[i] == monster)
                    {
                        monsters[i] = null;
                    }
                }
            }
            // 전체 몬스터를 출력하는 함수
            // 접근 방식
            // 1. 몬스터 배열을 순회하면서 이름과 레벨을 출력. 2. 만약 빈자리가 있을 경우 비었다고 출력.
            // 여기서 Monsters 클래스의 Print 함수를 사용
            public void PrintAll()
            {
                // 트레이너 이름과 몬스터 목록을 출력
                Console.WriteLine($"트레이너 이름 : {this.name}");
                Console.WriteLine("보유 몬스터 목록");
                for(int i = 0; i < monsters.Length; i++)
                {
                    if (monsters[i] != null)
                    {
                        Console.Write($"{i + 1}번째 ");
                        monsters[i].Print();
                    }
                    else 
                    {
                        Console.WriteLine($"{i+1}번째 몬스터는 비어있음");
                    }
                }
            }
        }
        // Monster 클래스
        // 필요 변수 : 이름, 레벨
        // 필수 기능 : 처음 선언할 때 이름과 레벨을 설정.
        // 필요 기능 : 몬스터 이름 , 레벨을 출력.
        // 레벨 출력은 단순 출력으로 설정.
        
        public class Monster
        {
            public string name;
            public int level;

            // 필수 기능인 첫 선언때 이름과 레벨을 둘다 설정
            // 하나라도 없어지면 이름만 있거나 레벨만 있는 오류가 발생할 수 있다.
            public Monster(string name, int level)
            {
                this.name = name;
                this.level = level;
            }

            public void Print()
            {
                Console.WriteLine($"몬스터 이름 : {name}\t레벨 : {level}");
            }
        }
        static void Main(string[] args)
        {
            Trainer trainer = new Trainer();
            Console.Write("트레이너 이름을 입력하세요 : ");
            trainer.name = Console.ReadLine();
            Monster slime = new Monster("슬라임", 1);
            Monster dragon = new Monster("드래곤", 150);
            Monster vulture = new Monster("벌쳐", 30);
            Monster ghoul = new Monster("구울", 2);
            Monster zombie = new Monster("좀비", 66);
            Monster witch = new Monster("마녀", 123);
            trainer.Add(slime);
            trainer.Add(vulture);
            trainer.Add(dragon);
            trainer.Add(ghoul);
            trainer.Add(zombie);
            trainer.Add(witch);
            trainer.PrintAll();
            Console.WriteLine("========================================");
            trainer.Remove(vulture);
            Console.WriteLine("벌쳐 제거 완료");
            trainer.PrintAll();
        }
    }
}
