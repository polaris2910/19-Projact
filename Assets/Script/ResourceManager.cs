using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Player player;

    [SerializeField] private float healthChangeDelay = 3f; // 피해 후 무적 지속 시간
    public bool TookDamageDuringRun { get; private set; }

    private ResourceFactory resourceFactory;
    //private StatHandler statHandler;
    //private AnimationHandler animationHandler;

    private float timeSinceLastChange = float.MaxValue; // 마지막 체력 변경 이후 경과 시간

    public float CurrentHealth { get; private set; } // 현재 체력 (외부 접근만 허용)
    public float MaxHealth => resourceFactory.Health; // 최대 체력은 StatHandler로부터 가져옴

    private void Awake()
    {
        resourceFactory = GetComponent<ResourceFactory>();
        //animationHandler = GetComponent<>();
        //baseController = GetComponent<>();
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
             //Player.Damage(); 
        }

        if (CurrentHealth <= 0f)
        {
            Death();
        }

        return true;
    }

    private void Death()
    {

        GameManager.instance.GameOver();
    }

    public void ResetDamageRecord()
    {
        TookDamageDuringRun = false;
    }

}
