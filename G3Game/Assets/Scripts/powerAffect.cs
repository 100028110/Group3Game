using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerAffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if ( col.gameObject.layer == 6)
        {
            
           
            GameObject.Find(col.gameObject.name).GetComponent<Movement>().damagePlayer+=2;
            GameObject.Find(col.gameObject.name).GetComponent<SpriteRenderer>().color=Color.cyan;

           
            Destroy(gameObject);
            
            
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
