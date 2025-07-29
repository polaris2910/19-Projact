using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    {
    public float jumpForce = 5f;

    public Transform groundCheck;
    public LayerMask groundLayer; 

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private int jumpCount = 0;
    private int maxjumpCount = 2;
    
     void Start()
     {
     //gameManager = GameManager.Instance; 추후 추가
     _animator = GetComponentInChildren<Animator>();
     _rigidbody = GetComponent<Rigidbody2D>(); 
     _animator = GetComponent<Animator>(); 

         if (_rigidbody == null)
             Debug.LogError("Rigidbody2D not found!");

         if (_animator == null)
             Debug.LogError("Animator not found!");
     }

     void Update()
    {
        // 바닥에 닿아있다면 점프 카운트 초기화
        if (IsGrounded())
        {
            jumpCount = 0;
        }

        // 점프 입력 처리
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxjumpCount)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            jumpCount++;

            if (_animator != null)
                _animator.SetTrigger("Jump");
        }

    }
    bool IsGrounded()
     {
         if (groundCheck == null) return false;

         Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
         return collider != null;
     }

}
