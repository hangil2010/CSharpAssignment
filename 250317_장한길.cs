using System.Drawing;

namespace _250317_기본실습
{
    // 과제 1. 구조체 활용하기

    internal class Program
    {

        struct Item // 아이템의 구조체, 이름과 고유 ID를 가진다.
        {
            // 아이템의 이름 name 과 아이템 고유 ID id가 있다.
            public string name;
            public string id;
        }


        // 구조체를 선언할 때 파라미터를 선언해줄 수 있다.
        // 함수처럼 파라미터를 설정이 가능한지 해봣는데 됬다.
        // 인벤토리를 선언할 때 사이즈를 설정해주는데 이후에 

        struct Inventory(int invenSize)// 인벤토리의 구조체, 아이템들과 인벤토리의 크기가 적혀있다.
        {
            public int size = invenSize;
            public Item[] item = new Item[invenSize];
        }
        // item 구조체를 파라미터로 하고 아이템 이름과 고유 ID를 출력한다.
        static void PrintItem(Item item)
        {
            Console.WriteLine($"아이템 이름 : {item.name}, 고유 ID : {item.id}");
        }
        // inventory 구조체를 파라미터로 하고 인벤토리 내부 item 구조체에 대한 반복을 실시
        // 비어있지 않을 경우 아이템 이름과 고유 ID를 출력, 비어있을 경우 비어있음을 출력
        // Note to Self : foreach 사용에 더 익숙해질 것, 잘만 쓰면 매우 편리하고 강력한 문법이 될 것 같다.
        static void PrintInventory(Inventory inventory)
        {
            foreach(Item item in inventory.item)
            {
                if (item.id != null) 
                {
                    Console.WriteLine($"아이템 이름 : {item.name}, 고유 ID : {item.id}");
                }
                else
                {
                    Console.WriteLine("인벤토리 비어있음");
                }
            }
            // 기존 for방식 코딩. 
            //for(int i = 0; i < inventory.size; i++)
            //{
            //    if (inventory.item[i].id == null)
            //    {
            //        Console.WriteLine($"{i+1}번 인벤토리 비어 있음");
            //        continue;
            //    }
            //    Console.WriteLine("{0}번 인벤토리 아이템 이름 : {1}, 고유 ID : {2}", i + 1, inventory.item[i].name, inventory.item[i].id);
            //}
        }

        static void Main(string[] args)
        {
            Item itemTest;
            Inventory invenTest = new Inventory(10);
            itemTest.name = "Bomb";
            itemTest.id = "00FF0E";
            invenTest.item[2].name = "투신의 함성 포션";
            invenTest.item[2].id = "0xFFA26";
            invenTest.item[5].name = "레미의 손길";
            invenTest.item[5].id = "0xEA251";
            invenTest.item[1].name = "고농축 힘의 포션";
            invenTest.item[1].id = "0x71225";

            PrintItem(itemTest);
            Console.WriteLine("--------");
            PrintInventory(invenTest);
        }
    }
}
