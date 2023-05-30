using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public GameObject inPlayMenu;
    private gameMaster gameMaster;
    public bool isInGame;
    void Start()
    {
        gameMaster = GameObject.FindObjectOfType<gameMaster>();
    }


    // Update is called once per frame
    void Update()
    {
        isInGame = gameMaster.isInGame;
        if (!isInGame)
        {
            resultBoard();
            gameMaster.isInGame = true;
        }
    }
    public void pauseButtonClicked()
    {
        Debug.Log("pasued");
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        inPlayMenu.SetActive(false);
    }
    public void continueButtonClicked()
    {
        Debug.Log("continue");

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        inPlayMenu.SetActive(true);
    }
    public void GameStart()
    {
        Time.timeScale = 1f;
        Debug.Log("gameStart");
        SceneManager.LoadScene(1);
    }
    public void Tutorial()
    {
        Debug.Log("tutorial");
        SceneManager.LoadScene(1);
    }
    public void GameQuit()
    {
        Debug.Log("gameQuit");
        Application.Quit();
    }
    public void return2Menu()
    {
        Debug.Log("return2Menu");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void resultBoard()
    {
        Debug.Log("resultBoard");
        Time.timeScale = 0f;
        SceneManager.LoadScene(2);
    }
}
