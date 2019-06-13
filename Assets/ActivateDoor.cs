using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnim;
    public bool openDoor;
    public bool closeDoor;
    [SerializeField]
    private GameObject closeDoorGO;

    void Start()
    {
        openDoor = false;
        closeDoor = false;      
    }

    void Update()
    {
        if (closeDoorGO.GetComponent<CloseDoorWithButton>().closeDoor && !closeDoor && closeDoorGO.GetComponent<CloseDoorWithButton>().enabled)
        {
            closeDoor = true;
            openDoor = false;
            closeDoorGO.GetComponent<Collider>().enabled = false;
            closeDoorGO.GetComponent<CloseDoorWithButton>().enabled = false;
        }

        if (openDoor)
        {
            doorAnim.SetBool("DoorOpen", true);
            doorAnim.SetBool("DoorClose", false);
        }

        if (closeDoor)
        {
            doorAnim.SetBool("DoorOpen", false);
            doorAnim.SetBool("DoorClose", true);
        }
    }
}
