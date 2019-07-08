using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorIndex : MonoBehaviour
{
   private GameObject dialogManager;

    void Start()
    {
       dialogManager = GameObject.FindWithTag("DialogManager");
    }

    void Update()
    {
        if (dialogManager.GetComponent<DialogSystem>().index == 65)
        {
            GetComponent<DoubleSlidingDoorController>().keepClose = false;
            GetComponent<DoubleSlidingDoorController>().DoOpenDoor();
        }
    }
}
