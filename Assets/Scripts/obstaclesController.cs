using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class obstaclesController : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out carController obstacles))
        {
            //OnEnter.Invoke(obstacles.gameObject);
            Debug.Log(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
