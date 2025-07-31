using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour,IConsumable
{
    ResourceManager _resourceManager;
    public void Eat(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;

        _resourceManager.ChangeScore(10);
        
        this.gameObject.SetActive(false);
    }

    
}
