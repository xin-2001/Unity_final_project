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
    public float forceMagnitude = 20f;
    public Vector3 launchDirection = new Vector3(0f, 2f, 2f).normalized;
    private Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out carController obstacles))
        {
            if (!itemManager.isStar)
            {
                //OnEnter.Invoke(obstacles.gameObject);
                Debug.Log(other.gameObject);
                car.currentLocation = 3;
            }
            else
            {
                //吃到無敵星星的時候要做的事情，起飛
                Launch();
                Destroy(gameObject, 0.5f);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 獲取 carController.cs 的實例
        car = GameObject.FindObjectOfType<carController>();
        // 獲取 itemManager.cs 的實例
        itemManager = GameObject.FindObjectOfType<itemManager>();
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
    private void Launch()
    {
        Vector3 force = launchDirection * forceMagnitude;
        rb.AddForce(force, ForceMode.Impulse);
    }
}
