using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour,IConsumable
{
    public void Eat()
    {
        //�����ö󰡱�
        this.gameObject.SetActive(false);
    }

    
}
