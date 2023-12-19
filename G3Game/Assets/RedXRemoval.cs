using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedXRemoval : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(transform.parent.name) && PlayerPrefs.GetInt(transform.parent.name) == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
