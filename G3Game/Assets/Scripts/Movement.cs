using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public int movementSpeed;

    public Animator weaponAnim;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            weaponAnim.SetTrigger("Attack");
        }
    }
}
