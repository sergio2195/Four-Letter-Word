using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private AudioSource source;
    private bool playSound = false;
    [SerializeField]
    private GameObject canvas;
    private FadeInOut scriptFade;

    void Start()
    {
        scriptFade = canvas.GetComponent<FadeInOut>();
        source = GetComponent<AudioSource>();


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !playSound)
        {
            playSound = true;
            StartCoroutine(changeScene());
        }

    }

    public IEnumerator changeScene()
    {
        source.Play();
        scriptFade.FadeIn();
        yield return new WaitForSeconds(4);
        Application.LoadLevel("Scene4");


    }
}
