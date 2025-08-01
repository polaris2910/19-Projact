using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover: BaseMover
{
    
    private float resetPosition = -32f;
    private float startPosition = 32f;
   

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (transform.position.x <= resetPosition)//리셋 포지션도달시
        {
            Vector3 newPos = transform.position;
            newPos.x = startPosition;//스타트 포지션으로 이동
            transform.position = newPos;
        }
    }
}
