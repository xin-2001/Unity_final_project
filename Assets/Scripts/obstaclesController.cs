using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class obstaclesController : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnter;
    private carController car;
    private itemManager itemManager;
    public int location;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out carController obstacles))
        {
            //OnEnter.Invoke(obstacles.gameObject);
            Debug.Log(other.gameObject);
            car.currentLocation = 3;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // 獲取 carController.cs 的實例
        car = GameObject.FindObjectOfType<carController>();
        if (car != null)
        {
            int location = car.currentLocation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (car != null)
        {
            int location = car.currentLocation;
        }
    }
}
