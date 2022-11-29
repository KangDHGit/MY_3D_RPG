using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraManager : MonoBehaviour
{
    public static CameraManager I;
    Vector3 _camRot = new Vector3(30, -45);
    Vector3 _camPos = new Vector3(52.5f, 44.0f, -52.5f);

    public Renderer ObstacleRenderer;
    private void Awake()
    {
        I = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.I.transform.position + _camPos;

        float Distance = Vector3.Distance(transform.position, Player.I.transform.position);

        Vector3 Direction = (Player.I.transform.position - transform.position).normalized;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Direction, out hit, Distance))
        {
            if (ObstacleRenderer != null && (ObstacleRenderer.gameObject != hit.transform.gameObject))
            {
                Material Mat = ObstacleRenderer.material;
                Color matColor = Mat.color;
                matColor.a = 1.0f;
                Mat.color = matColor;
            }

            // 2.맞았으면 Renderer를 얻어온다.
            if (hit.transform.tag == "Object")
            {
                    ObstacleRenderer = hit.transform.gameObject.GetComponentInChildren<Renderer>();

                if (ObstacleRenderer != null)
                {
                    // 3. Metrial의 Aplha를 바꾼다.
                    Material Mat = ObstacleRenderer.material;
                    Color matColor = Mat.color;
                    matColor.a = 0.25f;
                    Mat.color = matColor;
                }
            }
        }
        else if(ObstacleRenderer != null)
        {
            Debug.Log("Ray false");
            Material Mat = ObstacleRenderer.material;
            Color matColor = Mat.color;
            matColor.a = 1.0f;
            Mat.color = matColor;
        }
    }
}
