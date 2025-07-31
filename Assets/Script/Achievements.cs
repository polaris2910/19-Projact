using UnityEngine;

public class Achievements : MonoBehaviour
{
    public ResourceManager resourceManager; // 플레이어 체력 추적용

    private int obstacleCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            if (obstacleCount == 0)
            {
                resourceManager.ResetDamageRecord(); // 처음부터 피해 기록 초기화
            }

            obstacleCount++;

            Debug.Log($"장애물 통과: {obstacleCount} ");

            if (obstacleCount >= 10)
            {
                if (!resourceManager.TookDamageDuringRun)
                {
                    TriggerPerfectRun(); // 업적 달성
                }

                obstacleCount = 0;
                resourceManager.ResetDamageRecord(); // 초기화
            }
        }
    }
    public void ResetObstacleCount()
    {
        obstacleCount = 0;
        Debug.Log(" 장애물 카운트0");
    }
    private void TriggerPerfectRun()
    {
        Debug.Log("피해 없이 장애물 10개 돌파!");
         //UI, 보상, 애니메이션 등 추가
    }
}
