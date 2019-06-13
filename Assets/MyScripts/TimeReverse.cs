using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class TimeReverse : MonoBehaviour
{
    private Transform playerTransform;
    private Transform cameraTransform;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscontroller;

    private bool isReversing = false;

    private Stack<TimePoint> timeLine = new Stack<TimePoint>(2000);

    [SerializeField]
    private float reverseLength = 4f;
    [SerializeField]
    private float reverseCooldDown = 10f;
    [SerializeField]
    private float reverseCoef = 1f;

    private float currentLenght = 0f;
    private float currentCoolDown = 0f;
    private float currenFrameCount = 0f;

    public bool recordAvailable;

    // Start is called before the first frame update
    void Start()
    {
        recordAvailable = false;
        playerTransform = transform;
        cameraTransform = GetComponentInChildren<Camera>().transform;
        fpscontroller= GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

    }

    bool ReverseAvailable()
    {
        return !isReversing && currentCoolDown <= 0f;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            recordAvailable = true;

        if (Input.GetKeyDown(KeyCode.Tab) && ReverseAvailable())
        {
            StartReverse();
        }
        RefreshParams();
        Reverse();
        
    }

    private void StartReverse()
    {
        isReversing = true;
        currentCoolDown = reverseCooldDown;
        fpscontroller.enabled = false;

    }

    private void Reverse()
    {
        if (!isReversing)
        {
            return;
        }

        if (!timeLine.Any())
        {
            EndReverse();
            return;
        }
        uint removedFrames = 0;
        currenFrameCount += reverseCoef;
        for (; removedFrames < currenFrameCount && currentLenght < reverseLength && timeLine.Any(); removedFrames++)
        {
            TimePoint point = timeLine.Pop();
            currentLenght += point.deltaTime;
            SetTimePoint(point);
        }

        currenFrameCount -= removedFrames;
        if (currentLenght >= reverseLength || !timeLine.Any())
        {
            EndReverse();
        }
    }

    private void SetTimePoint(TimePoint point)
    {
        playerTransform.position = point.position;
        playerTransform.rotation = point.playerRotation;
        cameraTransform.rotation = point.cameraRotation;
      //  fpscontroller.MouseLook.Init(playerTransform, cameraTransform);

    }

    private void EndReverse()
    {
        isReversing = false;
        currentLenght = 0f;
        fpscontroller.enabled = true;
        recordAvailable = false;

    }

    private void RefreshParams()
    {
        if (isReversing)
        {
            currentCoolDown -= Time.deltaTime;
        }
    }

     private void LateUpdate()
      {

        if (recordAvailable == true)
        {
            if (!isReversing)
            {
                timeLine.Push(new TimePoint(playerTransform.position, playerTransform.rotation, cameraTransform.rotation, Time.deltaTime));
            }
        }
    }
   

    private void RecordMovement()
    {
        if (!isReversing)
        {
            timeLine.Push(new TimePoint(playerTransform.position, playerTransform.rotation, cameraTransform.rotation, Time.deltaTime));
        }

    }
    

    class TimePoint
    {
        public Vector3 position;
        public Quaternion playerRotation;
        public Quaternion cameraRotation;
        public float deltaTime;

        public TimePoint(Vector3 position, Quaternion playerRotation, Quaternion cameraRotation, float deltaTime)
        {
            this.position = position;
            this.playerRotation = playerRotation;
            this.cameraRotation = cameraRotation;
            this.deltaTime = deltaTime;

        }

    }

}
