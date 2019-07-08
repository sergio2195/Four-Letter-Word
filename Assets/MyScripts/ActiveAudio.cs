using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAudio : MonoBehaviour
{
    [SerializeField]
    private GameObject audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            audio.SetActive(true);
    }
}
