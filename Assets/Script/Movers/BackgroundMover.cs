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

        if (transform.position.x <= resetPosition)//���� �����ǵ��޽�
        {
            Vector3 newPos = transform.position;
            newPos.x = startPosition;//��ŸƮ ���������� �̵�
            transform.position = newPos;
        }
    }
}
