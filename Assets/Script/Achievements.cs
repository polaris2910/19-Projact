using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public ResourceManager resourceManager; // �÷��̾� ü�� ������

    private int obstacleCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            if (obstacleCount == 0)
            {
                resourceManager.ResetDamageRecord(); // ó������ ���� ��� �ʱ�ȭ
            }

            obstacleCount++;

            Debug.Log($"��ֹ� ���: {obstacleCount} ");

            if (obstacleCount >= 10)
            {
                if (!resourceManager.TookDamageDuringRun)
                {
                    TriggerPerfectRun(); // ���� �޼�
                }

                obstacleCount = 0;
                resourceManager.ResetDamageRecord(); // �ʱ�ȭ
            }
        }
    }

    private void TriggerPerfectRun()
    {
        Debug.Log("���� ���� ��ֹ� 10�� ����!");
         //UI, ����, �ִϸ��̼� �� �߰�
    }
}
