using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour,IConsumable
{
    public float speedIncrease = 2f;           // 증가시킬 속도
    public float maxSpeedLimit = 20f;          // 최대 속도 제한
    ResourceManager _resourceManager;
    public void Eat(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        _resourceManager.ChangeSpeed(speedIncrease);
        
    }

    
}
