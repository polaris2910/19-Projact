using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

        transform.Translate(Vector3.left*movingSpeed*Time.deltaTime);
    }

    
}



