using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    public GameObject gameManager;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();

        GenerateData();
    }
    void GenerateData()
    {
        // Talk Data
        // LUDO : 1000, LUNA : 2000
        // BOX : 100, DESK : 200
        // note0 : 300, note1 : 400
        talkData.Add(0 + 1000, new string[] { "안녕?:n:0", "이 곳에 처음 왔구나?:n:2" });
        talkData.Add(0 + 2000, new string[] { "여어.:n:0", "이 호수는 정말 아름답지?:n:1",
            "사실 이 호수에는 비밀이 숨겨져 있다고 해.:n:1" });
        talkData.Add(0 + 100, new string[] { "평범한 나무상자이다.:n" });
        talkData.Add(0 + 200, new string[] { "누군가 사용했던 흔적이 있는 책상이다.:n" });
        talkData.Add(0 + 300, new string[] {
            "[노트0] 3월 2일.:n",
            "오늘도… 도서관에서 시간을 버텼다.:n",
            "교실 가는 게 너무 무섭다.:n",
            "쉬는 시간마다 책상에 낙서가 늘어나고,:n",
            "내 의자엔 껌이 붙어 있다.:n",
            "누가 그런 건지 말 안 해도 다 아는데,:n",
            "선생님은 \"그냥 장난일 수 있다\"며 넘긴다.:n"});
        talkData.Add(0 + 400, new string[] {
            "[노트1] 3월 7일.:n",
            "도서관은 그나마 조용해서 좋다.:n",
            "하지만 오늘은… 누가 내 책가방을 숨겼다.:n",
            "사서 선생님은 걱정해주셨지만,:n",
            "결국 아무도 모른다고 했다.:n",
            "내가 투명 인간이 된 기분이다.:s"
        });
        // Quest Talk
        talkData.Add(10 + 1000, new string[] { "어서 와.:n:0",
            "이 마을에 놀라운 전설이 있다는데;n:2", "오른쪽 호수 쪽 LUDO가 알려줄꺼야.:n:2"});
        talkData.Add(11 + 2000, new string[] { "여어.:n:0",
            "이 호수의 전설을 들으러 온거야?:n:1",
            "그럼 일 좀 하나 해주면 좋을텐데.:n:1",
            "내 집 근처에 떨어진 동전 좀 주워줬으면 해.:n:0"
        });
        talkData.Add(20 + 1000, new string[] {
            "LUDO의 동전?:n:1",
            "돈을 흘리고 다니면 못 쓰지!:n:3",
            "나중에 LUDO에게 한 마디 해야겠어.:n:3",
        });
        talkData.Add(20 + 2000, new string[] { "찾으면 꼭 좀 가져다 줘.:n:1" });
        talkData.Add(20 + 5000, new string[] { "근처에서 동전을 찾았다.:n" });
        talkData.Add(21 + 2000, new string[] { "엇, 찾아줘서 고마워.:n:2" });

        talkData.Add(40 + 200, new string[] { "왠지 어떠한 숫자를 입력해야할 듯 하다.:n" });
        talkData.Add(41 + 200, new string[] { "정답이 아닌 듯 하다.:n", "다시 숫자를 입력해보자.:n" });
        talkData.Add(42 + 200, new string[] { "올바른 숫자를 입력하여 문이 열린 듯 하다.:n" });

        talkData.Add(50 + 1000, new string[] { "머리부터 발 끝까지 다...:n:1" });
        talkData.Add(51 + 1000, new string[] { "니가 나의 여자라는게 자랑스러워~:n:1" });
        talkData.Add(52 + 1000, new string[] { "내 모든 것 하나하나 핫 이슈~:n:1" });
        talkData.Add(53 + 1000, new string[] { "이건 잘 몰?루:n:2" });

        // Portrait Data
        //
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        // dictionary key check
        if (!talkData.ContainsKey(id))
        {          
            if (!talkData.ContainsKey(id - id % 10))
            {
                // 퀘스트 맨 처음 대사마저 없을 때 ex 사물
                // 기본 대사를 가지고 온다.
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                // 해당 퀘스트 진행 순서 대사가 없을 때
                // 퀘스트 맨 처음 대사를 가지고 온다.
                return GetTalk(id - id % 10, talkIndex);       
            }            
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
