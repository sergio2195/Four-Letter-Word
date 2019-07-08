using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTime : MonoBehaviour
{
    [SerializeField]
    private uint timeToWait;

    public static bool timeWaited;

    void Awake()
    {
        timeWaited = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            StartCoroutine(WaitSomeTime());
    }

    private IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(timeToWait);
        {
            PlayerRaycasting.waitRoomOpen = true;
            timeWaited = true;
        }
    }
}
