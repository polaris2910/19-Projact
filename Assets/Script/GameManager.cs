using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        // ΩÃ±€≈Ê «“¥Á
        instance = this;
    }

    public void GameOver()
    {
        //ªÁ∏¡ æ÷¥œ∏ﬁ¿Ãº« ∏ﬁº“µÂ √‚∑¬
        Debug.Log("ªÁ-∏¡");
    }
}
