using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMover : BaseMover
{
    
    private float resetPosition = -45f;
    

    protected override void Update()
    {
        
        base.Update();
        if (transform.position.x <= resetPosition)//���� �����ǵ��޽�
        {
            Vector3 newPos = transform.position;
            transform.Translate(new Vector3(90f, 0, 0));
        }
    }
}
