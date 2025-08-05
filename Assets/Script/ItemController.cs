using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] ObstacleController obstacleController;
    [SerializeField] GameObject healthItem;
    [SerializeField] GameObject speedUpItem;
    [SerializeField] GameObject purpleGem;
    [SerializeField] GameObject greenGem;
    [SerializeField] GameObject goldGem;

    Vector3 ItemSpawnPosition = new Vector3(13f, 0f, 0f);

   Dictionary<int,GameObject> itemsDictionary = new Dictionary<int,GameObject>();

    private void Start()
    {
        PrepareData();
        obstacleController.OnTypeSet += SetItem;
    }

    private void PrepareData()
    {
        itemsDictionary.Add(0, healthItem);
        itemsDictionary.Add(1, speedUpItem);
        itemsDictionary.Add(2, purpleGem);
        itemsDictionary.Add(3, greenGem);
        itemsDictionary.Add(4, goldGem);    
    }

    public void SetItem(int type)
    {
        int ramdomNum=Random.Range(0, itemsDictionary.Count);
        
        if(type == 4)
        {
            
            if (itemsDictionary.TryGetValue(ramdomNum, out GameObject item))
            {
                
                SpawnItem(item);
            }
            
        }
    }
    private void SpawnItem(GameObject item)
    {
        GameObject obj= Instantiate(item, ItemSpawnPosition, Quaternion.identity);
        Destroy(obj,10f);
    }

    

}
