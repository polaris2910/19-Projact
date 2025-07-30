using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    float movingSpeed = 6f;
    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {

        transform.Translate(Vector2.left * movingSpeed * Time.deltaTime);
    }

    
}



