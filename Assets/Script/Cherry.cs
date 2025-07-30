using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour,IConsumable
{
    ResourceManager _resourceManager;
    public void Eat(ResourceManager resourceManager)
    {
        this._resourceManager = resourceManager;
        //점수올라가기
        
        this.gameObject.SetActive(false);
    }

    
}
