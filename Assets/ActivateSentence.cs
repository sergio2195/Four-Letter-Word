using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSentence : MonoBehaviour
{
    private GameObject dialogSystem;

    void Awake()
    {
        dialogSystem = GameObject.FindWithTag("DialogManager");

    }
    void Start()
    {
        dialogSystem.GetComponent<DialogSystem>().index++;
        dialogSystem.GetComponent<DialogSystem>().stopSentences = false;
        StartCoroutine(dialogSystem.GetComponent<DialogSystem>().Type());
    }
}
