using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static MoneyManager _instance = null;
    public static MoneyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(MoneyManager)) as MoneyManager;
                if (_instance == null)
                {
                    Debug.LogError("Error MoneyManager");
                }
            }
            return _instance;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
