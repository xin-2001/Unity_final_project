using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour
{
    private static gameMaster instance;
    public int score = 0;
    public bool isInGame = true;
    private carController carController;
    private itemManager itemManager;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        carController = GameObject.FindObjectOfType<carController>();
        itemManager = GameObject.FindObjectOfType<itemManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
