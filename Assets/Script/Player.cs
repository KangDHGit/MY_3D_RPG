using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player I;
    public Rigidbody _rigid;
    public Animator _anim;
    public float _mSpeed;
    public float _rSpeed;
    float _h;
    float _v;

    private void Awake()
    {
        I = this;
    }

    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
    }

    public void OnAnimatorMove()
    {
        Move(_h, _v);
    }
    void Move(float h, float v)
    {
        Vector3 vec = (new Vector3(h, 0, v).normalized * _mSpeed) / Time.fixedDeltaTime;

        Vector3 isoVec = Quaternion.AngleAxis(-45, Vector3.up) * vec;
        
        _rigid.velocity = isoVec;
        Look(isoVec);
        _anim.SetFloat("velocity", isoVec.magnitude);
    }
    void Look(Vector3 vec)
    {
        if (vec.magnitude == 0)
            return;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vec), Time.fixedDeltaTime * _rSpeed);
    }
}
