using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceFactory : MonoBehaviour
{
    // 체력 (1 ~ 3 사이 값만 허용)
    [Range(1, 3)][SerializeField] private int health = 3;
    // 외부에서 접근 가능한 프로퍼티 (값 변경 시 자동으로 0~3 사이로 제한)
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, 3);
    }

    // 이동 속도 (1f ~ 20f 사이 값만 허용)
    [Range(1f, 20f)][SerializeField] private float speed = 1;
    // 외부에서 접근 가능한 프로퍼티 (값 변경 시 0~20f로 제한)
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
}
