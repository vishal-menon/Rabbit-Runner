using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private bool isStart = false;
    [SerializeField]
    private bool isJumping = false;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float jump;
    [SerializeField]
    private float moveSpeed;

    public Rigidbody2D rb;
    public UnityEvent hasStarted;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && isStart == true)
        {
            isJumping = false;

            _animator.SetBool("isJumping", false);
            _animator.SetBool("isStart", true);
        }
        else if (other.gameObject.CompareTag("Spike")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;

            _animator.SetBool("isStart", false);
            _animator.SetBool("isJumping", true);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && isStart == false)
        {
            isStart = true;  
            _animator.SetBool("isStart", true);
            hasStarted?.Invoke();
        }
        else if (Input.GetButtonDown("Jump") && isJumping == false) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if (isJumping &&  Math.Abs(rb.velocity.y) <= 5) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, -jump/100));
        }

        if (isStart) 
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }
}
