using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
#if UNITY_EDITOR
using UnityEditor.Build.Content;
#endif
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public Player player;
    public Achievements achievements;

    [SerializeField] private float healthChangeDelay = 1.5f; // 피해 후 무적 지속 시간
    public bool TookDamageDuringRun { get; private set; }

    private ResourceFactory resourceFactory;
    //private AnimationHandler animationHandler;

    private float timeSinceLastChange = float.MaxValue; // 마지막 체력 변경 이후 경과 시간

    public float CurrentHealth { get; private set; } // 현재 체력 (외부 접근만 허용)
    public float MaxHealth => resourceFactory.Health; // 최대 체력은 가져옴

    public float Speed { get; private set; } = 6f;//이 부분 팩토리랑 연결 나중에 해주세요

    public int Score {  get; private set; } //이 부분도 팩토리랑 연결해주세요

    public float ObjectSpawnInterval { get; private set; } = 3f;

    private float previousSpeed;
    private float totalDistance = 0f;

    public SpriteRenderer spriteRenderer; // [추가] Inspector에서 Player의 SpriteRenderer를 연결
    private Coroutine _blinkCoroutine;    // [추가] 깜빡임 코루틴 핸들러
    public bool IsInvincible => timeSinceLastChange < healthChangeDelay; // [추가] 무적 프로퍼티
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
                StopBlink();
            }
        }
        float totalDistancescore = Speed * Time.deltaTime;
        totalDistance += totalDistancescore;

        int scoreToAdd = Mathf.FloorToInt(totalDistance);
        if (scoreToAdd > 0)
        {
            ChangeScore(scoreToAdd);
            totalDistance -= scoreToAdd;
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

        if ((change < 0f && CurrentHealth > 0f && (CurrentHealth + change < CurrentHealth)))
        {
            TookDamageDuringRun = true; // 피해 발생 기록
            achievements.ResetObstacleCount();
            StartBlink();
        }

        if (CurrentHealth <= 0f)
        {
            Death();
        }

        return true;
    }
    public void SetHealth(float health)
    {
        CurrentHealth = health;
    }
    private void StartBlink()
    {
        Debug.Log("블링크 시작"); 
        if (_blinkCoroutine != null)
            StopCoroutine(_blinkCoroutine);                  //이전에 돌고 있던 블링크 코루틴이 있다면 중단
        _blinkCoroutine = StartCoroutine(BlinkCoroutine());  //실제 깜빡임을 연출하는 코루틴 시작, 핸들러에 저장(중복 방지)
    }

    private void StopBlink()
    {
        
        if (_blinkCoroutine != null)
        {
            StopCoroutine(_blinkCoroutine);  // 현재 실행 중인 블링크 코루틴이 있으면 중단
            _blinkCoroutine = null;          // 핸들러를 null로 리셋 (코루틴 상태 초기화)
        }
        if (spriteRenderer != null)
            spriteRenderer.enabled = true;   // 캐릭터가 완전히 보이도록 원상복구
        Debug.Log("블링크 종료");            
    }

    private IEnumerator BlinkCoroutine()
    {
        float blinkInterval = 0.15f;
        while (IsInvincible)            // 무적 상태가 유지되는 동안 반복
        {
            if (spriteRenderer != null)
                spriteRenderer.enabled = !spriteRenderer.enabled;   // 보임/숨김 반복
            yield return new WaitForSeconds(blinkInterval);         // 대기 후 다시 반복
        }
        if (spriteRenderer != null)
            spriteRenderer.enabled = true;
    }
    public void ResetDamageRecord()
    {
        TookDamageDuringRun = false;
    }
    public void ChangeSpeed(float speed)
    {
        previousSpeed = Speed;
        Speed += speed;
        OnChangeSpeed?.Invoke(Speed);
       
        MatchObjectSpawnInterval(Speed);
    }
    public Action<float> OnChangeSpeed;
    void MatchObjectSpawnInterval(float speed)
    {
        
        ObjectSpawnInterval = ObjectSpawnInterval*(previousSpeed/speed);
   
    }

    public void ChangeObjectSpawnInterval(float interval)
    {
        ObjectSpawnInterval = interval;
    }
    public void ReduceSpeedStart(float speed)
    {
        StartCoroutine(ReduceSpeed(speed));
    }


    private IEnumerator ReduceSpeed(float speed)
    {
        
        yield return new WaitForSeconds(10f);
        
        ChangeSpeed(-speed);
    }

    public void ChangeScore(int score)
    {
        Score += score;
        
    }

    public void SetScore(int score)
    {
        Score = score;
    }

    private void Death()
    {
        GameManager.Instance.GameOver();
    }

    

}
