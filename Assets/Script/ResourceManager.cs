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

    [SerializeField] private float healthChangeDelay = 1.5f; // ���� �� ���� ���� �ð�
    public bool TookDamageDuringRun { get; private set; }

    private ResourceFactory resourceFactory;
    //private AnimationHandler animationHandler;

    private float timeSinceLastChange = float.MaxValue; // ������ ü�� ���� ���� ��� �ð�

    public float CurrentHealth { get; private set; } // ���� ü�� (�ܺ� ���ٸ� ���)
    public float MaxHealth => resourceFactory.Health; // �ִ� ü���� ������

    public float Speed { get; private set; } = 6f;//�� �κ� ���丮�� ���� ���߿� ���ּ���

    public int Score {  get; private set; } //�� �κе� ���丮�� �������ּ���

    public float ObjectSpawnInterval { get; private set; } = 3f;

    private float previousSpeed;
    private float totalDistance = 0f;

    public SpriteRenderer spriteRenderer; // [�߰�] Inspector���� Player�� SpriteRenderer�� ����
    private Coroutine _blinkCoroutine;    // [�߰�] ������ �ڷ�ƾ �ڵ鷯
    public bool IsInvincible => timeSinceLastChange < healthChangeDelay; // [�߰�] ���� ������Ƽ
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
        // ���� ���� ���¶�� �ð� ����
        if (timeSinceLastChange < healthChangeDelay)
        {
            // ���� �ð� ���� �� �ִϸ��̼ǿ��� �˸�
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

    // ü�� ���� �Լ� (���� or ȸ��)
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
            TookDamageDuringRun = true; // ���� �߻� ���
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
        Debug.Log("��ũ ����"); 
        if (_blinkCoroutine != null)
            StopCoroutine(_blinkCoroutine);                  //������ ���� �ִ� ��ũ �ڷ�ƾ�� �ִٸ� �ߴ�
        _blinkCoroutine = StartCoroutine(BlinkCoroutine());  //���� �������� �����ϴ� �ڷ�ƾ ����, �ڵ鷯�� ����(�ߺ� ����)
    }

    private void StopBlink()
    {
        
        if (_blinkCoroutine != null)
        {
            StopCoroutine(_blinkCoroutine);  // ���� ���� ���� ��ũ �ڷ�ƾ�� ������ �ߴ�
            _blinkCoroutine = null;          // �ڵ鷯�� null�� ���� (�ڷ�ƾ ���� �ʱ�ȭ)
        }
        if (spriteRenderer != null)
            spriteRenderer.enabled = true;   // ĳ���Ͱ� ������ ���̵��� ���󺹱�
        Debug.Log("��ũ ����");            
    }

    private IEnumerator BlinkCoroutine()
    {
        float blinkInterval = 0.15f;
        while (IsInvincible)            // ���� ���°� �����Ǵ� ���� �ݺ�
        {
            if (spriteRenderer != null)
                spriteRenderer.enabled = !spriteRenderer.enabled;   // ����/���� �ݺ�
            yield return new WaitForSeconds(blinkInterval);         // ��� �� �ٽ� �ݺ�
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
