namespace _250311_장한길
{
    internal class Program
    {   
        // 정리하기 전 정보
        // 이름 장한길, 나이 26살, 키는 170, mbti entp, 게임을 좋아하며 pc, 모바일 둘다 좋아한다. pc는 던파, 모바일은 트릭컬, 명일방주를 좋아함.
        // 이름 문석규, 나이 27살, 키는 177, 몸무게 82kg , 게임은 여러가지 하지만 롤 칼바람 6천판 하신 언랭이다, mbti intp, 
        // 이름 박세찬, 나이 23살, 키 185, mbti enfp, 자기소개 노래 자주 듣고 좋아하는 장르는 발라드, 음식 좋아합니다.
        // 이름 최영은, 나이 27살, 키 153cm, 취미 : 노래 듣기, 책, 게임 좋아합니다, 전공은 소프트웨어학과. mbti는 enfp입니다.
        // 이름 정진모, 나이 27살, 키 179.8, 좋아하는것 게임, 핵슬 장르 모바일 게임은 니케 블루아카, 페그오, 대학 전공은 소프트웨어 공학과

        static void Main(string[] args)
        {
            const string choiName = "최영은";
            int choiAge = 23;
            float choiHeight = 153f;
            string choiMBTI = "ENFP";
            string choiInfo = "전공은 소프트웨어 학과입니다.\n노래듣기, 책, 게임을 좋아합니다.";

            const string myName = "장한길";
            int myAge = 26;
            float myHeight = 170f;
            string myMBTI = "ENTP";
            string myInfo = "PC, 모바일 게임 둘다 좋아합니다.\nPC는 던전 앤 파이터, 모바일은 트릭컬, 명일방주를 즐겨 합니다.\n가장 좋아하는 장르는 RPG입니다.";

            const string parkName = "박세찬";
            int parkAge = 23;
            float parkHeight = 185f;
            string parkMBTI = "ENFP";
            string parkInfo = "노래를 자주 들읍니다. 좋아하는 장르는 발라드입니다.\n음식을 좋아합니다.";

            const string moonName = "문석규";
            int moonAge = 27;
            float moonHeight = 177f;
            float moonWeight = 82f;
            string moonMBTI = "INTP";
            string moonInfo = "게임은 여러가지를 하고 롤을 좋아합니다.\n롤 칼바람을 6천판 하신 언랭입니다.";

            const string jungName = "정진모";
            int jungAge = 27;
            float jungHeight = 179.8f;
            string jungInfo = "게임을 좋아하며 핵슬 장르를 좋아합니다.\n모바일 게임을 좋아하며 니케, 블루아카, 페그오를 플레이 하고 있습니다.\n대학 전공은 소프트웨어 공학과입니다."; 

            // 왼쪽 순서대로 최영은, 나, 박세찬, 문석규, 정진모
            Console.WriteLine(" 가장 왼쪽에 앉은 조원의 이름은 {0}이고, 나이는 {1}살입니다. 키는 {2}cm이며, MBTI는 {3}입니다.\n자기 소개로는 \"{4}\"라고 하셨습니다. \n", choiName, choiAge, choiHeight, choiMBTI, choiInfo);
            Console.WriteLine(" 왼쪽에서 두 번째로 앉은 조원은 저입니다. 이름은 {0}이고, 나이는 {1}살입니다. 키는 {2}cm이며 MBTI는 {3}입니다.\n조원들에게는 \"{4}\"고 저를 소개했습니다.\n", myName, myAge, myHeight, myMBTI, myInfo);
            Console.WriteLine(" 중앙에 앉은 조원의 이름은 {0}이고, 나이는 {1}살입니다. 키는 {2}cm이며 MBTI는 {3}입니다.\n자기 소개로는 \"{4}\"라고 하셨습니다.\n", parkName, parkAge, parkHeight, parkMBTI, parkInfo);
            Console.WriteLine(" 왼쪽에서 세 번째로 앉은 조원의 이름은 {0}이고, 나이는 {1}살입니다. 키는 {2}cm이며, 몸무게는 {3}이며, MBTI는 {4}입니다.\n자기 소개로는 \"{5}\"라고 하셨습니다.\n", moonName, moonAge, moonHeight, moonWeight, moonMBTI, moonInfo);
            Console.WriteLine(" 왼쪽에서 네 번째로 앉은 조원의 이름은 {0}이고, 나이는 {1}살입니다. 키는 {2}cm입니다.\n자기 소개는 \"{3}\"라고 하셨습니다.\n", jungName, jungAge, jungHeight, jungInfo);

        
        }
    }
}
