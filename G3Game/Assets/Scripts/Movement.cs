using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float dashSpeed;
    public float movementSpeed;
    public float dampeningFactor;
    public Animator weaponAnim;
    private Rigidbody2D rb;
    private float ogSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        ogSpeed = movementSpeed;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("dash_press");
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;
        float moveY = 0;
        if (Input.GetKey("a"))
        {
            moveX--;
        }
        if (Input.GetKey("d"))
        {
            moveX++;
        }
        if (Input.GetKey("w"))
        {
            moveY++;
        }
        if (Input.GetKey("s"))
        {
            moveY--;
        }

        rb.velocity = (Vector2.right*moveX+Vector2.up*moveY).normalized*movementSpeed;
        if (Input.GetMouseButtonDown(0))
        {
            weaponAnim.SetTrigger("Attack");
        }
        
        movementSpeed = ogSpeed + (movementSpeed - ogSpeed) * dampeningFactor;
    }
    
    public IEnumerator dash_press(){

        while (true)
        {
            yield return null;
           
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Dash");
                movementSpeed = dashSpeed;
                yield return new WaitForSeconds(3);
            }

            
        }
    }
}
