using System;
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
    Vector3 UpSpawnPosition= new Vector3(13f, 3.51f, 0f);


    public List<int> objectSpawnData;
  

    Queue<GameObject> objectPool_1 = new Queue<GameObject>();
    Queue<GameObject> objectPool_2 = new Queue<GameObject>();
    Queue<GameObject> objectPool_3 = new Queue<GameObject>();
    [SerializeField] Stage_1 stage_1;
    [SerializeField] Stage_2 stage_2;
    Stage selectedStage = Stage.Stage_2;
    public void Init()
    {
        
        cherryController = GetComponent<CherryController>();
        itemController = GetComponent<ItemController>();
        

        if (selectedStage== Stage.Stage_1)
        {
            objectSpawnData=stage_1.objectDataList;
            ResourceManager.Instance.ChangeObjectSpawnInterval(stage_1.spawnInterval);
        }
        else if(selectedStage== Stage.Stage_2)
        {
            objectSpawnData=stage_2.objectDataList;
            ResourceManager.Instance.ChangeObjectSpawnInterval(stage_2.spawnInterval);
        }
            StartCoroutine(SetObstacles(objectSpawnData));
    }
    private void Start()
    {
        Init();
        
    }


    public event Action<int> OnTypeSet;
        

    private IEnumerator SetObstacles(List<int> obstacleInfoList)
    {

        foreach (int data in obstacleInfoList)
        {
            
            SetType(data);
            OnTypeSet?.Invoke(data);
            
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
        else if(type==5)
        {
            UIManager.Instance.ChangeState(UIState.Clear);
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
