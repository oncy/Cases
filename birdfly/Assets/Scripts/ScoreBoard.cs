using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    int sco = 0;                                    //储存成绩    
    public GameObject BAT;                          //蝙蝠游戏对象
    public GameObject NumSprite1;
    public GameObject NumSprite2;
    public Sprite[] Num;                            //数字图片数字

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() {
        sco = BAT.GetComponent<BatContral>().score; //获取玩家的成绩
        showScore(sco);                             //绘制计分板
    }

    void showScore(int num) {                       //绘制成绩方法
        int n1;                                     //十位数字
        int n2;                                     //个位数字
        if (num >= 100) {                           //大于一百，默认成绩为99
            n1 = 9;
            n2 = 9;
        } else {                                    //整除10，获取十位数数字
            n1 = num / 10;                          //对10取余，获取个位数字
            n2 = num % 10;
        }
        if (n1 == 0) {                              //如果十位是零，不对十位进行绘制
            NumSprite1.transform.gameObject.SetActive(false);
        } else {
            NumSprite1.transform.gameObject.SetActive(true);
            NumSprite1.GetComponent<SpriteRenderer>().sprite = Num[n1];
        }
        if (n1 == 0 && n2 == 0) {                   //十位和个位都是零，都不绘制
            NumSprite2.transform.gameObject.SetActive(false);
        } else {
            NumSprite2.transform.gameObject.SetActive(true);
            NumSprite2.GetComponent<SpriteRenderer>().sprite = Num[n2];
        }
    }
}
