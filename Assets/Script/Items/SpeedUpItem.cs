using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour,IConsumable
{
    private float speedIncrease = 3f;          
             // �ִ� �ӵ� ����
    ResourceManager _resourceManager;
    public void Eat(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        _resourceManager.ChangeSpeed(speedIncrease);
        _resourceManager.ReduceSpeedStart(speedIncrease);
        gameObject.SetActive(false);
        
        
    }
   
    
}
