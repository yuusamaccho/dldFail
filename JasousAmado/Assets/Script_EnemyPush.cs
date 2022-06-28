using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyPush : MonoBehaviour
{
    public GameObject player;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("colision enemu8 plater");

            gameObject.GetComponent<SphereCollider>().radius = 5f;
            StartCoroutine(Timer());
        
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SphereCollider>().radius = 0.55f;
        Debug.Log("enemy shrink");
    }

}
