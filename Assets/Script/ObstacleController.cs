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
    public float scrollSpeed = 2f;
    public float resetPosition = -20f;
    public float startPosition = 20f;


    List<int> objectSpawnData = new List<int> { 0, 1, 2, 0, 3, 4, 0, 2, 0, 2, 1 };
    List<GameObject> objectPool = new List<GameObject>();

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

    

    void SpawnDownObstacles(GameObject downPrefab)
    {
        Instantiate(downPrefab, new Vector3(7f, 0f, 0f), Quaternion.identity);
    }
    void SpawnUpObstacles(GameObject upPrefab)
    {
        Instantiate(upPrefab, new Vector3(7f, 3f, 0f), Quaternion.identity);
    }
}
