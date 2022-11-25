using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int _damage = 10;
    Collider _col;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        if (!TryGetComponent(out _col)) Debug.LogError("Weapon/_col is Null");
    }

    public void ColCheck()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();

        contactFilter.SetLayerMask(LayerMask.GetMask("Player"));
        List<Collider2D> list = new List<Collider2D>();
        
        //if (_col.OverlapCollider(contactFilter, list) >= 1)
        //{
        //    foreach (Collider2D col in list)
        //    {
        //        if (col.gameObject.TryGetComponent(out NetUnit netUnit))
        //            netUnit.Hp += _damage;
        //    }
        //}
    }
}
