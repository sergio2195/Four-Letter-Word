using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
   public static int failedTimes { get; set; }
   public static bool respawned;
   private Transform respwnTrans;
   private Transform playerTrans;
   [SerializeField]
   private bool activateRespawn;
   [SerializeField]
   private GameObject canvasFade;

    void Start()
    {
        failedTimes = 0;
        playerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
        respwnTrans = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
    }

    void Update()
    {
        if (respawned)
            GetComponent<Collider>().enabled = false;
        else
            GetComponent<Collider>().enabled = true;

    }

    void OnTriggerStay(Collider col)
        {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(IRespawn());
        }
    }

    private IEnumerator IRespawn()
    {
        canvasFade.GetComponent<FadeInOut>().FadeIn();
        DialogSystem.activeMovement = false;
        DialogSystem.invertControls = false;
        respawned = true;
        yield return new WaitForSeconds(2);
        canvasFade.GetComponent<FadeInOut>().FadeOut();
        yield return new WaitForSeconds(0.5f);
        respawned = false;
        DialogSystem.activeMovement = true;
        playerTrans.transform.position = respwnTrans.transform.position;
        failedTimes++;
    }  
}
