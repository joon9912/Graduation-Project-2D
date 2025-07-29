using System;
using UnityEngine;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public float CharPerSeconds;
    public GameObject EndCursor;
    public string targetMsg;
    public bool isAnim; // 대화 출력 도중의 애니메이션 의미

    TextMeshProUGUI msgText;
    AudioSource audioSource;
    int index;
    float interval;

    private void Awake()
    {
        msgText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        // msg에는 end cursor가 오기 전의 모든 대화 내용이 들어있음
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {      
        msgText.text = ""; // 실제 대화가 출력되기 위해 필요한 변수
        index = 0;
        EndCursor.SetActive(false);

        // start Animation
        interval = 1.0f / CharPerSeconds;

        isAnim = true;
        Invoke("Effecting", interval);
    }

    void Effecting()
    { 
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        
        // Play Sound
        if ((targetMsg[index] != ' ' || targetMsg[index] != '.')
            && CharPerSeconds > 5)
            audioSource.Play();

        index++;

        // Recursive
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}
