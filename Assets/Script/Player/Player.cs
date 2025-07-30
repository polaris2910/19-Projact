using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
    {
    public float jumpForce = 5f;

    public Transform groundCheck;
    public LayerMask groundLayer; 

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private int jumpCount = 0;
    private int maxjumpCount = 2;

    private bool wasGrounded = false;
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
        bool grounded = IsGrounded();

        // "착지" 순간에만 점프카운트 초기화
        if (grounded && !wasGrounded)
        {
            jumpCount = 0;
        }
        wasGrounded = grounded;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxjumpCount)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            jumpCount++;

            if (_animator != null)
                _animator.SetTrigger("Jump");

            AudioManager.instance.PlayJumpSound();
            
        }
    }
    bool IsGrounded()
     {
        if (transform == null) return false;

        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        return collider != null;
     }

}
