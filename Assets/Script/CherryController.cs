using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CherryController : MonoBehaviour
{
    Vector3 CherryPositionLow = new Vector3(13f,-2f,0f);
    Vector3 CherryPositionMiddle = new Vector3(13f, 0f, 0f);
    Vector3 CherryPositionHigh=new Vector3(13f,1f,0f);


    Queue<GameObject> CherryPoolStraight = new Queue<GameObject>();
    Queue<GameObject> CherryPoolArch = new Queue<GameObject>();


    [SerializeField] ObstacleController obstacleController;
    [SerializeField] GameObject cherryPatternStraight;
    [SerializeField] GameObject cherryPatternArch;


    private void Start()
    {
        obstacleController.OnTypeSet += SetCherry;
    }

    public void SetCherry(int type)
    {
        if(type==0)
        {
            
            SpawnCherry(CherryPoolStraight, cherryPatternStraight,CherryPositionLow);
            
        }
        else if(type==1)
        {
            SpawnCherry(CherryPoolArch, cherryPatternArch, CherryPositionMiddle);
        }
        else if(type ==2)
        {
            SpawnCherry(CherryPoolArch , cherryPatternArch, CherryPositionHigh);
        }
        else if(type==3)
        {
            SpawnCherry(CherryPoolStraight, cherryPatternStraight,CherryPositionLow);
        }
        else
        {
            
        }

    }

    private void SpawnCherry(Queue<GameObject> queue, GameObject prefab,Vector3 cherryPosition)
    {
        GameObject obj = null;

        if (queue.Count > 0)
        {
            
            obj = queue.Dequeue();
            obj.transform.position = cherryPosition;
            obj.SetActive(true);
            foreach(Transform cherry in obj.transform)
            {
                cherry.gameObject.SetActive(true);
            }
        }
        else
        {
            obj=Instantiate(prefab, cherryPosition, Quaternion.identity);
        }
        StartCoroutine(ReturnToPool(queue, obj));

    }
    IEnumerator ReturnToPool(Queue<GameObject> queue, GameObject obj)
    {
        yield return new WaitForSeconds(10f);
        queue.Enqueue(obj);
        obj.SetActive(false);
        
    }
}
