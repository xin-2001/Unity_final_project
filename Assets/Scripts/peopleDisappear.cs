using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peopleDisappear : MonoBehaviour
{
    public float DestroyTime = 5f;//消失的時間
    public float forwordSpeed= 0.5f;//向前速度
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*forwordSpeed);
    }
}
