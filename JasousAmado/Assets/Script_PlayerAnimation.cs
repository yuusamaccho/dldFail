using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody player;

    public AudioSource jumpAudio;

    private bool aPressed = false;
    private bool dPressed = false;

    public bool onAir = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsMoving();
        Rotation();
    }

    void IsMoving()
    {
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            if (onAir == false)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void JumpAnima()
    {
        //jumpAudio.Play();
        animator.SetTrigger("isJumping");


    }

    void Rotation()
    {
        if (Input.GetKey("a") && aPressed == false)
        {
            player.transform.rotation = Quaternion.Euler(0, -90, 0);
            aPressed = true;
            dPressed = false;
        }

        if (Input.GetKey("d") && dPressed == false)
        {
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
            aPressed = false;
            dPressed = true;
        }
    }

}
