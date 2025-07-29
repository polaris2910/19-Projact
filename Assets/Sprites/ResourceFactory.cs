using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceFactory : MonoBehaviour
{
    // ü�� (1 ~ 3 ���� ���� ���)
    [Range(1, 3)][SerializeField] private int health = 3;
    // �ܺο��� ���� ������ ������Ƽ (�� ���� �� �ڵ����� 0~3 ���̷� ����)
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, 3);
    }

    // �̵� �ӵ� (1f ~ 20f ���� ���� ���)
    [Range(1f, 20f)][SerializeField] private float speed = 1;
    // �ܺο��� ���� ������ ������Ƽ (�� ���� �� 0~20f�� ����)
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
}
