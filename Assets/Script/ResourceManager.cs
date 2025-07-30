using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Player player;

    [SerializeField] private float healthChangeDelay = 3f; // ���� �� ���� ���� �ð�
    public bool TookDamageDuringRun { get; private set; }

    private ResourceFactory resourceFactory;
    //private StatHandler statHandler;
    //private AnimationHandler animationHandler;

    private float timeSinceLastChange = float.MaxValue; // ������ ü�� ���� ���� ��� �ð�

    public float CurrentHealth { get; private set; } // ���� ü�� (�ܺ� ���ٸ� ���)
    public float MaxHealth => resourceFactory.Health; // �ִ� ü���� StatHandler�κ��� ������

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
