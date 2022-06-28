using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_WaterRise : MonoBehaviour
{
    private bool moved = false;
    public float rise = 0.1f;

    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moved == false)
        {
            GameStarted();
        }
    }

    private void FixedUpdate()
    {
        WaterRise();
    }

    void GameStarted()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            moved = true;
            //Debug.Log("A key or mouse click has been detected");

        }
    }

    void WaterRise()
    {
        if (moved == true)
        {
            water.transform.Translate(Vector3.up * Time.deltaTime * rise);
        }

    }

}
