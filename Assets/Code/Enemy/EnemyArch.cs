using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArch : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    

    public float speed;
    public float move;


    private void FixedUpdate()
    {
        animator.SetFloat("Speed", move);
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

}
