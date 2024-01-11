using System;
using System.Collections;
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
    public float knockbackForce = 5f; // Adjust this value to control the knockback force

    private Transform self;
    private Rigidbody2D rb;
    private Vector2 Movement;
    private Animator anim;
    private Rigidbody2D playerRb;
    private Vector2 knockbackDirection;

    void Start()
    {
        self = transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        swordCollider.SetActive(false);
    }

    private void Update()
    {
        if (health <= 0)
        {
            int gos = GameObject.FindGameObjectsWithTag("Enemy1").Length;
            if (gos <= 1)
            {
                PlayerPrefs.SetInt(nextScene, 1);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 6)
        {
            Debug.Log("hit");

      
            playerRb = col.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                
                knockbackDirection = (col.transform.position - transform.position).normalized;
                StartCoroutine("PlayerKnockback");
                // Damage the player
                GameObject.Find("HealthManger").GetComponent<HealthManger>().HealthAmount -= damage;
            }
        }
    }

    IEnumerator PlayerKnockback()
    {
        int numCycles = 20;
        float timeDelay = 0.02f;
        float currPush = knockbackForce;
        WaitForSeconds delay = new WaitForSeconds(timeDelay);
        for (int i = 0; i < numCycles; i++)
        {
            playerRb.MovePosition(playerRb.position + currPush*timeDelay*knockbackDirection);
            currPush *= 0.9f;
            yield return delay;
        }
    }

    private void PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.CircleCast(self.position, searchRange, Vector2.zero, 0f, playerLayers);
        if (hit)
        {
            Movement = (hit.transform.position - self.position).normalized;

            if (Movement.x < 0.01f)
            {
                self.rotation = Quaternion.Euler(Vector3.up * 180f);
            }
            else
            {
                self.rotation = Quaternion.identity;
            }

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
        rb.MovePosition((Vector2)self.position + (Time.fixedDeltaTime * moveSpeed * direction1));
    }

    public void DisableSword()
    {
        swordCollider.SetActive(false);
    }
}
