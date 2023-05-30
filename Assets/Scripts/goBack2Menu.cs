using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goBack2Menu : MonoBehaviour
{
    private menuManager menuManager;
    void Start()
    {
        menuManager = GameObject.FindObjectOfType<menuManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out carController player))
        {
            menuManager.pauseButtonClicked();
            Destroy(gameObject);
        }
    }
}
