using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public Player player;
    public Achievements achievements;

    [SerializeField] private float healthChangeDelay = 1f; // 피해 후 무적 지속 시간
    public bool TookDamageDuringRun { get; private set; }

    private ResourceFactory resourceFactory;
    //private AnimationHandler animationHandler;

    private float timeSinceLastChange = float.MaxValue; // 마지막 체력 변경 이후 경과 시간

    [field: SerializeField] public float CurrentHealth { get; private set; } // 현재 체력 (외부 접근만 허용)
    public float MaxHealth => resourceFactory.Health; // 최대 체력은 가져옴

    [field: SerializeField] public float Speed { get; private set; } = 6f;//이 부분 팩토리랑 연결 나중에 해주세요

    public int Score {  get; private set; } //이 부분도 팩토리랑 연결해주세요

    [field: SerializeField] public float ObjectSpawnInterval { get; private set; } = 3f;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
        resourceFactory = GetComponent<ResourceFactory>();
        //animationHandler = GetComponent<>();
        
    }

    private void Start()
    {
        CurrentHealth = resourceFactory.Health;
        
    }

    private void Update()
    {
        // 아직 무적 상태라면 시간 누적
        if (timeSinceLastChange < healthChangeDelay)
        {
            // 무적 시간 종료 시 애니메이션에도 알림
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                //animationHandler.InvincibilityEnd();
            }
        }
    }

    // 체력 변경 함수 (피해 or 회복)
    public bool ChangeHealth(float change)
    {
        if (change == 0 || timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0f;

        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

        if (change < 0f)
        {
            TookDamageDuringRun = true; // 피해 발생 기록
            achievements.ResetObstacleCount();

        }

        if (CurrentHealth <= 0f)
        {
            Death();
        }

        return true;
    }
    public void ChangeSpeed(float speed)
    {
        Speed += speed;
        Debug.Log("속도업");
        //속도 증가
        ChangeObjectSpawnInterval(Speed);
    }

    void ChangeObjectSpawnInterval(float speed)
    {
        Debug.Log($"스폰 수치변화 , 현재 스피드{speed}");
        ObjectSpawnInterval = ObjectSpawnInterval*(6f/speed);
        
        
    }

    public void ChangeScore(int score)
    {
        Score += score;
        Debug.Log($"얻은 점수 {score}, 현재점수 {Score}");
    }


    private void Death()
    {
        GameManager.Instance.GameOver();
    }

    public void ResetDamageRecord()
    {
        TookDamageDuringRun = false;
    }

}
