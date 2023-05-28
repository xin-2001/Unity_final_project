using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food_to_rotate : MonoBehaviour
{
    public float RotateSpeed = 50f;//旋轉速度
    public float DestroyTime = 5f;//道具消失的時間
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*Time.deltaTime*RotateSpeed,Space.World);
    }
}
