using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public Player player;

    [SerializeField] private float healthChangeDelay = 3f; // ���� �� ���� ���� �ð�

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
        // ��ȭ ���ų� ���� ���¸� ����
        if (change == 0 || timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0f; // �ٽ� ���� ����

        // ü�� ����
        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        // �������� ��� (����)
        if (change < 0)
        {
            //Player.Damage(); // �´� �ִϸ��̼� ����
        }

        // ü���� 0 ���ϰ� �Ǹ� ��� ó��
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

}
