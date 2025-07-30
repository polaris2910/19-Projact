using UnityEngine;
using System;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance { get; private set; } // 싱글톤

    public float MaxHealth { get; private set; } = 100f;
    public float CurrentHealth { get; private set; }
    
    


}
