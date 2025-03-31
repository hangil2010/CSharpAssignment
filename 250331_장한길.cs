namespace _250331_기본실습
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. 인접행렬 그래프");
            MatrixGraph matrixGraph = new(10);
            // 가중치 없는 양방향 연결
            matrixGraph.AddEdge(2, 5);
            // 시작-끝 방향만 가중치가 있는 양방향 연결
            matrixGraph.AddEdge(3, 5, 2f);
            // 양쪽다 가중치가 있는 양방향 연결
            matrixGraph.AddEdge(5, 7, 2.5f, 5.3f);
            Console.WriteLine($"7번과 5번 노드의 연결 여부 : {matrixGraph.IsConnected(7, 5)}");
            matrixGraph.RemoveEdge(7, 5);
            Console.WriteLine($"제거 이후 7번과 5번 노드의 연결 여부 : {matrixGraph.IsConnected(7, 5)}");
            matrixGraph.Print();

            Console.WriteLine("===========================");
            Console.WriteLine("2. 인접리스트 그래프");
            ListGraph listGraph = new(10);
            // 가준치 없는 양방향 연결
            listGraph.AddEdge(2, 5);
            // 시작-끝 방향만 가중치가 있는 양방향 연결
            listGraph.AddEdge(3, 5, 2f);
            // 양쪽 다 가중치가 있는 양방향 연결
            listGraph.AddEdge(5, 7, 2.5f, 5.3f);
            Console.WriteLine($"7번과 5번 노드의 연결 여부 : {listGraph.IsConnected(7, 5)}");
            listGraph.RemoveEdge(7, 5);
            Console.WriteLine($"제거 이후 7번과 5번 노드의 연결 여부 : {listGraph.IsConnected(7, 5)}");
            listGraph.Print();
        }
    }
    // 추상 클래스 그래프 클래스 생성
    public abstract class Graph
    {
        // 간선 추가, 간선 제거, 연결여부 확인, 전체 그래프 인쇄 4개의 함수가 무조건 구현되야 한다.
        // AddEdge는 간선 추가로 노드 시작, 노드 끝, 시작-끝 가중치, 끝-시작 가중치 4개의 매개변수를 가진다.
        // 가중치는 다를 수 있더라도 양방향 연결을 기본으로 한다.
        // RemoveEdge는 간선 제거로 제거할 간선의 시작과 끝 값을 매개변수로 한다.
        // IsConnected는 두 간선이 연결되어있는지 확인하는 bool 타입 자료형을 반환으로 갖는 함수다.
        // Print는 현재 추가된 간선을 전부 출력한다.
        public abstract void AddEdge(int start, int end, float startToEndWeight, float endToStartWeight);
        public abstract void RemoveEdge(int start, int end);
        public abstract bool IsConnected(int start, int end);
        public abstract void Print();
    }
    // 1. 인접행렬 그래프 방식
    // 수업시간에 배운 배열로 그래프를 나타내는 방식
    // 그래프[시작노드, 끝노드] 위치에 가중치를 저장하는 구조로 설정
    public class MatrixGraph(int node) : Graph
    {
        public float[,] graph = new float[node, node];
        // 간선을 추가하는 함수, 우선 가중치의 음수 여부를 확인한 이후 시작-끝, 끝-시작에 해당하는 가중치를 추가한다.
        // 추가로 값을 지정하지 않을 경우 가중치는 1f로 설정
        public override void AddEdge(int start, int end, float startToEndWeight = 1f, float endToStartWeight = 1f)
        {
            if (startToEndWeight <= 0 || endToStartWeight <= 0)
            {
                Console.WriteLine("가중치는 음수가 될 수 없습니다.");
            }
            else
            {
                graph[start, end] = startToEndWeight;
                graph[end, start] = endToStartWeight;
            }
        }
        // 해당하는 간선의 가중치 값을 0으로 하여 연결을 끊는다.
        public override void RemoveEdge(int start, int end)
        {
            graph[start, end] = 0;
        }
        // 해당하는 간선의 가중치 값이 0 이상일 경우(연결되어 있을 경우) true 반환.
        public override bool IsConnected(int start, int end)
        {
            return graph[start, end] > 0;
        }
        // 현재 그래프의 모든 간선을 출력하는 함수
        // 출력 양식 => OOO노드 : - OOO노드, 가중치 O
        // 노드 배열 전체를 순회하면서 노드에 값이 있을 경우 도착 노드, 가중치를 출력
        public override void Print()
        {
            for (int i = 0; i < node; i++)
            {
                Console.Write($"{i} 노드 : ");
                for (int j = 0; j < node; j++)
                {
                    if (graph[i, j] > 0f)
                    {
                        Console.Write($" - {j}노드, 가중치 {graph[i, j]}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
    // 2. 인접리스트 그래프 방식
    // 수업시간에 배웠던 리스트로 그래프를 나타내는 방식
    // 도착노드, 가중치를 구조체로 하는 Node를 List로 가지는 graph 변수를 사용
    public class ListGraph(int size) : Graph
    {

        public struct Node
        {
            public int targetNode;
            public float weight;
        }
        public List<Node>[] graph = new List<Node>[size];
        Node node = new Node();
        // 노드를 추가하는 함수, 
        public override void AddEdge(int start, int end, float startToEndWeight = 1f, float endToStartWeight = 1f)
        {
            // 두 간선의 가중치가 양수여야 시작할 수 있도록 설정
            if (startToEndWeight > 0 || endToStartWeight > 0)
            {
                // 시작 배열에 아무런 노드가 추가되지 않을 경우 오류가 발생
                // 처음 노드를 추가할 때는 새로운 노드를 선언하여 추가.
                if (graph[start] == null)
                {
                    node.targetNode = end;
                    node.weight = startToEndWeight;
                    graph[start] = new List<Node>() { node };
                }
                // 노드가 추가된 기록이 있을 경우 값을 설정한 이후 추가.
                else
                {
                    node.targetNode = end;
                    node.weight = startToEndWeight;
                    graph[start].Add(node);
                }
                // 양방향 연결을 기본으로 하여 끝에도 동일한 과정을 거침.
                if (graph[end] == null)
                {
                    node.targetNode = start;
                    node.weight = endToStartWeight;
                    graph[end] = new List<Node>() { node };
                }
                else
                {
                    node.targetNode = start;
                    node.weight = endToStartWeight;
                    graph[end].Add(node);
                }
            }
            else
            {
                Console.WriteLine("가중치는 음수가 될 수 없습니다.");
            }

        }
        // 타겟 노드를 설정한 이후 제거
        public override void RemoveEdge(int start, int end)
        {
            node.targetNode = end;
            graph[start].Remove(node);
        }

        public override bool IsConnected(int start, int end)
        {
            node.targetNode = end;
            return graph[start].Contains(node);
        }

        public override void Print()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i}노드 :");
                if (graph[i] == null)
                {
                    Console.WriteLine();
                    continue;
                }
                foreach (Node node in graph[i])
                {
                    Console.Write($" - {node.targetNode}노드, 가중치 {node.weight}");
                }
                Console.WriteLine();
            }
        }

    }
}
