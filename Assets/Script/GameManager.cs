using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            bool isBlue = collision.gameObject.name.Contains("Blue");
            bool isGreen = collision.gameObject.name.Contains("Green");
            bool isGold = collision.gameObject.name.Contains("Gold");

            if (isBlue)
            {
                gameManager.stagePoint += 100;
            }
            if (isGreen)
            {
                gameManager.stagePoint += 200;
            }
            if (isGold)
            {
                gameManager.stagePoint += 300;
            }

            collision.gameObject.SetActive(false);
        }

        }
    }

}
