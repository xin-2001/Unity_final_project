using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalDisappear : MonoBehaviour
{
    //移动的的目标
    GameObject target;
    //是否可以移动
    public bool isCanMove = false;
    //移动的速度
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanMove)
        {
            //向外移動
            int i = 0;
            transform.rotation = Quaternion.Euler(0,0,0);
            if (i == 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
                if (transform.position.x >= 0)
                {
                    transform.rotation = Quaternion.Euler(0,60,0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0,-60,0);
                }

                i = 1;
            }
            
            transform.Translate(Vector3.forward * Time.deltaTime*speed);
            Destroy(gameObject, 1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        //如果碰到的物体是玩家

        if (other.tag.Equals("Player"))
        {
            //這裡要扣分
            Destroy(gameObject, 0.1f);
        }
    }
}
