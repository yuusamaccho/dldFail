using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_FloorFall : MonoBehaviour
{
    RigidbodyConstraints originalCons;

    // Start is called before the first frame update
    void Awaken()
    {
        //originalCons = this.GetComponent<Rigidbody>().constraints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            StartCoroutine(Timer());
        }

        if (other.gameObject.tag == "Water")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Timer()
    {
        Debug.Log("is going to fall");
        yield return new WaitForSeconds(1);
        
        this.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePosition;
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Rigidbody>().AddForce(Vector3.down * 3, ForceMode.VelocityChange);
    }
}
