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
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);//이동속도

        if (transform.position.x <= resetPosition)//리셋 포지션도달시
        {
            Vector3 newPos = transform.position;
            newPos.x = startPosition;//스타트 포지션으로 이동
            transform.position = newPos;
        }
    }
}
