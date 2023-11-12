using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMissionText : MonoBehaviour
{
    public Text speechText;
    public string message = "�ȳ��ϼ���!";

    void Start()
    {
        UpdateMessage(message);
    }

    public void UpdateMessage(string newMessage)
    {
        speechText.text = newMessage;
    }
}
