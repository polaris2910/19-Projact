using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HeartItem : MonoBehaviour,IConsumable
{

    private int healAmount = 1;
    ResourceManager _resourceManager;

    public void Eat(ResourceManager resourceManager)
    {
        this._resourceManager = resourceManager;
        _resourceManager.ChangeHealth(healAmount);
        gameObject.SetActive(false);
    }

    
}
