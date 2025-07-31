using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    

    CherryController cherryController;
    ItemController itemController;
    [SerializeField] GameObject smallDownObstaclePrefab;
    [SerializeField] GameObject bigDownObstaclePrefab;
    [SerializeField] GameObject bigUpObstaclePrefab;

    float obstacleInterval=> ResourceManager.Instance.ObjectSpawnInterval;
    Vector3 DownSpawnPosition = new Vector3(13f, -2.1f, 0f);
    Vector3 UpSpawnPosition= new Vector3(13f, 5f, 0f);


    public List<int> objectSpawnData; 

    Queue<GameObject> objectPool_1 = new Queue<GameObject>();
    Queue<GameObject> objectPool_2 = new Queue<GameObject>();
    Queue<GameObject> objectPool_3 = new Queue<GameObject>();


    private void Start()
    {
        objectSpawnData = new List<int> { 4, 4, 1, 4,4,4,4,0, 0, 4, 3, 4, 2, 0, 1, 2, 0, 3, 3, 0, 2, 4, 0, 2, 1, 1, 1, 1, 1, 2, 0, 0, 0, 3, 0, 1, 1, 3, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 };
        
        cherryController = GetComponent<CherryController>();
        itemController = GetComponent<ItemController>();
        StartCoroutine(SetObstacles());
    }


    

    IEnumerator SetObstacles()
    {

        //특정 간격으로 오브젝트에 대한 정보를 끌어오고 싶어
        //그럼 코루틴을 사용해서 꺼내올까?
        foreach (int data in objectSpawnData)
        {
            
            SetType(data);
            cherryController.SetCherry(data);
            itemController.SetItem(data);
            yield return new WaitForSeconds(obstacleInterval);
        }
    }



    public void SetType(int type)
    {
        if (type == 0 )
        {
            
        }
        else if (type == 1)
        {
            
            SpawnObstacles(objectPool_1,smallDownObstaclePrefab,DownSpawnPosition);
            
        }
        else if (type == 2)
        {
            SpawnObstacles(objectPool_2,  bigDownObstaclePrefab, DownSpawnPosition);
        }
        else if(type == 3) 
        {
            SpawnObstacles(objectPool_3, bigUpObstaclePrefab,UpSpawnPosition);
        }
        else
        {
            
        }

    }
    void SpawnObstacles(Queue<GameObject> queue,GameObject prefab,Vector3 spawnPosition)
    {
        GameObject obj = null;
        if (queue.Count > 0)
        {

            obj = queue.Dequeue();
            obj.transform.position = spawnPosition;
            obj.SetActive(true);


        }
        else
        {
            obj = Instantiate(prefab, spawnPosition, Quaternion.identity);

        }
        StartCoroutine(ReturnToPool(queue, obj));




    }
    IEnumerator ReturnToPool(Queue<GameObject> queue,GameObject obj)
    {
        yield return new WaitForSeconds(10f);
        
        queue.Enqueue(obj);
        obj.SetActive(false);
        

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
