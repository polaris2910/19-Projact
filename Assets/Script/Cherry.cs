using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour,IConsumable
{
    ResourceManager _resourceManager;
    public void Eat(ResourceManager resourceManager)
    {
        this._resourceManager = resourceManager;
        //�����ö󰡱�
        
        this.gameObject.SetActive(false);
    }

    
}
