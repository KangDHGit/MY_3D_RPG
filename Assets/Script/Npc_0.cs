using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_0 : MonoBehaviour
{
    bool _activeReady = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            _activeReady = true;
    }
    
}
