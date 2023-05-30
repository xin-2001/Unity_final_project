using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    //磁鐵、無敵星星在這邊寫
    public bool isMagnet = false;
    public bool isStar = false;
    private carController car;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //如果玩家碰到磁鐵的話 就檢測玩家周圍的所有帶有碰撞器的遊戲對象
        if (isMagnet)
        {
            //檢測以玩家為球心半徑是5的範圍內的所有的帶有碰撞器的遊戲對象
            Collider[] colliders = Physics.OverlapSphere(this.transform.position, 2);
            foreach (var item in colliders)
            {
                //如果是人
                if (item.tag.Equals("people"))
                {
                    //讓人開始移動
                    item.GetComponent<peopleMagnet>().isCanMove = true;
                }
            }
        }
        if (isStar)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("cake"))
        {
            //設置玩家可以吸取周圍的人類
            isMagnet = true;
            //刪除磁鐵
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("ham"))
        {
            //設置玩家變成無敵狀態
            isStar = true;
            //刪除無敵星星
            Destroy(other.gameObject);
        }
    }
}
