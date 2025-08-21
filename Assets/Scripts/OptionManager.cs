using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class OptionManager : MonoBehaviour
{
    public TextMeshProUGUI[] opt;
    public GameObject optionSet;
    public TypeEffect talk;
    public GameManager gameManager;
    public QuestManager questManager;

    Dictionary<int, string[]> optionData;

    void Awake()
    {
        optionData = new Dictionary<int, string[]>();

        generateOptionData();
    }
    void generateOptionData()
    {
        optionData.Add(50 + 1000, new string[] { "사랑스러워~", "핫 이슈~", "오로라민 C~"});
    }

    public bool getOption(int id)
    {
        if (optionData.ContainsKey(id))
        {
            // 각 버튼에 정해준 대사 출력
            optionSet.SetActive(true);
            for (int i = 0; i < optionData[id].Length; ++i)
            {
                opt[i].text = optionData[id][i];
                setActive(i);
            }
            return true;
        }
        return false;
    }
    void setActive(int buttonNumber)
    {
        optionSet.transform.GetChild(buttonNumber).gameObject.SetActive(true);
    }

    public void getButton(int number)
    {
        optionSet.SetActive(false);

        // show answer
        questManager.questActionIndex += number;
        gameManager.Action(gameManager.scanObject);

        // next quest
        questManager.questActionIndex = questManager.GetQuestListLength(questManager.questId) - 1;
        // gameManager.Action(gameManager.scanObject);
    }
}
