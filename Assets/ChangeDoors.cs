using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDoors : MonoBehaviour
{

    [SerializeField]
    private GameObject fakeDoor;

    [SerializeField]
    private GameObject trueDoor;

    private GameObject dialogSystem;

    void Start()
    {
        dialogSystem = GameObject.FindWithTag("DialogManager");
    }

    void Update()
    {
        if (dialogSystem.GetComponent<DialogSystem>().index >= 117)
        {
            fakeDoor.SetActive(false);
            trueDoor.SetActive(true);

        }
    }
}
