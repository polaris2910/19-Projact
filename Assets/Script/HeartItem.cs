using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{

    public float healAmount = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ResourceController rc = collision.GetComponent<ResourceController>();
            if (rc != null)
            {
                bool healed = rc.ChangeHealth(healAmount);
                if (healed)
                {
                    Debug.Log("체력 회복!");
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
