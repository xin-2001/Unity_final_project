using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peopleMagnet : MonoBehaviour
{
    //移动的的目标
    GameObject target;
    //是否可以移动
    public bool isCanMove = false;
    //移动的速度
    public float speed = 50;
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
            //向玩家移动的速度
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position,Time.deltaTime*speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //如果碰到的物体是玩家
        if (other.tag.Equals("Player"))
        {
            //碰到玩家后就会销毁
            Destroy(gameObject,0.1f);
        }
    }
}
