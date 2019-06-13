using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene2 : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            Application.LoadLevel("FinalChapter");
    }
}
