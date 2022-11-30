using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public static TalkManager I;

    Dictionary<int, string[]> _dic_Talkdata;
    private void Awake()
    {
        I = this;
        _dic_Talkdata = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        _dic_Talkdata.Add(1000, new string[] { "안녕?", "이곳에 처음왔구나?" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return _dic_Talkdata[id][talkIndex];
    }
}
