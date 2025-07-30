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
            //score.stagePoint += 100; 점수 도입 시 활성화
        }
        if (isGreen)
        {
            //score.stagePoint += 200; 점수 도입 시 활성화
        }
        if (isGold)
        {
            //score.stagePoint += 300; 점수 도입 시 활성화
        }

        collision.gameObject.SetActive(false);
    }


    
}
