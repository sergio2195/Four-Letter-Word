using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSentence4 : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogSystem;

    void Start()
    {
        dialogSystem.GetComponent<DialogSystem>().index++;
        dialogSystem.GetComponent<DialogSystem>().stopSentences = false;
        StartCoroutine(dialogSystem.GetComponent<DialogSystem>().Type());
    }

}
