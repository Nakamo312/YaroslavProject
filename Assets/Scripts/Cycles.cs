using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycles : MonoBehaviour
{
    public GameObject[] points;

    public string[] items = {"меч", "зелье", "щит"};
    void Start()
    {
        int index = 0;

        while (index < 3)
        {
            Debug.Log(items[index]);
            index += 1;
        }
        
        

    }

    
    void Update()
    {
        
    }
}
