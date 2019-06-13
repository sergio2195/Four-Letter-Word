using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorWithButton : MonoBehaviour
{
    public bool closeDoor { get; set; }

    void Start()
    {
        closeDoor = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !closeDoor)
        {
            closeDoor = true;
        }
    }
}
