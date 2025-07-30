using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    public float speedIncrease = 2f;           // 증가시킬 속도
    public float maxSpeedLimit = 20f;          // 최대 속도 제한

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어와 충돌했을 때만
        {
            ResourceFactory rf = collision.GetComponent<ResourceFactory>();
            if (rf != null)
            {
                rf.Speed = Mathf.Min(rf.Speed + speedIncrease, maxSpeedLimit);
                Debug.Log($"SpeedUp! 현재 속도: {rf.Speed}");

                gameObject.SetActive(false); // 아이템 제거
            }
        }
    }
}
