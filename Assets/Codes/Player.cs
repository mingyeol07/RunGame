using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public float startJumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    CapsuleCollider2D capsuleCollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Jump();
        GroundCast();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Fire1")) {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
        }

        if (rigid.velocity.y < 0) {
            anim.SetBool("isJump", false);
        }
        
    
    }

    void GroundCast()
    {
        Debug.DrawRay(rigid.position, Vector3.down, new Color(0,1,0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 2, LayerMask.GetMask("Board"));

        if (rayHit.collider != null) {
            Debug.Log("dd");
            rayHit.collider.enabled = true;
        }
    }
}
