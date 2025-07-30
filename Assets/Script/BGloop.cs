using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGloop : MonoBehaviour
{
    float scrollSpeed = 6f;
    private float resetPosition = -32f;
    private float startPosition = 32f;
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);//�̵��ӵ�

        if (transform.position.x <= resetPosition)//���� �����ǵ��޽�
        {
            Vector3 newPos = transform.position;
            newPos.x = startPosition;//��ŸƮ ���������� �̵�
            transform.position = newPos;
        }
    }
}
