using System;
using UnityEngine;

public class ResetLevelLocks : MonoBehaviour
{
    public String[] levelNames;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string level in levelNames)
        {
            PlayerPrefs.SetInt(level,0);
        }
        PlayerPrefs.SetInt(levelNames[0],1);
        //PlayerPrefs.SetInt("Dungeon 2",1);  ... Correctly marks dungeon 2 as completed in PlayerPrefs
    }
}
