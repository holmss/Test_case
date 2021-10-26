using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreenManager : MonoBehaviour
{
    public GameObject obj;

    public void ShowScreen()
    {
        obj.SetActive(true);
    }
}
