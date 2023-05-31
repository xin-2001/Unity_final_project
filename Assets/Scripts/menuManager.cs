using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public GameObject inPlayMenu;
    public GameObject scoreBoard;
    private gameMaster gameMaster;
    private carController carController;
    public GameObject text1;
    public bool isInGame;
    public TMP_Text txt;

    public GameObject[] mesBox = new GameObject[6];
    void Start()
    {
        gameMaster = GameObject.FindObjectOfType<gameMaster>();
        if (GameObject.FindObjectOfType<carController>() != null) carController = GameObject.FindObjectOfType<carController>();
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
        if (GameObject.Find("gameMenu/scoreboard/point") != null)
        {
            //Debug.Log("抓到");
            text1 = GameObject.Find("gameMenu/scoreboard/point");
            txt = text1.GetComponent<TMP_Text>();
            txt.text = gameMaster.score.ToString();
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
        gameMaster.score = 0;
        Time.timeScale = 1f;
        Debug.Log("gameStart");
        SceneManager.LoadScene(1);
    }
    public void Tutorial()
    {
        Debug.Log("tutorial");
        SceneManager.LoadScene(3);
    }
    public void GameQuit()
    {
        Debug.Log("gameQuit");
        Application.Quit();
    }
    public void return2Menu()
    {
        if (GameObject.FindObjectOfType<carController>() != null) carController.tutorialIndex = -1;
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
