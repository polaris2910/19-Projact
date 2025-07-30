using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapScroller : MonoBehaviour
{
    private float scrollSpeed = 6f;
    private float resetPosition = -32.256f;
    private float startPosition = 32.256f;

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= resetPosition)
        {
            Vector3 newPos = transform.position;
            newPos.x = startPosition;
            transform.position = newPos;
        }
    }
}
