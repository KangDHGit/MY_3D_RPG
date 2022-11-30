using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public Text _talkText;
    public GameObject _scanObject;

    private void Awake()
    {
        I = this;
    }

    public void Action(GameObject scanObj)
    {
        _scanObject = scanObj;
        _talkText.text = "�̰��� �̸��� " + _scanObject.name + " �̶�� �Ѵ�";
    }

    void Talk()
    {
        //TalkManager.I.GetTalk(id, talkIndex);
    }
}
