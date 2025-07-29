using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] GameObject smallDownObstaclePrefab;
    [SerializeField] GameObject bigDownObstaclePrefab;
    [SerializeField] GameObject smallUpObstaclePrefab;
    [SerializeField] GameObject bigUpObstaclePrefab;

    float obstacleInterval = 1f;



    Queue<int> objectSpawnData = new Queue<int>();

    private void Start()
    {
        AddData();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SetObstacles());
        }
    }


    //��������� 
    //�� Ȥ�� ������ ���̾�α׿��� ��� queue�Ẽ��
    void AddData()
    {
        objectSpawnData.Enqueue(0);
        objectSpawnData.Enqueue(1);
        objectSpawnData.Enqueue(2);
        objectSpawnData.Enqueue(1);
        objectSpawnData.Enqueue(4);
        objectSpawnData.Enqueue(0);
        objectSpawnData.Enqueue(1);
        objectSpawnData.Enqueue(3);

    }

    IEnumerator SetObstacles()
    {

        //Ư�� �������� ������Ʈ�� ���� ������ ������� �;�
        //�׷� �ڷ�ƾ�� ����ؼ� �����ñ�?
        foreach (int data in objectSpawnData)
        {
            SetType(data);
            yield return new WaitForSeconds(obstacleInterval);
        }
    }

    void SpawnDownObstacles(GameObject downPrefab)
    {
        Instantiate(downPrefab, new Vector3(7f, 0f, 0f), Quaternion.identity);
    }
    void SpawnUpObstacles(GameObject upPrefab)
    {
        Instantiate(upPrefab, new Vector3(7f, 1f, 0f), Quaternion.identity);
    }

    public void SetType(int type)
    {
        if (type == 0)
        {

        }
        else if (type == 1)
        {
            SpawnDownObstacles(smallDownObstaclePrefab);
        }
        else if (type == 2)
        {
            SpawnDownObstacles(bigDownObstaclePrefab);
        }
        else if (type == 3)
        {
            SpawnUpObstacles(smallUpObstaclePrefab);
        }
        else
        {
            SpawnUpObstacles(bigUpObstaclePrefab);
        }

    }

}