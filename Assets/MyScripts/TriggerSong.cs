using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSong : MonoBehaviour
{
    [SerializeField]
    private GameObject songRolling;

    void Update()
    {
        if (PlayerRaycasting.secretCodeSongIsCorrect)
            songRolling.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            songRolling.SetActive(true);
        }
    }
}
