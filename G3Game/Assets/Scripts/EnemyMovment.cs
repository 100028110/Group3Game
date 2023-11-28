using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public LayerMask playerLayers;
    public float radius;

    private Transform player;
    private Transform self;

    void Start()
    {
        self = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerDetected();
    }

    private void PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.CircleCast(self.position, radius, Vector2.zero, 0f, playerLayers);
        if (hit)
        {
            Debug.Log("Detected Player");
            // Do player following
        }
    }

}
