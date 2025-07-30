using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    float movingSpeed = 6f;
    Rigidbody2D _rigidbody2D;
    // Update is called once per frame

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
    }


    void Move()
    {

        _rigidbody2D.velocity=Vector3.left*movingSpeed;
    }

    
}



