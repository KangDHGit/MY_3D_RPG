using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager I;
    Vector3 _camRot = new Vector3(30, -45);
    Vector3 _camPos = new Vector3(52.5f, 44.0f, -52.5f);
    private void Awake()
    {
        I = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.I.transform.position + _camPos;
    }
}
