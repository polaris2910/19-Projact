using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    float movingSpeed => ResourceManager.Instance.Speed;
    

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



