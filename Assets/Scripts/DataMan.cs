using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataMan : MonoBehaviour
{
    public static DataMan Instance;

    public string playerName = "";
    public string hiScoreName = "";
    public int hiScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {   
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
}
