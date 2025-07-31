using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMover : MonoBehaviour
{
    float movingSpeed => ResourceManager.Instance.Speed;
    // Start is called before the first frame update
    

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
    }
}
