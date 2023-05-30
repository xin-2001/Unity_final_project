using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    //磁鐵、無敵星星在這邊寫
    public bool isMagnet = false;
    public bool isStar = false;
    private bool isDisappear = false;
    private carController car;
    private gameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.FindObjectOfType<gameMaster>();
        car = GameObject.FindObjectOfType<carController>();
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
        //如果玩家碰到吸铁石的话 就检测玩家周围的所有带有碰撞器的游戏对象
        if (isDisappear)
        {
            //检测以玩家为球心半径是5的范围内的所有的带有碰撞器的游戏对象
            Collider[] colliders = Physics.OverlapSphere(this.transform.position, 3);
            foreach (var item in colliders)
            {
                //如果是人
                if (item.tag.Equals("animal"))
                {
                    //让動物的开始移动
                    item.GetComponent<animalDisappear>().isCanMove = true;
                }
                if (item.tag.Equals("Car"))
                {
                    //让動物的开始移动
                    item.GetComponent<carDisappear>().isCanMove = true;
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("people"))
        {
            gameMaster.score = gameMaster.score + 1;
        }
        if (other.tag.Equals("animal"))
        {
            if (!isStar)
            {
                gameMaster.score = gameMaster.score - 1;
            }
        }
        if (other.tag.Equals("cake"))
        {
            //設置玩家可以吸取周圍的人類
            isMagnet = true;
            //刪除磁鐵
            Destroy(other.gameObject);
            Invoke("cakeMagent", 5);
        }
        if (other.tag.Equals("ham"))
        {
            //設置玩家變成無敵狀態
            isStar = true;
            //刪除無敵星星
            Destroy(other.gameObject);
            Invoke("hamStart", 5);
        }
        if (other.tag.Equals("onigiri"))
        {
            //设置玩家可以排斥動物
            isDisappear = true;
            //销毁吸铁石
            Destroy(other.gameObject);
            Invoke("onigiriDisappear", 5);
        }
    }
    private void cakeMagent()
    {
        isMagnet = false;
        //item.GetComponent<peopleMagnet>().isCanMove = false;
        Debug.Log("isCakeMagent");
    }
    private void hamStart()
    {
        isStar = false;
        Debug.Log("isHamStart");
    }
    private void onigiriDisappear()
    {
        isDisappear = false;
        Debug.Log("isOnigiriDisappear");
    }
}
