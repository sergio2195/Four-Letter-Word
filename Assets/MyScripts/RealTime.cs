using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTime : MonoBehaviour
{
    public int day;
    public int month;

    // Start is called before the first frame update
    void Start()
    {
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
