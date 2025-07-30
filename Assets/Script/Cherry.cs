using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour,IConsumable
{
    public void Eat()
    {
        //점수올라가기
        this.gameObject.SetActive(false);
    }

    
}
