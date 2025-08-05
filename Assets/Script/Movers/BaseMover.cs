using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMover : MonoBehaviour
{
    float movingSpeed;

    private void Start()
    {
        movingSpeed=ResourceManager.Instance.Speed;
        ResourceManager.Instance.OnChangeSpeed += UpdateSpeed;
    }

    protected virtual void Update()
    {
        Move();
    }

    void UpdateSpeed(float speed)
    {
        movingSpeed = speed;
    }

    private void Move()
    {
        transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
    }
}
