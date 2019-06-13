using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMazeSolution : MonoBehaviour
{
    private Renderer MazeRend;
    [SerializeField]
    private ActivateSentence showMazeSentence;

    void Start()
    {
        MazeRend = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            StartCoroutine(WaitTimeToShowSolution());
    }

    private IEnumerator WaitTimeToShowSolution()
    {
        yield return new WaitForSeconds(20);
        showMazeSentence.enabled = true;
        yield return new WaitForSeconds(5);
        MazeRend.enabled = true;

    }
}
