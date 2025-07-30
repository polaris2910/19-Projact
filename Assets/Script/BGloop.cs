using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGloop : MonoBehaviour
{
    public float scrollSpeed = 6f;
    public float resetPosition = -32.256f;
    public float startPosition = 32.256f;
   

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
