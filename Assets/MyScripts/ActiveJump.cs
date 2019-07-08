using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveJump : MonoBehaviour
{
 private GameObject dialogSystem;

    void Awake()
    {
        dialogSystem = GameObject.FindWithTag("DialogManager");
    }
    void Start()
    {
        StartCoroutine(ActiveJumpCoroutine());
    }

    public IEnumerator ActiveJumpCoroutine()
    {
        yield return new WaitForSeconds(20);
        dialogSystem.GetComponent<DialogSystem>().index++;
        dialogSystem.GetComponent<DialogSystem>().stopSentences = false;
        StartCoroutine(dialogSystem.GetComponent<DialogSystem>().Type());
    }
}
