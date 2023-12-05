using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestruct : MonoBehaviour
{
    public float selfdestructTime = 3f;
    // Start is called before the first frame update
    void Start()
    {

    Destroy(gameObject,selfdestructTime);
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
