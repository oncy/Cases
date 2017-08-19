using UnityEngine;
using System.Collections;

public class BarrierMove : MonoBehaviour {

    public float moveSpeed;                                                 //移动速度
    public Vector3 Init_pos;                                                //初始化位置
    public GameObject[] barreir;                                            //障碍
    private Vector3[] load_pos = new Vector3[2];

    void Start() {
        barreir[0].GetComponent<BarrierContral>().hidden();                 //隐藏闪电
        barreir[1].GetComponent<BarrierContral>().changeBarrier();          //刷新并显示闪电
        Init_pos = barreir[1].transform.position;                           //保存第二个障碍组的位置
        //将位置保存在数组中，重置时用于恢复位置
        for (int i = 0;i < load_pos.Length;i++) {
            load_pos[i] = barreir[i].gameObject.transform.position;
        }
    }

    void Update() {
        for (int i = 0;i < barreir.Length;i++) {
            barreir[i].transform.Translate(
                    new Vector3(-Time.deltaTime * moveSpeed, 0, 0));        //障碍向左移动
            if (barreir[i].transform.position.x <= -20.2f) {                //障碍的左边界
                barreir[i].GetComponent<BarrierContral>().changeBarrier();  //刷新高度
                barreir[i].transform.position = Init_pos;                   //将障碍的位置恢复到初始化的位置 
            }
        }
    }

    public void resetBarrier() {                                            //重置障碍
        //恢复位置
        for (int i = 0;i < load_pos.Length;i++) {
            barreir[i].gameObject.transform.position = load_pos[i];
        }
        barreir[0].GetComponent<BarrierContral>().hidden();                 //一组隐藏
        barreir[1].GetComponent<BarrierContral>().changeBarrier();          //二组改变高度
    }
}