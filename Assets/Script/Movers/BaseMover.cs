using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMover : MonoBehaviour
{
    float movingSpeed;
    // Start is called before the first frame update

    private void Start()
    {
        ResourceManager.Instance.OnChangeSpeed += UpdateSpeed;
    }
    // Update is called once per frame
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
