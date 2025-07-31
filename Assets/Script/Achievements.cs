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
    public void ResetObstacleCount()
    {
        obstacleCount = 0;
        Debug.Log(" ��ֹ� ī��Ʈ0");
    }
    private void TriggerPerfectRun()
    {
        Debug.Log("���� ���� ��ֹ� 10�� ����!");
         //UI, ����, �ִϸ��̼� �� �߰�
    }
}
