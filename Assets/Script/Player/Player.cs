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

    public Transform groundCheck; //�ٴ� üũ��
    public LayerMask groundLayer; 

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField] private BoxCollider2D normalCollider;
    [SerializeField] private BoxCollider2D slideCollider;

    private bool wasGrounded = false;
    void Start()
     {
     //gameManager = GameManager.Instance; ���� �߰�
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
        HandleGroundCheck(); // �ٴ� üũ �� ���� ī��Ʈ ����
        HandleJump();        // ���� �Է� ó��
        HandleFalling();     // ����/���� ���� �ִϸ��̼� ó��
        HandleSlide();       // �����̵� �Է� �� �ִϸ��̼� ó��
    }

    void HandleGroundCheck() 
    {
        bool grounded = IsGrounded();
        if (grounded && !wasGrounded)
            jumpCount = 0;
        wasGrounded = grounded; // ���� ���� ���
    }// �ٴ� üũ �� ���� ī��Ʈ ����

    void HandleJump()          // ���� �Է� ó��
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount) 
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            jumpCount++;

            _animator?.SetTrigger("Jump");          // ���� �ִϸ��̼� ���
            AudioManager.instance?.PlayJumpSound(); // ���� ���� ���
        }
    }

    void HandleFalling() 
    {
        float yVelocity = _rigidbody.velocity.y;
        bool grounded = IsGrounded();

        bool isFalling = !grounded && yVelocity < -0.1f;
        _animator?.SetBool("isFalling", isFalling); // ���� �ִϸ��̼� Ʈ����
        if (isFalling)
            _animator?.ResetTrigger("Jump");        // ���� Ʈ���� �ʱ�ȭ(���Ͻ�)
    }

    void HandleSlide() 
    {
        bool isSliding = Input.GetKey(KeyCode.LeftShift); // �Ʒ�Ű �Է½� �����̵�
        _animator?.SetBool("isSliding", isSliding);       // �����̵� �ִϸ��̼�

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
            //  ResourceManager���� ����+ü��+��ũ ����
            if (_resourceManager != null && _resourceManager.ChangeHealth(-1f))
            {
                TakeDamage();     
            }
        }

        IConsumable consumable = collision.gameObject.GetComponent<IConsumable>();
        consumable?.Eat(_resourceManager);
    }
}