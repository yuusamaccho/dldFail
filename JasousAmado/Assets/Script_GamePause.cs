using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GamePause : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject interfaceUI;
    public GameObject configUI;
    public GameObject winUI;
    public GameObject loseUI;

    public Script_ButtonClick buttonClick;

    /*
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }
    */
    // Update is called once per frame
    void Update()
    {
        CheckPauseMenu();
    }

    public void Resume()
    {
        //buttonClick.ButtonClickSound();

        interfaceUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        configUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        interfaceUI.SetActive(false);
        configUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        winUI.SetActive(false);
        loseUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MainMenu()
    {
        Debug.Log("voltou menu principal");
        Resume();
        //Destroy(GameObject.FindGameObjectWithTag("allScript"));
        //Destroy(GameObject.FindGameObjectWithTag("oceanSound"));

        SceneManager.LoadScene("MainMenu");
        //Resume();
    }

    public void Config()
    {
        //buttonClick.ButtonClickSound();

        Debug.Log("entra nas opções");
        interfaceUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);
        configUI.SetActive(true);

    }

    public void Sair()
    {
        //buttonClick.ButtonClickSound();

        Debug.Log("saiu do jogo");
        Application.Quit();
    }


    void CheckPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Win()
    {
        //buttonClick.ButtonClickSound();

        Debug.Log("wins");
        interfaceUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        configUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(true);

        Time.timeScale = 0f;

    }

    public void Lose()
    {
        Debug.Log("wins");
        interfaceUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        configUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(true);

        Time.timeScale = 0f;
    }
}
