using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   [SerializeField] private float speed = 2f;
   [SerializeField] private float jumpForce = 25f;
   private Rigidbody2D _rigidbody2D;
   private Animator _animator;
   private bool started;
   private bool grounded;
   private bool jumping;
   
   

   private void Awake()
   {
      _rigidbody2D = GetComponent<Rigidbody2D>();
      _animator = GetComponent<Animator>();
      grounded = true;
   }

   private void Update()
   {
      if (Input.GetKeyDown("space"))
      {
         if (started && grounded)
         {
            _animator.SetTrigger("Jump");
            grounded = false;
            jumping = true;
         }
         else
         {
            _animator.SetBool("GameStarted", true);
            started = true;
         }
      }
      
      _animator.SetBool("Grounded", grounded);
   }

   private void FixedUpdate()
   {
      if (started)
      {
         _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
      }

      if (jumping)
      {
         _rigidbody2D.AddForce(new Vector2(0f, jumpForce));
         jumping = false;
      }
   }

   private void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.CompareTag("Ground"))
      {
         grounded = true;
      }
   }
}
