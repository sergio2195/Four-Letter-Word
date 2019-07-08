using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactiveAudio : MonoBehaviour
{
    [SerializeField]
    private GameObject audio;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
            audio.SetActive(false);
    }
}
