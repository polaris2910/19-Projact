using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour,IConsumable
{

    public float healAmount = 20f;
    ResourceManager _resourceManager;

    public void Eat(ResourceManager resourceManager)
    {
        this._resourceManager = resourceManager;
        _resourceManager.ChangeHealth(healAmount);
        gameObject.SetActive(false);
    }

    
}
