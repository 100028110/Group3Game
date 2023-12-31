using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyMovment : MonoBehaviour
{
    public LayerMask playerLayers;
    public float searchRange;
    public float attackRange;
    public float moveSpeed;
    public GameObject swordCollider;
    public float damage;
    public float health;
    public String nextScene;

    
    
    private Transform self;
    private Rigidbody2D rb;
    private Vector2 Movement;
    private Animator anim;
    
    
    //private SpriteRenderer sr;
    void Start()
    {
        self = transform;
        rb = GetComponent<Rigidbody2D>();
        //sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Debug.Log(gameObject.name + " has " + swordCollider.name);
        swordCollider.SetActive(false);
       
    }

    private void Update()
    {
        if (health <= 0)
        {
            int gos = GameObject.FindGameObjectsWithTag("Enemy1").Length;
            if(gos <=1)
            {
                PlayerPrefs.SetInt(nextScene,1);
                SceneManager.LoadScene("You Win");
                
            }
            Destroy(gameObject);
            
        }
    }

    void FixedUpdate()
    {
        PlayerDetected();
        MoveCharacter(Movement);
    }
    void OnTriggerEnter2D(Collider2D col) {
        if ( col.gameObject.layer == 6)
        {
            Debug.Log("hit");
            GameObject.Find("HealthManger").GetComponent<HealthManger>().HealthAmount-=damage;
            
            
        }
        
    }

 


    private void PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.CircleCast(self.position, searchRange, Vector2.zero, 0f, playerLayers);
        if (hit)
        {
            // Find direction for moving towards
            Movement = (hit.transform.position - self.position).normalized;
            
            // Flip image to look left or right
            if (Movement.x < 0.01f)
            {
                self.rotation = Quaternion.Euler(Vector3.up * 180f);
            }
            else
            {
                self.rotation = Quaternion.identity;
            }
            
            // If distance is close enough, swing
            if (Vector3.Distance(self.position, hit.transform.position) < attackRange)
            {
                anim.SetTrigger("Attack");
                swordCollider.SetActive(true);
            }
        }
        else
        {
            Movement = Vector2.zero;
        }
    }

    void MoveCharacter(Vector2 direction1)
    {
        rb.MovePosition((Vector2)self.position + (Time.fixedDeltaTime*moveSpeed*direction1));
    }

    public void DisableSword()
    {
        swordCollider.SetActive(false);
    }

}
