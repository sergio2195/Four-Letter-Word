using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRoomDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject ledTime;
    [SerializeField]
    private GameObject ledMath;
    [SerializeField]
    private GameObject ledSong;
    [SerializeField]
    private GameObject ledWait;
    [SerializeField]
    private GameObject finalDoor;

    [SerializeField]
    private GameObject doorTime;

    [SerializeField]
    private GameObject doorWait;

    [SerializeField]
    private GameObject doorMath;

    [SerializeField]
    private GameObject doorSong;

    public static bool fourTrialCompleted = false;

    [SerializeField]
    private GameObject matrix;

    void Update()
    {
        if (PlayerRaycasting.secretCodeTimeIsCorrect)
        {
            ledTime.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            doorTime.GetComponent<DoubleSlidingDoorController>().keepClose = false;
        }

        if (PlayerRaycasting.secretCodeSongIsCorrect)
        {
            ledSong.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            doorSong.GetComponent<DoubleSlidingDoorController>().keepClose = false;
        }

        if (PlayerRaycasting.secretCodeMathIsCorrect)
        {
            ledMath.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            doorMath.GetComponent<DoubleSlidingDoorController>().keepClose = false;
        }

        if (PlayerRaycasting.waitRoomOpen)
        {
            ledWait.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            doorWait.GetComponent<DoubleSlidingDoorController>().keepClose = false;
        }

        if (PlayerRaycasting.secretCodeTimeIsCorrect && PlayerRaycasting.secretCodeSongIsCorrect && PlayerRaycasting.secretCodeMathIsCorrect && PlayerRaycasting.waitRoomOpen && matrix != null)
        {
            finalDoor.GetComponent<DoubleSlidingDoorController>().keepClose = false;
            fourTrialCompleted = true;
            matrix.SetActive(true);
        }
    }
}
