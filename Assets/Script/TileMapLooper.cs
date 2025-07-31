using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapScroller : BaseMover
{
    
    private float resetPosition = -45f;
    private float startPosition = 45f;

    protected override void Update()
    {
        
        base.Update();
        if (transform.position.x <= resetPosition)
        {
            Vector3 newPos = transform.position;
            newPos.x = startPosition;
            transform.position = newPos;
        }
    }
}
