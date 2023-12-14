using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour
{
    public void OnClickCheck(string level)
    {
        if (PlayerPrefs.HasKey(level) && PlayerPrefs.GetInt(level) == 1)
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            Debug.Log("That level is locked");
        }
    }
}
