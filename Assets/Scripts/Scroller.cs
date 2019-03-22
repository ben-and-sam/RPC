using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// code ripped from the space shooter unity tutorial with a change to movement along the x instead of z
// (Sam) if that counts
public class Scroller : MonoBehaviour
{
    //The background being scrolled
    public float scrollSpeed;
    public float tileSizeX;

    //The intital position of the background
    private Vector3 startPosition;

    void Start()
    {
        //starting position used to detemine where to tranform object from
        startPosition = transform.position;
    }

    void Update()
    {
        // speed at which the tile move to a new position
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        //the new position the tile should be at
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
