using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public Player player;
    public Achievements achievements;

    [SerializeField] private float healthChangeDelay = 1f; // ���� �� ���� ���� �ð�
    public bool TookDamageDuringRun { get; private set; }

    private ResourceFactory resourceFactory;
    //private AnimationHandler animationHandler;

    private float timeSinceLastChange = float.MaxValue; // ������ ü�� ���� ���� ��� �ð�

    [field: SerializeField] public float CurrentHealth { get; private set; } // ���� ü�� (�ܺ� ���ٸ� ���)
    public float MaxHealth => resourceFactory.Health; // �ִ� ü���� ������

    [field: SerializeField] public float Speed { get; private set; } = 6f;//�� �κ� ���丮�� ���� ���߿� ���ּ���

    public int Score {  get; private set; } //�� �κе� ���丮�� �������ּ���

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
        // ���� ���� ���¶�� �ð� ����
        if (timeSinceLastChange < healthChangeDelay)
        {
            // ���� �ð� ���� �� �ִϸ��̼ǿ��� �˸�
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                //animationHandler.InvincibilityEnd();
            }
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

        if (change < 0f)
        {
            TookDamageDuringRun = true; // ���� �߻� ���
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
        Debug.Log("�ӵ���");
        //�ӵ� ����
        ChangeObjectSpawnInterval(Speed);
    }

    void ChangeObjectSpawnInterval(float speed)
    {
        Debug.Log($"���� ��ġ��ȭ , ���� ���ǵ�{speed}");
        ObjectSpawnInterval = ObjectSpawnInterval*(6f/speed);
        
        
    }

    public void ChangeScore(int score)
    {
        Score += score;
        Debug.Log($"���� ���� {score}, �������� {Score}");
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
