using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameManager score;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Gem")
        { }
        bool isBlue = collision.gameObject.name.Contains("Blue");
        bool isGreen = collision.gameObject.name.Contains("Green");
        bool isGold = collision.gameObject.name.Contains("Gold");

        if (isBlue)
        {
            //score.stagePoint += 100; ���� ���� �� Ȱ��ȭ
        }
        if (isGreen)
        {
            //score.stagePoint += 200; ���� ���� �� Ȱ��ȭ
        }
        if (isGold)
        {
            //score.stagePoint += 300; ���� ���� �� Ȱ��ȭ
        }

        collision.gameObject.SetActive(false);
    }


    
}
