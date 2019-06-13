using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPressed : MonoBehaviour
{
    public bool buttonPush = false;

    IEnumerator OnTriggerStay(Collider col)
    {
        yield return new WaitForSeconds(0.1f);
        if (col.gameObject.tag == "Cube" || col.gameObject.tag == "Player")
        {
            buttonPush = true;
        }
    }

    IEnumerator OnTriggerExit(Collider col)
    {
        yield return new WaitForSeconds(0.1f);

        if (col.gameObject.tag == "Cube" || col.gameObject.tag == "Player")
        {
            buttonPush = false;
        }
    }
}
