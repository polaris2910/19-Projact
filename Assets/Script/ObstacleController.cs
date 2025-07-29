using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    Obstacles obstacles;
    float obstacleInterval = 3f;



    Queue<int> objectSpawnData = new Queue<int>();


    //��������� 
    //�� Ȥ�� ������ ���̾�α׿��� ��� queue�Ẽ��
    void AddData()
    {
        objectSpawnData.Enqueue(0);
        objectSpawnData.Enqueue(1);
        objectSpawnData.Enqueue(2);
    }

    void SetObstacles()
    {

        //Ư�� �������� ������Ʈ�� ���� ������ ������� �;�
        //�׷� �ڷ�ƾ�� ����ؼ� �����ñ�?
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
