using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    float _hp; public float Hp { get { return _hp; } set { _hp = value; } }
    float _max_Hp = 100.0f; public float Max_Hp { get { return _max_Hp; } set { _max_Hp = value; } }

    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        _hp = _max_Hp;
        if (!TryGetComponent(out _anim)) Debug.LogError(this.gameObject.name + " _anim is Null");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
