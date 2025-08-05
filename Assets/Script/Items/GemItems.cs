using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class GemItems : MonoBehaviour,IConsumable
{
    ResourceManager _resourceManager;
    [SerializeField] GemType gemType;
    
    public void Eat(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        GemScore();
        gameObject.SetActive(false);
    }

    void GemScore()
    {
        if (gemType == GemType.Purple)
        {
            _resourceManager.ChangeScore(100);
        }
        else if (gemType == GemType.Green) 
        {
            _resourceManager.ChangeScore(200);
        }
        else
        {
            _resourceManager.ChangeScore(300);
        }

        
    }

}  
enum GemType
{
    Purple,
    Green,
    Gold
}
