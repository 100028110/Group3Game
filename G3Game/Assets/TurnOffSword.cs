using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSword : MonoBehaviour
{
    public GameObject swordChild;

    public void TurnOffSwordFunc()
    {
        swordChild.SetActive(false);
    }
}
