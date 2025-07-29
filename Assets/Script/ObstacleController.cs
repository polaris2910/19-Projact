using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    Obstacles obstacles;
    float obstacleInterval = 3f;



    Queue<int> objectSpawnData = new Queue<int>();


    //시험용으로 
    //아 혹시 예전에 다이어로그에서 썼던 queue써볼까
    void AddData()
    {
        objectSpawnData.Enqueue(0);
        objectSpawnData.Enqueue(1);
        objectSpawnData.Enqueue(2);
    }

    void SetObstacles()
    {

        //특정 간격으로 오브젝트에 대한 정보를 끌어오고 싶어
        //그럼 코루틴을 사용해서 꺼내올까?
        foreach (int data in objectSpawnData)
        {
            if (data == 0)
            {
                obstacles.SetType(0);
            }
            else if(data == 1) 
            {
                obstacles.SetType(1);
            }
            else
            {
                obstacles.SetType(2);
            }


        }
    }
    
}
