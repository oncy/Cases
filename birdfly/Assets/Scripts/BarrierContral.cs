using UnityEngine;
using System.Collections;
/*
 * 每一组地面+柱子的控制脚本
*/
public class BarrierContral : MonoBehaviour {
    public GameObject[] zhuzi;                                              //障碍数组
    public Vector3 positionBuffer;
    public float down = 0.5f, upper = 3.5f;                                 //障碍的上下限
    void Start() {
        Random.seed = System.Environment.TickCount;                         //随机数的种子
    }

    public void changeBarrier() {                                           //改变柱子高度
        float RandomVal;                                                    //随机数
        for (int i = 0;i < zhuzi.Length;i++) {
            zhuzi[i].SetActive(true);                                       //激活障碍对象
            positionBuffer = zhuzi[i].transform.position;                   //获取障碍当前的位置
            RandomVal = Random.value;                                       //随机数赋值 
            positionBuffer.y = Mathf.Lerp(down, upper, RandomVal);          //对障碍的高度进行插值计算
            zhuzi[i].transform.position = positionBuffer;                   //将改变高度后的位置变量赋值
        }
    }

    public void hidden() {                                                  //隐藏柱子
        for (int i = 0;i < zhuzi.Length;i++) {
            zhuzi[i].SetActive(false);                                      //设为不可用
        }
    }
}