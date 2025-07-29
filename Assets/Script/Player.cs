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
            // 점프 입력 처리
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);

                if (_animator != null)
                    _animator.SetTrigger("Jump");
            }

            // 달리는 애니메이션 처리
            if (_animator != null)
                _animator.SetBool("isRunning", true);
        }

        bool IsGrounded()
        {
            if (groundCheck == null) return false;

            Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
            return collider != null;
        }
        
    }
