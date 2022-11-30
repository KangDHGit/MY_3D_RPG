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
        _talkText.text = "이것의 이름은 " + _scanObject.name + " 이라고 한다";
    }

    void Talk()
    {
        //TalkManager.I.GetTalk(id, talkIndex);
    }
}
