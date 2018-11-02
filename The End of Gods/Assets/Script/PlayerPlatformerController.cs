﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    KeyCode keyPressed = KeyCode.None;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 12;
    public bool isAttacking = false;


    private Animator animator;
    private SpriteRenderer sprite;
    Collider2D test;

    bool isGauche;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {

           
            if (Input.GetKey(vKey))
            {
                keyPressed = vKey;
                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Left"))
                {

                    move.x = -1.0f;
                    
                }
                else if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Right"))
                {
                    move.x = 1.0f;
                }

                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Jump") && grounded)
                {
                    velocity.y = jumpTakeOffSpeed;
                    
                }
                else if (Input.GetKeyUp(KeyImputManager.GetKeyBind("Jump").ToLower()))
                {               
                    if (velocity.y > 0)
                    {
                        velocity.y = velocity.y * 0.5f;
                        
                    }
                }

                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Left"))
                {
                    if (isGauche == false)
                    {
                        test = GameObject.FindGameObjectWithTag("SwordCollider").GetComponent<Collider2D>();
                        sprite.flipX = !sprite.flipX;
                        test.offset *= -1;
                    }
                        

                    isGauche = true;
                }
                else if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Right"))
                {
                    if (isGauche == true)
                    {
                        test = GameObject.FindGameObjectWithTag("SwordCollider").GetComponent<Collider2D>();
                        sprite.flipX = !sprite.flipX;
                        test.offset *= -1;
                    }

                    isGauche = false;
                }

                


                if (keyPressed.ToString() == KeyImputManager.GetKeyBind("Attack"))
                {
                   
                    if (Player_Info.ableToHit == true)
                    {
                        
                        if(grounded == true)
                        {
                            sound.PlaySound("Swoosh");
                            animator.Play("knight_Attack");
                            Player_Info.ableToHit = false;
                            Player_Info.timeForNextAttack = Player_Info.attackDelay;
                            //Invoke("StrikeFalse", 1);
                        }
                       
                         
                    }
                    

                   
                }

                targetVelocity = move * maxSpeed;

            }
        }

        animator.SetFloat("speed", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetBool("grounded", grounded);

        
    }
   // public void StrikeFalse()
    //{
   //     animator.SetBool("strike",false);
    //}
}




  

        
    