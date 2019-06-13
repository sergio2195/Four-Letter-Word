using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMatrix : MonoBehaviour
{
    public float ScrollX = 0f ;
    public float ScrollY = 1f;
    public float timeScroll = 0.5f;

    void Update()
    {
        float OffsetX = Time.time * timeScroll * ScrollX;
        float OffsetY = Time.time * timeScroll * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }

}
