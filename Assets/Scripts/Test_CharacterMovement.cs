using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CharacterMovement : MonoBehaviour
{
    // [Header("Movement")]
    // [SerializeField] private float _speed = 5.0f;
    
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    /*private void Moveto()
    {
        // move forward
        Vector3 targetPosition = transform.position.z * Vector3.forward;

        Vector3 movement = Vector3.zero;
        movement.z = _speed;

        _characterController.Move(movement * Time.deltaTime);
    }*/
    private void Moveto()
	{   
        if (Input.GetKey("w"))
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, 5)* Time.deltaTime );
        }  //此類別.這個物件.座標系統.位移(delta向量)
        if (Input.GetKey("a"))
        {
            this.gameObject.transform.Translate(new Vector3(-5, 0, 0)* Time.deltaTime );
        }  //此類別.這個物件.座標系統.位移(delta向量)
        if (Input.GetKey("d"))
        {
            this.gameObject.transform.Translate(new Vector3(5, 0, 0)* Time.deltaTime );
        }  //此類別.這個物件.座標系統.位移(delta向量)
    }
    private void Update()
    {
        Moveto();
    }
}
