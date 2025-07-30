using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour,IConsumable
{
    public float speedIncrease = 2f;           // ������ų �ӵ�
    public float maxSpeedLimit = 20f;          // �ִ� �ӵ� ����
    ResourceManager _resourceManager;
    public void Eat(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        _resourceManager.ChangeSpeed(speedIncrease);
        
    }

    
}
