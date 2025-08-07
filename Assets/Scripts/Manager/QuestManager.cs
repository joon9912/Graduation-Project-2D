using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        // quest id = 10 * n
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�.", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("LUDO�� ���� ã���ֱ�.", new int[] { 5000, 2000 }));
        questList.Add(30, new QuestData("����Ʈ Ŭ����!", new int[] { 0 }));
        questList.Add(40, new QuestData("���� �濡�� Ż������.", new int[] { 200, 0, 200 }));
        questList.Add(50, new QuestData("������ �׽�Ʈ", new int[] { 1000, 0, 0, 1000 }));
        questList.Add(60, new QuestData("���� �Ϸ�", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public int GetQuestListLength(int questId)
    {
        return questList[questId].npcId.Length;
    }

    public string CheckQuest(int id)
    {
        // �� npc�� ���ϴ� ��� ��ȭ ����(string �迭)�� ���� �� ȣ��Ǵ� �Լ�

        // Next Talk Target       
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        // Control Quest Object
        ControlObject();

        // Talk Complete & Next Quest
        if (questActionIndex == GetQuestListLength(questId))
            NextQuest();
        
        // Quest Name
        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        // start initial quest
        return questList[questId].questName;
    }
    
    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    public void ControlObject()
    {
        switch(questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 0)
                    questObject[0].SetActive(true);
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
            case 40:
                if (questActionIndex == 1)
                    questObject[1].SetActive(true);                  
                break;
        }
    }
}
