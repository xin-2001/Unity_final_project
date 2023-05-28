using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peopleDisappear : MonoBehaviour
{
    public float DestroyTime = 5f;//消失的時間
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
