using System;
using UnityEngine;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public float CharPerSeconds;
    public GameObject EndCursor;
    public string targetMsg;
    public bool isAnim; // ��ȭ ��� ������ �ִϸ��̼� �ǹ�

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
        // msg���� end cursor�� ���� ���� ��� ��ȭ ������ �������
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
        msgText.text = ""; // ���� ��ȭ�� ��µǱ� ���� �ʿ��� ����
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
