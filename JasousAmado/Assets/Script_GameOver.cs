using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Script_GameOver : MonoBehaviour
{
    public float fullStamina = 100f;
    private float decreaseStamina = 10f;
    private float increaseStamina = 15f;
    private float lessJumpStamina = 20f;
    private float atualStamina;
    private bool onCollision = false;

    public Script_GamePause script_GP;

    public Image energySlide;
    public GameObject textBox;


    // Start is called before the first frame update
    void Start()
    {
        atualStamina = fullStamina;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    void FixedUpdate()
    {
        ShowAtualStamina();
        ReplenishStamina();
    }

    void ShowAtualStamina()
    {
        //stamina.text = atualStamina.ToString();
        energySlide.fillAmount = atualStamina / 100f;
        //Debug.Log("atual stamina: " + atualStamina);
    }

    /*
    public void YouWin()
    {
        textBox.GetComponent<TMP_Text>().text = "You Win!";
        textBox.SetActive(true);
        GamePaused();
    }
    */

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" || atualStamina > 0)
        {
            atualStamina = atualStamina - decreaseStamina * Time.deltaTime;
            onCollision = true;
            //Debug.Log("fez colison player stamina = " + stamina.text);
        }

    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            onCollision = false;
        }
    }

    public void StaminaJump()
    {
        atualStamina = atualStamina - lessJumpStamina;
        //Debug.Log("JUMP!");

    }

    void ReplenishStamina()
    {
        if (atualStamina <= fullStamina && onCollision == false)
        {
            atualStamina = atualStamina + increaseStamina * Time.deltaTime;
        }

    }

    void GameOver()
    {
        if (atualStamina <= 0)
        {
            energySlide.fillAmount = 0;
            //stamina.text = 0f.ToString();
            //ShowAtualStamina();

            //textBox.SetActive(true);
            //GamePaused();

            script_GP.Lose();
        }
    }

    void GamePaused()
    {
        Time.timeScale = 0;
    }

}
