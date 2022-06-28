using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject OptionsUI;
    public Script_ButtonClick buttonClick;

    // Start is called before the first frame update
    public void Play()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("entrou Play");
        SceneManager.LoadScene("Level01");
    }

    
    public void Options()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("entrou Options");
        MainMenuUI.SetActive(false);
        OptionsUI.SetActive(true);

    }

    public void BackMainMenu()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("saiu Options");
        OptionsUI.SetActive(false);
        MainMenuUI.SetActive(true);

    }

    /*
    public void Exit()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
    */
    
}
