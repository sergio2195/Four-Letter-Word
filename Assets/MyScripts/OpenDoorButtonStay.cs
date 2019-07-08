using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButtonStay : MonoBehaviour
{
    [SerializeField]
    private GameObject button1;

    [SerializeField]
    private GameObject button2;

    [SerializeField]
    private GameObject led1;

    [SerializeField]
    private GameObject led2;

    private bool twoButtonsPressed = false;
    private bool buttonPressed1 = false;
    private bool buttonPressed2 = false;

    void Update()
    {
        if (button1.GetComponent<buttonPressed>().buttonPush == true)
        {
            buttonPressed1 = true;
            led1.GetComponent<Renderer>().material.color = Color.green;

        }

        else
        {
            buttonPressed1 = false;
            led1.GetComponent<Renderer>().material.color = Color.red;
        }


        if (button2.GetComponent<buttonPressed>().buttonPush == true)
        {
            buttonPressed2 = true;
            led2.GetComponent<Renderer>().material.color = Color.green;
        }

        else
        {
            buttonPressed2 = false;
            led2.GetComponent<Renderer>().material.color = Color.red;

        }

        if (buttonPressed1 && buttonPressed2)
        {
            twoButtonsPressed = true;
        }

        if (twoButtonsPressed)
        {
            led1.GetComponent<Renderer>().material.color = Color.green;
            led2.GetComponent<Renderer>().material.color = Color.green;

            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(1);
        GetComponent<DoubleSlidingDoorController>().DoOpenDoor();
        GetComponent<DoubleSlidingDoorController>().keepClose = false;
    }
}
