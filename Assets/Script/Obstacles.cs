using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    float smallObstacleHeight = 1f;
    float bigObstaclesHeight = 2f;
    float movingSpeed = 4f;
    GameObject SmallObstaclePrefab;
    GameObject BigObstaclePrefab;

    

    //이걸 빈 오브젝트에 달아주고 이걸 부모삼아서?
    void SpawnObstacles(GameObject prefab)
    {
        Instantiate(prefab,transform);
    }

    void Move()
    {
        transform.Translate(Vector2.left * movingSpeed * Time.deltaTime);
    }

    public void SetType(int type)
    {
        if(type==0)
        {
            
        }
        else if(type==1)
        {
            SpawnObstacles(SmallObstaclePrefab);
        }
        else
        {
            SpawnObstacles(BigObstaclePrefab);
        }

    }
}



