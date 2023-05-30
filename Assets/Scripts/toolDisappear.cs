using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolDisappear : MonoBehaviour
{
    private bool isDisappear = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //如果玩家碰到吸铁石的话 就检测玩家周围的所有带有碰撞器的游戏对象
        /*if (isDisappear)
        {
            //检测以玩家为球心半径是5的范围内的所有的带有碰撞器的游戏对象
            Collider[] colliders = Physics.OverlapSphere(this.transform.position,2);
            foreach (var item in colliders)
            {
                //如果是人
                if (item.tag.Equals("animal"))
                {
                    //让金币的开始移动
                    item.GetComponent<animalDisappear>().isCanMove = true;
                }
            }

        }*/
        transform.Translate(Vector3.forward * Time.deltaTime*0.2f);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("onigiri"))
        {
            //设置玩家可以排斥動物
            isDisappear = true;
            //销毁吸铁石
            Destroy(other.gameObject);
        }
    }*/
}
