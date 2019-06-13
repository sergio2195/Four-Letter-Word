using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyGameObject());
    }

   private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
