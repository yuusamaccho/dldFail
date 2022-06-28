using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Slip : MonoBehaviour
{
    public Script_PlayerMovement script_PM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //script_PM.speed = Time.deltaTime;
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            script_PM.speed = script_PM.speed / 2;
        }

    }

}
