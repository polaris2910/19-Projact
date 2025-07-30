using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CherryController : MonoBehaviour
{
    Vector3 CherryPatternPosition_0 = new Vector3(13f,-2f,0f);
    Vector3 CherryPatternPosition_1 = new Vector3(13f, 0f, 0f);
    Vector3 CherryPatternPosition_2=new Vector3(13f,1f,0f);


    Queue<GameObject> CherryPool_0 = new Queue<GameObject>();
    Queue<GameObject> CherryPool_1 = new Queue<GameObject>();
    
    

    [SerializeField] GameObject cherryPattern_0;
    [SerializeField] GameObject cherryPattern_1;
  
    

    public void SetCherry(int type)
    {
        if(type==0)
        {
            
            SpawnCherry(CherryPool_0, cherryPattern_0,CherryPatternPosition_0);
            
        }
        else if(type==1)
        {
            SpawnCherry(CherryPool_1, cherryPattern_1, CherryPatternPosition_1);
        }
        else if(type ==2)
        {
            SpawnCherry(CherryPool_1 , cherryPattern_1, CherryPatternPosition_2);
        }
        else if(type==3)
        {
            SpawnCherry(CherryPool_0, cherryPattern_0,CherryPatternPosition_0);
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
