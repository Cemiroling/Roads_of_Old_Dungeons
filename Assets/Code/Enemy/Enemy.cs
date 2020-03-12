using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator animatorController;


    private float move;

    private bool isDealDamage = false;
    private bool isStateAttack = false;
    private bool isICanAttack = false;
    private bool isFoundPlayer = false;

    private float defaultSpeed;
    private int prefMove;

    [Header("Скорость")]
    public float walkSpeed;
    [Header("Радиус атаки")]
    public float attackRange;
    [Header("Радиус поиска игрока")]
    public float searchRange;
    public LayerMask enemyLayer;
    [Header("Bars")]
    public HealthBar healthBar;
    [Header("Урон")]
    public float damageOfEnemy;
    [Header("Задержка между атаками (сек)")]
    public float secDelayAttack;


    [Header("Работа с землёй")]
    public Transform groundCheck;
    public LayerMask groundMask;
    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
        defaultSpeed = walkSpeed;
        move = 1;
        prefMove = 1;
    }

    /*private void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 2f, groundMask);
        if (!groundInfo)
            Flip();
        SearchPlayer();
        if (isFoundPlayer)
            Attack();


    }
    private void Flip()

    {
        Vector3 theScale = _transform.localScale;
        theScale.x *= -1;
        move *= -1;
        prefMove *= -1;
        _transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            Flip();
    }

    private void FixedUpdate()
    {
        animatorController.SetFloat("Speed", Mathf.Abs(move));
        _rigidbody.velocity = new Vector2(move * walkSpeed, _rigidbody.velocity.y);
    }*/
}
