using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField]
    private Image imageFade;
    [SerializeField]
    private float timeToWait;

    void Start()
    {
            imageFade.canvasRenderer.SetAlpha(1.0f);
            StartCoroutine(WaitFade());         
    }
    public void FadeIn() { imageFade.CrossFadeAlpha(1, 2, false); }

    public void FadeOut() { imageFade.CrossFadeAlpha(0, 4, false); }

    public IEnumerator WaitFade()
    {
        yield return new WaitForSeconds(timeToWait);
        FadeOut();
    }
}
