using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.Experimental.GraphView.GraphView;
#endif

public class Player : MonoBehaviour
    {
    ResourceManager _resourceManager;

    public float jumpForce = 5f;
    private int jumpCount = 0;
    private int maxJumpCount = 2;

    public Transform groundCheck; //바닥 체크용
    public LayerMask groundLayer; 

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField] private BoxCollider2D normalCollider;
    [SerializeField] private BoxCollider2D slideCollider;

    private bool wasGrounded = false;
    void Start()
     {
     //gameManager = GameManager.Instance; 추후 추가
     _animator = GetComponentInChildren<Animator>();
     _rigidbody = GetComponent<Rigidbody2D>(); 
     _resourceManager = GetComponent<ResourceManager>();

        if (_rigidbody == null)
             Debug.LogError("Rigidbody2D not found!");

         if (_animator == null)
             Debug.LogError("Animator not found!");

     slideCollider.enabled = false;  
     normalCollider.enabled = true;

    }

    void Update()
    {
        HandleGroundCheck(); // 바닥 체크 및 점프 카운트 리셋
        HandleJump();        // 점프 입력 처리
        HandleFalling();     // 낙하/공중 상태 애니메이션 처리
        HandleSlide();       // 슬라이드 입력 및 애니메이션 처리
    }

    void HandleGroundCheck() 
    {
        bool grounded = IsGrounded();
        if (grounded && !wasGrounded)
            jumpCount = 0;
        wasGrounded = grounded; // 이전 상태 기록
    }// 바닥 체크 및 점프 카운트 리셋

    void HandleJump()          // 점프 입력 처리
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount) 
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            jumpCount++;

            _animator?.SetTrigger("Jump");          // 점프 애니메이션 재생
            AudioManager.instance?.PlayJumpSound(); // 점프 사운드 재생
        }
    }

    void HandleFalling() 
    {
        float yVelocity = _rigidbody.velocity.y;
        bool grounded = IsGrounded();

        bool isFalling = !grounded && yVelocity < -0.1f;
        _animator?.SetBool("isFalling", isFalling); // 낙하 애니메이션 트리거
        if (isFalling)
            _animator?.ResetTrigger("Jump");        // 점프 트리거 초기화(낙하시)
    }

    void HandleSlide() 
    {
        bool isSliding = Input.GetKey(KeyCode.LeftShift); // 아래키 입력시 슬라이드
        _animator?.SetBool("isSliding", isSliding);       // 슬라이드 애니메이션

        if (normalCollider != null)
        {
            if (isSliding)
            {
                normalCollider.enabled = false;
            }
            else
            {
                normalCollider.enabled = true;
            }
        }

        if (slideCollider != null)
        {
            if (isSliding)
            {
                slideCollider.enabled = true;
            }
            else
            {
                slideCollider.enabled = false;
            }
        }

    }
    
    
    bool IsGrounded()
    {
        if (groundCheck == null) return false;
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        return collider != null;
    }

    public void TakeDamage()
    {
        _animator?.SetTrigger("Hurt");
        AudioManager.instance?.PlayHurtSound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isObstacle = collision.CompareTag("Obstacle") ||
                     collision.gameObject.layer == LayerMask.NameToLayer("Obstacle");

        if (isObstacle)
        {
            //  ResourceManager에서 무적+체력+블링크 설정
            if (_resourceManager != null && _resourceManager.ChangeHealth(-1f))
            {
                TakeDamage();     
            }
        }

        IConsumable consumable = collision.gameObject.GetComponent<IConsumable>();
        consumable?.Eat(_resourceManager);
    }
}