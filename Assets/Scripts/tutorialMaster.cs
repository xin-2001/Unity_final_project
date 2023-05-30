using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialMaster : MonoBehaviour
{
    private carController carController;
    private menuManager menuManager;

    private GameObject temp;
    public GameObject[] mesBox = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.FindObjectOfType<menuManager>();
        carController = GameObject.FindObjectOfType<carController>();
        carController.tutorialIndex = 0;
        temp = GameObject.Find("gameMenu/MSB/M0");
        mesBox[0] = temp;
        temp = GameObject.Find("gameMenu/MSB/M1");
        mesBox[1] = temp;
        temp = GameObject.Find("gameMenu/MSB/M2");
        mesBox[2] = temp;
        temp = GameObject.Find("gameMenu/MSB/M3");
        mesBox[3] = temp;
        temp = GameObject.Find("gameMenu/MSB/M4");
        mesBox[4] = temp;
        temp = GameObject.Find("gameMenu/MSB/M5");
        mesBox[5] = temp;
        menuManager.inPlayMenu.SetActive(false);
        menuManager.pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && carController.tutorialIndex < 6)
        {
            carController.tutorialIndex += 1;
            mesBox[carController.tutorialIndex - 1].SetActive(false);
        }
        if (carController.tutorialIndex == 6)
        {
            carController.currentLocation = 0;
            carController.tutorialIndex = -1;
            temp = GameObject.Find("gameMenu/hint");
            temp.SetActive(false);
            menuManager.inPlayMenu.SetActive(true);
        }
    }
}
