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
        talkData.Add(0 + 1000, new string[] { "�ȳ�?:n:0", "�� ���� ó�� �Ա���?:n:2" });
        talkData.Add(0 + 2000, new string[] { "����.:n:0", "�� ȣ���� ���� �Ƹ�����?:n:1",
            "��� �� ȣ������ ����� ������ �ִٰ� ��.:n:1" });
        talkData.Add(0 + 100, new string[] { "����� ���������̴�.:n" });
        talkData.Add(0 + 200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�.:n" });
        talkData.Add(0 + 300, new string[] {
            "[��Ʈ0] 3�� 2��.:n",
            "���õ��� ���������� �ð��� �����.:n",
            "���� ���� �� �ʹ� ������.:n",
            "���� �ð����� å�� ������ �þ��,:n",
            "�� ���ڿ� ���� �پ� �ִ�.:n",
            "���� �׷� ���� �� �� �ص� �� �ƴµ�,:n",
            "�������� \"�׳� �峭�� �� �ִ�\"�� �ѱ��.:n"});
        talkData.Add(0 + 400, new string[] {
            "[��Ʈ1] 3�� 7��.:n",
            "�������� �׳��� �����ؼ� ����.:n",
            "������ �������� ���� �� å������ �����.:n",
            "�缭 �������� �������ּ�����,:n",
            "�ᱹ �ƹ��� �𸥴ٰ� �ߴ�.:n",
            "���� ���� �ΰ��� �� ����̴�.:s"
        });
        // Quest Talk
        talkData.Add(10 + 1000, new string[] { "� ��.:n:0",
            "�� ������ ���� ������ �ִٴµ�;n:2", "������ ȣ�� �� LUDO�� �˷��ٲ���.:n:2"});
        talkData.Add(11 + 2000, new string[] { "����.:n:0",
            "�� ȣ���� ������ ������ �°ž�?:n:1",
            "�׷� �� �� �ϳ� ���ָ� �����ٵ�.:n:1",
            "�� �� ��ó�� ������ ���� �� �ֿ������� ��.:n:0"
        });
        talkData.Add(20 + 1000, new string[] {
            "LUDO�� ����?:n:1",
            "���� �긮�� �ٴϸ� �� ����!:n:3",
            "���߿� LUDO���� �� ���� �ؾ߰ھ�.:n:3",
        });
        talkData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��.:n:1" });
        talkData.Add(20 + 5000, new string[] { "��ó���� ������ ã�Ҵ�.:n" });
        talkData.Add(21 + 2000, new string[] { "��, ã���༭ ����.:n:2" });

        talkData.Add(40 + 200, new string[] { "���� ��� ���ڸ� �Է��ؾ��� �� �ϴ�.:n" });
        talkData.Add(41 + 200, new string[] { "������ �ƴ� �� �ϴ�.:n", "�ٽ� ���ڸ� �Է��غ���.:n" });
        talkData.Add(42 + 200, new string[] { "�ùٸ� ���ڸ� �Է��Ͽ� ���� ���� �� �ϴ�.:n" });

        talkData.Add(50 + 1000, new string[] { "�Ӹ����� �� ������ ��...:n:1" });
        talkData.Add(51 + 1000, new string[] { "�ϰ� ���� ���ڶ�°� �ڶ�������~:n:1" });
        talkData.Add(52 + 1000, new string[] { "�� ��� �� �ϳ��ϳ� �� �̽�~:n:1" });
        talkData.Add(53 + 1000, new string[] { "�̰� �� ��?��:n:2" });

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
                // ����Ʈ �� ó�� ��縶�� ���� �� ex �繰
                // �⺻ ��縦 ������ �´�.
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                // �ش� ����Ʈ ���� ���� ��簡 ���� ��
                // ����Ʈ �� ó�� ��縦 ������ �´�.
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
