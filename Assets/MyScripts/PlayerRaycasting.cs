using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerRaycasting : MonoBehaviour
{
    [SerializeField]
    private float interactionDistance;
    private Camera cameraPlayer;
    RaycastHit hit;
    [SerializeField]
    private LayerMask layerMaskInteract;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed;
    public static bool moveUp {get; set;}
    [SerializeField]
    private GameObject songPlayTheGame;
    public static bool fakeButtonPressed { get; set; }

    //Throw and Grab objects
    private bool beingGrabbed;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private float distanceToGrab;
    private GameObject grabbedObject;
   

    //Panel Variables
    [SerializeField]
    private TextMeshProUGUI textMarcadorTime;
    [SerializeField]
    private TextMeshProUGUI textMarcadorSong;
    [SerializeField]
    private TextMeshProUGUI textMarcadorMath;
    [SerializeField]
    private bool CanPressMarcadorTime = false;
    private bool CanPressMarcadorSong = false;
    private bool CanPressMarcadorMath = false;
    //Open Room Door
    static public bool secretCodeTimeIsCorrect { get; set; }
    static public bool secretCodeSongIsCorrect { get; set; }
    static public bool secretCodeMathIsCorrect { get; set; }
    static public bool waitRoomOpen { get; set; }


    //Numbers
    private uint firstNum, secondNum, thirdNum, fourthNum;
    private uint timePressed;
    [SerializeField]private bool waitShowMessage = false;

    //Secret Codes:
    [SerializeField]
    private string secretCodeTime;
    [SerializeField]
    private string secretCodeSong = "1965";
    [SerializeField]
    private string secretCodeMath = "1872";

    //TrapScene
    [SerializeField]
    private GameObject trapRoom;

    //MarioScene
    [SerializeField]
    private bool changeSceneButtonPressed = false;

    public System.TimeSpan hour;
    System.DateTime myTime;

    void Start()
    {
        cameraPlayer = GetComponent<Camera>();
        timePressed = 0;
        hour = myTime.TimeOfDay;
        moveUp = false;

        secretCodeSong = "1965";
        secretCodeTimeIsCorrect = false;
        secretCodeSongIsCorrect = false;
        secretCodeMathIsCorrect = false;
        waitRoomOpen = false;
    }

    void Update()
    {
        myTime = System.DateTime.Now;
        hour = myTime.TimeOfDay;

        secretCodeTime = hour.ToString(@"hhmm");

        if (secretCodeTimeIsCorrect)
            CanPressMarcadorTime = false;

        if (secretCodeMathIsCorrect)
            CanPressMarcadorMath = false;

        if (secretCodeSongIsCorrect)
            CanPressMarcadorSong = false;

        if (moveUp)
            StartCoroutine(MoveUp());

        if (Input.GetButton("Fire1"))
        {
            Vector3 rayOrigin = cameraPlayer.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            Debug.DrawRay(rayOrigin, cameraPlayer.transform.forward * distanceToGrab, Color.magenta);

            if (Physics.Raycast(rayOrigin, cameraPlayer.transform.forward, out hit, distanceToGrab, layerMaskInteract.value))
            {
                 Grabbable g = hit.collider.GetComponent<Grabbable>();
                    if(g != null)
                    {
                        grabbedObject = g.gameObject;
                        GrabObject(grabbedObject);
                    }               
            }
        }

        else if (beingGrabbed)
        {
            DrobObject(grabbedObject);  
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 rayOrigin = cameraPlayer.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            if (Physics.Raycast(rayOrigin, cameraPlayer.transform.forward, out hit, interactionDistance, layerMaskInteract.value))
            {
                if (CanPressMarcadorTime && textMarcadorTime != null && !waitShowMessage)
                    PressButtons(textMarcadorTime, secretCodeTime);

                else if (CanPressMarcadorSong && textMarcadorSong != null)
                    PressButtons(textMarcadorSong, secretCodeSong);

                else if (CanPressMarcadorMath && textMarcadorMath != null)
                    PressButtons(textMarcadorMath, secretCodeMath);

                if (timePressed >= 4)
                    timePressed = 0;


                if (hit.collider.gameObject.tag == "Button")
                {
                    hit.collider.gameObject.GetComponent<DoubleSlidingDoorController>().keepClose = false;
                }

                if (hit.collider.gameObject.tag == "TrapButton")
                {
                    trapRoom.GetComponent<Collider>().enabled = false;
                }

                if (hit.collider.gameObject.tag == "FakeButton")
                {
                    fakeButtonPressed = true;
                }

                if (hit.collider.gameObject.tag == "ChargeSceneButton" && !changeSceneButtonPressed)
                {
                    changeSceneButtonPressed = true;
                    StartCoroutine(changeScenePeachCastle());

                }

                if (hit.collider.gameObject.tag == "FinalButton" && songPlayTheGame != null)
                {
                    moveUp = true;
                    songPlayTheGame.SetActive(true);
                }
            }
        }
    }

    private void GrabObject(GameObject objectGrabbed)
    {
        objectGrabbed.GetComponent<Rigidbody>().isKinematic = true;
        objectGrabbed.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position, cameraPlayer.transform.position + cameraPlayer.transform.forward * 1.5f, Time.deltaTime * smooth );
        objectGrabbed.gameObject.transform.SetParent(transform);
        beingGrabbed = true;
   
    }

    private void DrobObject(GameObject objectGrabbed)
    {
        objectGrabbed.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        objectGrabbed.gameObject.transform.SetParent(null);
        objectGrabbed = null;
        beingGrabbed = false;
                  
    }

    private IEnumerator changeScenePeachCastle()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Peach'sCastle");
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "TriggerMarcadorTime" && !secretCodeTimeIsCorrect)
        {
            CanPressMarcadorTime = true;
        }


        if (col.gameObject.tag == "TriggerMarcadorSong" && !secretCodeSongIsCorrect)
        {
            CanPressMarcadorSong = true;
        }

        if (col.gameObject.tag == "TriggerMarcadorMath" && !secretCodeMathIsCorrect)
        {
            CanPressMarcadorMath = true;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "TriggerMarcadorTime")
        {
            CanPressMarcadorTime = false;
        }

        if (col.gameObject.tag == "TriggerMarcadorSong")
        {
            CanPressMarcadorSong = false;
        }

        if (col.gameObject.tag == "TriggerMarcadorMath")
        {
            CanPressMarcadorMath = false;
        }
    }

    private void PressButtons(TextMeshProUGUI marcador, string secretCode)
    {

        if (hit.collider.gameObject.tag == "num1" || hit.collider.gameObject.tag == "num2" || hit.collider.gameObject.tag == "num3" ||
            hit.collider.gameObject.tag == "num4" || hit.collider.gameObject.tag == "num5" || hit.collider.gameObject.tag == "num6" ||
            hit.collider.gameObject.tag == "num7" || hit.collider.gameObject.tag == "num8" || hit.collider.gameObject.tag == "num9" ||
            hit.collider.gameObject.tag == "num0")
        {
            timePressed++;

            if (timePressed == 1)
            {
                marcador.text = hit.collider.gameObject.name.ToString();

            }

            else if (timePressed == 2)
            {
                marcador.text = marcador.text + hit.collider.gameObject.name.ToString();

            }

            else if (timePressed == 3)
            {
                marcador.text = marcador.text + hit.collider.gameObject.name.ToString();

            }

            else if (timePressed == 4)
            {
                marcador.text = marcador.text + hit.collider.gameObject.name.ToString();

                if (marcador.text == secretCode)
                {

                    if (secretCode == secretCodeTime)
                    {
                        secretCodeTimeIsCorrect = true;
                        StartCoroutine(WaitTimeToShowMessage(marcador, "YEP :)"));
                    }
                    else if (secretCode == secretCodeSong)
                    {
                        secretCodeSongIsCorrect = true;
                        StartCoroutine(WaitTimeToShowMessage(marcador, "YEP :)"));
                    }
                    else if (secretCode == secretCodeMath)
                    {
                        secretCodeMathIsCorrect = true;
                        StartCoroutine(WaitTimeToShowMessage(marcador, "YEP :)"));
                    }
                }
                else
                {
                    waitShowMessage = true;
                    StartCoroutine(WaitTimeToShowMessage(marcador, "NOPE :("));
                }
            }
        }
    }

    private IEnumerator WaitTimeToShowMessage(TextMeshProUGUI marc, string message)

    {    
        yield return new WaitForSeconds(0.5f);
        marc.text = message;
        waitShowMessage = false;       
    }

    private IEnumerator MoveUp()

    {
        
        DialogSystem.activeMovement = false;
        DialogSystem.canJump = false;
        DialogSystem.invertControls = false;

        yield return new WaitForSeconds(5);

        player.GetComponent<CharacterController>().enabled = false;
       
        player.transform.position = player.transform.position + (new Vector3(0, speed, 0) * Time.deltaTime);
    }

}
