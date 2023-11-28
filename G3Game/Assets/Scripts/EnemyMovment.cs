using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public LayerMask playerLayers;
    public float searchRange;
    public float attackRange;
    public float moveSpeed;

    private Transform self;
    private Rigidbody2D rb;
    private Vector2 Movement;
    private Animator anim;
    private SpriteRenderer sr;
    void Start()
    {
        self = transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        PlayerDetected();
        MoveCharacter(Movement);
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
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
            
            // If distance is close enough, swing
            if (Vector3.Distance(self.position, hit.transform.position) < attackRange)
            {
                anim.SetTrigger("Attack");
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

}
