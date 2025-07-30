using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    public float speedIncrease = 2f;           // ������ų �ӵ�
    public float maxSpeedLimit = 20f;          // �ִ� �ӵ� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �÷��̾�� �浹���� ����
        {
            ResourceFactory rf = collision.GetComponent<ResourceFactory>();
            if (rf != null)
            {
                rf.Speed = Mathf.Min(rf.Speed + speedIncrease, maxSpeedLimit);
                Debug.Log($"SpeedUp! ���� �ӵ�: {rf.Speed}");

                gameObject.SetActive(false); // ������ ����
            }
        }
    }
}
