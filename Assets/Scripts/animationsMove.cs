using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationsMove : MonoBehaviour
{
    public float movementSpeed = 3;
    public float DestroyTime = 5f;//道具消失的時間
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Destroy(gameObject,DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }
}
