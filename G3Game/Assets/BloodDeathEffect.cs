using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDeathEffect : MonoBehaviour
{
    public int health;

    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}