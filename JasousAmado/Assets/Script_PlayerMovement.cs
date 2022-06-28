using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerMovement : MonoBehaviour
{
    private bool jumpKey;
    private float horizontalInput;
    private float lastHI;

    public int speed = 9;
    public int jump = 8;

    private float fallMulti = 2.5f;
    private float lowFallMulti = 2f;

    public Transform groundCheck = null;
    public LayerMask playerMask;
    private Rigidbody rigidbodyComponent;

    public Script_GameOver scriptGO;
    public Script_PlayerAnimation scriptPA;
    public Script_GamePause scriptGP;
    private bool hitIce;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = true;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput > 0.225f || horizontalInput < -0.225f)
        {
            lastHI = horizontalInput;
        }
                
        CheckTouchGround();

        SlipOrNot();
    }

    private void FixedUpdate()
    {
        //PMovement();
        BetterJump();
        //Debug.Log("speed = " + speed);
    }

    void PMovement(float hInput)
    {
        rigidbodyComponent.velocity = new Vector3(hInput * speed, rigidbodyComponent.velocity.y, rigidbodyComponent.velocity.z);
                
    }
    
    void CheckTouchGround()
    {
        if (Physics.OverlapSphere(groundCheck.position, 0.1f, playerMask).Length == 0)
        //verifica se o empty (que tá no "pé" do player) ta fazendo colisao com algo
        {
            scriptPA.onAir = false;
            Debug.Log("entrou overlap");
            //jumpKey = false;
            return;
        }

        IsJumpOk();
    }

    void IsJumpOk()
    {
        if (jumpKey == true)
        {
            scriptPA.onAir = true;
            scriptPA.JumpAnima();

            scriptGO.StaminaJump();
            rigidbodyComponent.AddForce(Vector3.up * jump, ForceMode.VelocityChange);
            jumpKey = false;

        }
    }

    void BetterJump()
    {
        if (rigidbodyComponent.velocity.y < 0)
        {
            rigidbodyComponent.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;

        }
        else
            if (rigidbodyComponent.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rigidbodyComponent.velocity += Vector3.up * Physics.gravity.y * (lowFallMulti - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bouncer")
        {
            scriptPA.JumpAnima();
        }

        if(other.gameObject.tag == "Goal")
        {
            Debug.Log("goalllllll");
            scriptGP.Win();
        }

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Slip")
        {
            hitIce = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Slip")
        {
            hitIce = false;
            //StartCoroutine(Timer());
            
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        hitIce = false;
    }

    void SlipOrNot()
    {
        if (hitIce && horizontalInput == 0)
        {
            PMovement(lastHI);
            
        }
        else
        {
            hitIce = false;
            PMovement(horizontalInput);
            
        }
    }

   

}
