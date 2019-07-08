using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRaceManager : MonoBehaviour
{
    [SerializeField]
    private Animator obstacleUpDown1;
    [SerializeField]
    private Animator obstacleLeft1;
    [SerializeField]
    private Animator obstacleRight1;
    [SerializeField]
    private Animator obstacleLeft2;
    [SerializeField]
    private Animator obstacleRight2;
    [SerializeField]
    private Animator obstacleUpDown2;
    [SerializeField]
    private Animator obstacleLeft3;
    [SerializeField]
    private Animator obstacleRight3;
    [SerializeField]
    private Animator obstacleUpDown3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Respawn.failedTimes == 5)
        {
            StartCoroutine(IChargeSceneDifficultyCurve());        }

        }

    IEnumerator OnTriggerEnter(Collider col)
    {
        yield return new WaitForSeconds(0.1f);
        if (col.gameObject.tag == "Player")
        {
            obstacleUpDown1.SetBool("Up", true);
            obstacleUpDown1.SetBool("Down", true);
            obstacleLeft1.SetBool("Center", true);
            obstacleLeft1.SetBool("Left", true);
            obstacleRight1.SetBool("Center", true);
            obstacleRight1.SetBool("Right", true);
            obstacleLeft2.SetBool("Center", true);
            obstacleLeft2.SetBool("Left", true);
            obstacleRight2.SetBool("Center", true);
            obstacleRight2.SetBool("Right", true);
            obstacleUpDown2.SetBool("Up", true);
            obstacleUpDown2.SetBool("Down", true);
            obstacleLeft3.SetBool("Center", true);
            obstacleLeft3.SetBool("Left", true);
            obstacleRight3.SetBool("Center", true);
            obstacleRight3.SetBool("Right", true);
            obstacleUpDown3.SetBool("Up", true);
            obstacleUpDown3.SetBool("Down", true);

        }

    }

    private IEnumerator IChargeSceneDifficultyCurve()

    {
        yield return new WaitForSeconds(10);
        Application.LoadLevel("DifficultyCurveScene");


    }

}
