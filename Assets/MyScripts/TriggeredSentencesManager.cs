using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredSentencesManager : MonoBehaviour
{

    [SerializeField]
    private GameObject triggerSentence1;

    [SerializeField]
    private ActivateSentence sentence1;

    [SerializeField]
    private IndexCorrector sentence2;

    [SerializeField]
    private ActivateSentence sentence3;

    [SerializeField]
    private ActivateSentence sentence4;

    [SerializeField]
    private ActivateSentence sentence5;

    [SerializeField]
    private IndexCorrector sentence6;

    [SerializeField]
    private IndexCorrector sentence7;

    [SerializeField]
    private ActiveJump sentence8;

    [SerializeField]
    private IndexCorrector sentence9;

    [SerializeField]
    private IndexCorrector sentence10;

    [SerializeField]
    private ActivateSentence sentenceFinalChapter;

    [SerializeField]
    private IndexCorrector sentence11;

    [SerializeField]
    private ActivateSentence sentence12;

    [SerializeField]
    private ActivateSentence sentence13;

    [SerializeField]
    private ActivateSentence sentence14;

    [SerializeField]
    private IndexCorrector sentence15;

    [SerializeField]
    private IndexCorrector sentence16;

    [SerializeField]
    private IndexCorrector sentence17;

    [SerializeField]
    private ActivateSentence lastSentence;

    [SerializeField]
    private GameObject dialogSystem;

    [SerializeField]
    private GameObject easelCanvas;

    [SerializeField]
    private IndexCorrector sentenceTime;

    [SerializeField]
    private IndexCorrector sentenceWait;

    [SerializeField]
    private IndexCorrector sentenceSong;

    [SerializeField]
    private IndexCorrector sentenceMath;

    [SerializeField]
    private IndexCorrector sentenceWaitJoke;

    [SerializeField]
    private IndexCorrector sentenceFourTrialCompleted;

    [SerializeField]
    private IndexCorrector sentence18;

    [SerializeField]
    private GameObject evilLaugh;

    [SerializeField]
    private GameObject sinisterMusic;

    [SerializeField]
    private GameObject thunderSoundEffect;

    [SerializeField]
    private GameObject thunderPS;

    IEnumerator WaitForTriggerSentence1()
    {
        yield return new WaitForSeconds(4);
        triggerSentence1.SetActive(true);
    }

    IEnumerator TriggerChangeFinalChapter()
    {
        yield return new WaitForSeconds(15);
        Application.LoadLevel("FourTrialScene");

    }

    IEnumerator TriggerChangeChapter()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("Chapter2");


    }

    IEnumerator TriggerChangeDifficultyScene()
    {
        yield return new WaitForSeconds(15);
        Application.LoadLevel("DifficultyCurveScene");

    }


    IEnumerator TriggerFourTrialCompleted()
    {
        yield return new WaitForSeconds(15);
        sentenceFourTrialCompleted.enabled = true;

    }

    IEnumerator TriggerFakeButtonPressed()
    {
        yield return new WaitForSeconds(2);
        evilLaugh.SetActive(true);
        yield return new WaitForSeconds(9);
        sentence16.enabled = true;
        sinisterMusic.SetActive(true);

    }

    IEnumerator TriggerSentence17()
    {
        yield return new WaitForSeconds(10);
        sentence17.enabled = true;

    }

    IEnumerator TriggerLastSentence()
    {
        yield return new WaitForSeconds(10);
        lastSentence.enabled = true;

    }

    IEnumerator WaitToEitGame()
    {
        yield return new WaitForSeconds(55);
        Application.Quit();
    }

    void Update()
    {
        if (dialogSystem.GetComponent<DialogSystem>().index == 6)
        {
            StartCoroutine(WaitForTriggerSentence1());
        }

            if (Respawn.failedTimes >= 7 && sentence13 != null)
        {
            sentence13.enabled = true;
            StartCoroutine(TriggerChangeDifficultyScene());
        }

        if (Application.loadedLevelName == "DifficultyCurveScene" && easelCanvas == null && sentence14 != null)
        {
            sentence14.enabled = true;
            StartCoroutine(TriggerChangeFinalChapter());
        }

        if (OpenRoomDoor.fourTrialCompleted == true && sentenceFourTrialCompleted != null)
            StartCoroutine(TriggerFourTrialCompleted());

        if (WaitTime.timeWaited && sentenceWaitJoke != null)
            sentenceWaitJoke.enabled = true;

        if (PlayerRaycasting.fakeButtonPressed)
            StartCoroutine(TriggerFakeButtonPressed());

        if(dialogSystem.GetComponent<DialogSystem>().index == 104)
            StartCoroutine(TriggerSentence17());

        if (dialogSystem.GetComponent<DialogSystem>().index >= 105)
        {
            sinisterMusic.SetActive(false);
            thunderSoundEffect.SetActive(true);
            if(thunderPS != null)
            thunderPS.SetActive(true);
        }

        if (PlayerRaycasting.moveUp)
        {
            StartCoroutine(TriggerLastSentence());
            StartCoroutine(WaitToEitGame());
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "TriggerSentence1" && sentence1 != null)
        {
            sentence1.enabled = true;

        }

        if (col.gameObject.tag == "TriggerSentence2" && sentence2 != null)
        {
            sentence2.enabled = true;

        }

        if (col.gameObject.tag == "TriggerSentence3" && sentence3 != null)
        {

            sentence3.enabled = true;

        }

        if (col.gameObject.tag == "TriggerSentence4" && sentence4 != null)
        {
            sentence4.enabled = true;

        }

        if (col.gameObject.tag == "TriggerSentence5" && sentence5 != null)
        {
            sentence5.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentence6" && sentence6 != null)
        {
            sentence6.enabled = true;
            sentence8.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentence7" && sentence7 != null)
        {
            sentence7.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentence9" && sentence9 != null)
        {
            sentence9.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentence10" && sentence10 != null)
        {
            sentence10.enabled = true;
            StartCoroutine(TriggerChangeChapter());

        }

        if (col.gameObject.tag == "TriggerSentence11" && sentence11 != null)
        {
            sentence11.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentence12" && sentence12 != null)
        {
            sentence12.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentenceTime" && sentenceTime != null)
        {
            sentenceTime.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentenceWait" && sentenceWait != null)
        {
            sentenceWait.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentenceSong" && sentenceSong != null)
        {
            sentenceSong.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentenceMath" && sentenceMath != null)
        {
            sentenceMath.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentence15" && sentence15 != null)
        {
            sentence15.enabled = true;
        }

        if (col.gameObject.tag == "TriggerSentence18" && sentence18 != null)
        {
            sentence18.enabled = true;
        }

    }
}
