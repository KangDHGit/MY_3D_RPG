using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player I;
    Rigidbody _rigid;
    Animator _anim;
    Collider _atk_Col;
    Weapon _weapon;

    public float _mSpeed;
    public float _rSpeed;
    public float _jump_Force;
    float _h;
    float _v;

    bool _isGround = true;

    GameObject _scanObject;
    Vector3 isoVec;

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
        _weapon = transform.Find("arm_R_weapon").GetComponentInChildren<Weapon>();
        if (_weapon == null) Debug.LogError("_weapon is Null");
    }

    private void Update()
    {
        if (_isGround && Input.GetKeyDown(KeyCode.Space)) Jump();
        if (_isGround && Input.GetKeyDown(KeyCode.X))
        {
            _rigid.velocity = Vector3.zero;
            _anim.SetFloat("velocity", 0.0f);
            _anim.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.V) && _scanObject != null)
            GameManager.I.Action(_scanObject);
        RaycastHit fRayHit;
        Debug.DrawRay(_rigid.position, transform.forward * 3.0f, Color.red);
        if (Physics.Raycast(_rigid.position, transform.forward, out fRayHit, 1.0f))
        {
            Debug.Log(fRayHit.transform.name);
        }
    }

    private void FixedUpdate()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * 0.11f));
#endif
        RaycastHit gRayHit;
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out gRayHit, 0.11f))
        {
            _isGround = true;
            _anim.SetBool("jump", false);
        }
        else
        {
            _isGround = false;
            _anim.SetBool("jump", true);
        }

        //RaycastHit fRayHit;
        //Debug.DrawRay(_rigid.position, transform.forward * 3.0f, Color.red);
        //if (Physics.Raycast(_rigid.position, transform.forward, out fRayHit, 3.0f))
        //{
        //    Debug.Log(fRayHit.transform.name);
        //}

    }

    #region Move
    public void OnAnimatorMove()
    {
        if(Time.deltaTime > 0 && !_anim.GetBool("isAttack"))
            Move(_h, _v);
    }
    void Move(float h, float v)
    {
        Vector3 vec = (new Vector3(h, 0, v).normalized * _mSpeed) / Time.fixedDeltaTime;

        isoVec = Quaternion.AngleAxis(-45, Vector3.up) * vec;
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
        if (_anim.GetBool("isAttack")) return;

        Vector3 force = new Vector3(0, _jump_Force);
        _rigid.AddForce(force);
    }

    public void SetAttackCol(int stat)
    {
        _atk_Col.enabled = stat == 1 ? true : false;
    }

    public void SetisAttack(int stat)
    {
        bool result = stat == 1 ? true : false;
        _anim.SetBool("isAttack", result);
    }

    public void NormalAttack()
    {
        if(_weapon != null)
        {

        }
    }
}
