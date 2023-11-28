using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public LayerMask playerLayers;
    public float radius;
    private Transform self;
    private Rigidbody2D rb;
    private Vector2 Movement;
    public float moveSpeed;

    private SpriteRenderer sr;
    void Start()
    {
        self = transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        PlayerDetected();
        MoveCharacter(Movement);
    }

    private void PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.CircleCast(self.position, radius, Vector2.zero, 0f, playerLayers);
        if (hit)
        {
            Movement = (hit.transform.position - self.position).normalized;
            if (Movement.x < 0.01f)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
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
