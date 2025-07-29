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


    List<int> objectSpawnData = new List<int> { 0, 1, 2, 0, 3, 4, 0, 2, 0, 2, 1,1,1,1,1,4,2,0,0,0,3,0,1,1,3,2,1,1,1,1,1,1,2,1,1,1,1,1 };
    Queue<GameObject> objectPool_1 = new Queue<GameObject>();
    Queue<GameObject> objectPool_2 = new Queue<GameObject>();
    Queue<GameObject> objectPool_3 = new Queue<GameObject>();
    Queue<GameObject> objectPool_4 = new Queue<GameObject>();

    

  
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SetObstacles());
        }


    }

    IEnumerator SetObstacles()
    {

        //특정 간격으로 오브젝트에 대한 정보를 끌어오고 싶어
        //그럼 코루틴을 사용해서 꺼내올까?
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
            
            SpawnOb(objectPool_1,1,smallDownObstaclePrefab);
            
        }
        else if (type == 2)
        {
            SpawnOb(objectPool_2, 2, bigDownObstaclePrefab);
        }
        else if (type == 3)
        {
            SpawnOb(objectPool_3, 3, smallUpObstaclePrefab);
        }
        else
        {
            SpawnOb(objectPool_4, 4, bigUpObstaclePrefab);
        }

    }
    void SpawnOb(Queue<GameObject> queue,int type,GameObject prefab)
    {
        GameObject obj = null;
        if (type == 1 || type == 2)
        {
            
            if (queue.Count > 0)
            {
                Debug.Log("꺼내쓰기");
                obj = queue.Dequeue();
                obj.transform.position = new Vector3(7f, 0f, 0f);
                obj.SetActive(true);
                

            }
            else
            {
                obj=Instantiate(prefab, new Vector3(7f, 0f, 0f), Quaternion.identity);
                
            }
            StartCoroutine(ReturnToPool(queue, obj));
        }
        else if(type == 3 || type == 4)
        {
            if (queue.Count > 0)
            {
                Debug.Log("꺼내쓰기");
                obj = queue.Dequeue();
                obj.transform.position = new Vector3(7f, 3f, 0f);
                obj.SetActive(true);
                
            }
            else
            {
                obj=Instantiate(prefab, new Vector3(7f, 3f, 0f),Quaternion.identity);
                
            }
            StartCoroutine(ReturnToPool(queue, obj));
        }
    }
    IEnumerator ReturnToPool(Queue<GameObject> queue,GameObject obj)
    {
        yield return new WaitForSeconds(10f);
        
        queue.Enqueue(obj);
        obj.SetActive(false);
        Debug.Log("풀에돌아감");

    }


    //void SpawnDownObstacles(GameObject downPrefab)
    //{
    //    Instantiate(downPrefab, new Vector3(7f, 0f, 0f), Quaternion.identity);
    //}
    //void SpawnUpObstacles(GameObject upPrefab)
    //{
    //    Instantiate(upPrefab, new Vector3(7f, 3f, 0f), Quaternion.identity);
    //}
}
