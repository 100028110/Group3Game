using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    
    public Animator playerDashAnimator;
    public float dashSpeed;
    public float movementSpeed;
    public float dampeningFactor;
    public Animator weaponAnim;
    private Rigidbody2D rb;
    private float ogSpeed;
    public float damagePlayer;
    public GameObject mySwordCollider;
    private Collider2D obg;
    private Animator playerIdleWalkingAnim;
    public GameObject ani;
    public GameObject  ani2;
    
    // Start is called before the first frame update
    void Start()
    {
        obg = null;
        mySwordCollider.SetActive(false);
        ogSpeed = movementSpeed;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("dash_press");
        playerIdleWalkingAnim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;
        float moveY = 0;
        if (Input.GetKey("a"))
        {
            transform.rotation = Quaternion.Euler(Vector3.up * 180f);
            moveX--;
           
           
            var particleSystem = ani.GetComponent<ParticleSystem>();
            var mainModule = particleSystem.main;
            mainModule.startSize = 1;
            var particleSystem2 = ani2.GetComponent<ParticleSystem>();
            var mainModule2 = particleSystem2.main;
            mainModule2.startSize = 1;
// Updated code using 'main.loop' property
        
            

        }
        else if (Input.GetKey("d"))
        {
            transform.rotation = Quaternion.identity;
            moveX++;
            var particleSystem = ani.GetComponent<ParticleSystem>();
            var mainModule = particleSystem.main;
            mainModule.startSize = 1;
            var particleSystem2 = ani2.GetComponent<ParticleSystem>();
            var mainModule2 = particleSystem2.main;
            mainModule2.startSize = 1;
        }
        else if (Input.GetKey("w"))
        {
            moveY++;
            var particleSystem = ani.GetComponent<ParticleSystem>();
            var mainModule = particleSystem.main;
            mainModule.startSize = 1;
            var particleSystem2 = ani2.GetComponent<ParticleSystem>();
            var mainModule2 = particleSystem2.main;
            mainModule2.startSize = 1;
        }
        else if(Input.GetKey("s"))
        {
            moveY--;
            var particleSystem = ani.GetComponent<ParticleSystem>();
            var mainModule = particleSystem.main;
            mainModule.startSize = 1;
            var particleSystem2 = ani2.GetComponent<ParticleSystem>();
            var mainModule2 = particleSystem2.main;
            mainModule2.startSize = 1;
        }
        else
        {
            var particleSystem = ani.GetComponent<ParticleSystem>();
            var mainModule = particleSystem.main;
            mainModule.startSize = 0;
            var particleSystem2 = ani2.GetComponent<ParticleSystem>();
            var mainModule2 = particleSystem2.main;
            mainModule2.startSize = 0;
            
        }

        rb.velocity = (Vector2.right*moveX+Vector2.up*moveY).normalized*movementSpeed;
        Debug.Log("Speed: " + rb.velocity.magnitude);
        playerIdleWalkingAnim.SetFloat("Speed",rb.velocity.magnitude);
        if (Input.GetMouseButtonDown(0))
        {
            weaponAnim.SetTrigger("Attack");
            mySwordCollider.SetActive(true);
            
        }
        
        
        
    }

    private void FixedUpdate()
    {
       

        movementSpeed = ogSpeed + (movementSpeed - ogSpeed) * dampeningFactor;
    }

 

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log("Hit something");
        if (col.gameObject.CompareTag("Enemy1"))
        {
            //Debug.Log("hit of player");
            col.gameObject.GetComponent<EnemyMovment>().health -= damagePlayer;
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            obg = col;




        }
      
    }

 
    
    public IEnumerator dash_press(){

        while (true)
        {
            yield return null;
           
            if (Input.GetKey(KeyCode.Space))
            {
                movementSpeed = dashSpeed;
                playerDashAnimator.SetTrigger("OnDash");
                yield return new WaitForSeconds(3);
            }
            if (obg != null)
            {
                obg.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                obg = null;
                yield return new WaitForSeconds(1);
                
            }
        }
    }

    public void TurnOffSword()
    {
        mySwordCollider.SetActive(false);
        
    }
}
