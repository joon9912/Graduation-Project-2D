using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public OptionManager optionManager;
    public Animator talkPanel;
    public Animator portraitAnim;
    public TypeEffect talk;
    public Image portraitImg;
    public Sprite prevPortrait;
    public GameObject menuSet;
    public GameObject keypadSet;
    public GameObject scanObject;
    public GameObject optionSet;
    public GameObject player;
    public TextMeshProUGUI questText;
    public TextMeshProUGUI keypadText;

    public bool isAction;
    public bool isOption;
    public int talkIndex;

    void Start()
    {
        GameLoad();
        questText.text = questManager.CheckQuest();
    }

    void Update()
    {
        // Sub Menu
        if (Input.GetButtonDown("Cancel"))
        {          
            if (!menuSet.activeSelf && (!keypadSet.activeSelf && !optionSet.activeSelf))
            {
                // when pure state
                menuSet.SetActive(true);
            }   
            else if (menuSet.activeSelf && (!keypadSet.activeSelf && !optionSet.activeSelf))
            {
                // when menuSet is activated
                menuSet.SetActive(false);
            }
            else if (keypadSet.activeSelf)
            {
                // when keyPad is activated
                keypadSet.SetActive(false);
            }
            else if (optionSet.activeSelf)
            {
                // when optionSet is activated
                optionSet.SetActive(false);
            }
            isAction = false;
        }

        // cannot move when using menu
        if (menuSet.activeSelf || keypadSet.activeSelf
            || optionSet.activeSelf)
            isAction = true;
    }


    public void Action(GameObject scanObj)
    {
        // 상호작용한 오브젝트의 데이터 불러옴
        scanObject = scanObj; 
        ObjData objData = scanObject.GetComponent<ObjData>();  
        
        // 대화 시작
        Talk(objData.id, objData.isNpc);
        
        // Visible Talk for Action
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex;
        string talkData;
        string[] talkDataArr = null;
        float typeInterval = 15f;

        // Set Talk Data
        if (talk.isAnim)
        {
            // 대화 창 출력 도중에 또다시 Talk()가 호출될 경우 (즉, player의 action이 또 다시 호출)
            // 모든 메시지 출력
            talk.SetMsg(""); // dummy parameter
            return;
        }
        else
        {
            // 다음 대화로 넘어가거나 대화 종료
            // id는 objData.id         
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        // End Talk
        if (talkData == null)
        {
            // if have option
            optionManager.getOption(id + questTalkIndex);

            isAction = false;
            talkIndex = 0;

            questText.text = questManager.CheckQuest(id);

            return;
        }

        talkDataArr = talkData.Split(':');

        // type speed
        // s : slow
        // n : normal
       
        if (talkDataArr[1] == "s")
            talk.CharPerSeconds = 5f;
        else if (talkDataArr[1] == "n")
            talk.CharPerSeconds = 15f;

        // Continue Talk
        if (isNpc)
        {
            // show typing effect
            talk.SetMsg(talkDataArr[0]);

            // Show Portrait
            portraitImg.sprite = talkManager.GetPortrait(id,
                int.Parse(talkDataArr[2]));
            portraitImg.color = new Color(1, 1, 1, 1); // opacity = 100%

            // Animation Portrait
            if (prevPortrait != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }            
        }
        else
        {
            // not npc
            talk.SetMsg(talkDataArr[0]);

            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void GetKeyPadNumber(int num)
    {
        // full length = 4 (can be change)
        if (keypadText.text.Length < 4)
            keypadText.text += num.ToString();
    }
    
    public void DeleteKeyPadNumber()
    {
        // delete last char
        if (keypadText.text.Length > 0)
            keypadText.text = keypadText.text.Substring(0, keypadText.text.Length - 1);
    }

    public void EnterKeyPadNumber()
    {
        // answer
        string ans = "1234";

        // Action(scanObject) : 상호작용한 것으로 '가정'
        // scanObject는 desk
        if (keypadText.text.Equals(ans))
        {
            questManager.questActionIndex++;
            Action(scanObject);
        }
        else
        {     
            Action(scanObject);

            keypadText.text = "";
        }
       
        keypadSet.SetActive(false);
        isAction = false;
    }

    public void GameSave()
    {
        // player.x
        // player.y
        // Quest Id
        // Quest Action Index
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);     
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x, y, 0);
        questManager.questActionIndex = questActionIndex;
        questManager.questId = questId;
        questManager.ControlObject();
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
