using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player I;
    Rigidbody _rigid;
    Animator _anim;
    Collider _atk_Col;

    public float _mSpeed;
    public float _rSpeed;
    public float _jump_Force;
    float _h;
    float _v;

    private void Awake()
    {
        I = this;
    }

    void Start()
    {
        Init();
    }

    public void Init()
    {
        if (!TryGetComponent(out _rigid)) Debug.LogError(this.gameObject.name + " _rigid is Null");
        if (!TryGetComponent(out _anim)) Debug.LogError(this.gameObject.name + " _anim is Null");
        if (!transform.Find("arm_R_weapon/warrior_handsword").TryGetComponent(out _atk_Col)) Debug.LogError(this.gameObject.name + " _atk_Col is Null");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void FixedUpdate()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
    }

    #region Move
    public void OnAnimatorMove()
    {
        if(Time.deltaTime > 0)
            Move(_h, _v);
    }
    void Move(float h, float v)
    {
        Vector3 vec = (new Vector3(h, 0, v).normalized * _mSpeed) / Time.fixedDeltaTime;

        Vector3 isoVec = Quaternion.AngleAxis(-45, Vector3.up) * vec;
        Look(isoVec);

        isoVec.y = _rigid.velocity.y;
        _rigid.velocity = isoVec;
        _anim.SetFloat("velocity", isoVec.magnitude);
    }
    void Look(Vector3 vec)
    {
        if (vec.magnitude == 0)
            return;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vec), Time.fixedDeltaTime * _rSpeed);
    }
    #endregion Move

    public void Jump()
    {
        if (_anim.GetBool("isAttack") || _anim.GetBool("isjump")) return;
        Debug.Log("Jump");  
        Vector3 force = new Vector3(0, _jump_Force);
        _rigid.AddForce(force);
    }

    public void SetAttackCol(int stat)
    {
        _atk_Col.enabled = stat == 1 ? true : false;
    }

    public void SetisAttack(int stat)
    {
        bool result  = stat == 1 ? true : false;
        _anim.SetBool("isAttack", result);
    }
}
