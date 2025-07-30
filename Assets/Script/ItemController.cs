using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    
    [SerializeField] GameObject healthItem;
    [SerializeField] GameObject speedUpItem;

    Vector3 ItemSpawnPosition = new Vector3(13f, 0f, 0f);

    

    public void SetItem(int type)
    {
        if(type == 0)
        {
            SpawnItem();
        }
    }
    private void SpawnItem()
    {
        Debug.Log("하트소환");
        Instantiate(healthItem,ItemSpawnPosition, Quaternion.identity);
    }

}
