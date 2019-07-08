using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexCorrector : MonoBehaviour
{
    private GameObject dialogSystem;
    [SerializeField]
    private int actualIndex;

    void Awake()
    {
        dialogSystem = GameObject.FindWithTag("DialogManager");

    }
    void Start()
    {
        dialogSystem.GetComponent<DialogSystem>().index = actualIndex;
        dialogSystem.GetComponent<DialogSystem>().stopSentences = false;
        StartCoroutine(dialogSystem.GetComponent<DialogSystem>().Type());
    }
}
