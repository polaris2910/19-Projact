using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour,IConsumable
{
    private float speedIncrease = 3f;          
             // 최대 속도 제한
    ResourceManager _resourceManager;
    public void Eat(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        _resourceManager.ChangeSpeed(speedIncrease);
        gameObject.SetActive(false);
        
    }

    
}
