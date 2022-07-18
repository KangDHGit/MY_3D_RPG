using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody _rigid;
    public Animator _anim;
    public float _mSpeed;
    public float _rSpeed;
    float _h;
    float _v;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        //Move(_h, _v);
    }

    public void OnAnimatorMove()
    {
        Move(_h, _v);
    }
    void Move(float h, float v)
    {
        Vector3 vec = (new Vector3(h, 0, v).normalized * _mSpeed) / Time.fixedDeltaTime;
        _rigid.velocity = vec;
        Look(vec);
        _anim.SetFloat("velocity", vec.magnitude);
    }
    void Look(Vector3 vec)
    {
        if (vec.magnitude == 0)
            return;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vec), Time.fixedDeltaTime * _rSpeed);
    }
}
