using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField]
    private Animator doorToClose;
    public bool closeDoor;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            closeDoor = true;
            doorToClose.SetBool("DoorOpen", false);
            doorToClose.SetBool("DoorClose", true);
        }
    }
}
