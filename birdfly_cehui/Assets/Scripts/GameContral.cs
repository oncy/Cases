using UnityEngine;
using System.Collections;

public class GameContral : MonoBehaviour {
    public Texture2D reStart;       //重新开始按钮贴图
    public Texture2D exit;          //退出按钮贴图
    public bool isOver = false;     //游戏结束标志
    public GUIStyle myStyle;        //自定义的GUIStyle对象
    public GameObject BAT;          //蝙蝠游戏对象

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() {
        isOver = BAT.GetComponent<BatContral>().isOver;
    }

    void OnGUI() {

        float e_width = Screen.width * 0.1f;                            //退出图标的边长
        if (GUI.Button(new Rect(10, 10, e_width, e_width), exit, myStyle)) {
            Debug.Log("退出游戏");
            Application.Quit();                                         //退出程序方法
        }
        if (isOver) {                                                   //绘制重新开始按钮
            float r_width = Screen.width * 0.5f;
            float r_heigh = Screen.height * 0.3f;
            if (GUI.Button(new Rect(Screen.width * 0.5f - r_width / 2,
                           Screen.height * 0.6f - r_heigh / 2, r_width, r_heigh),
                           reStart, myStyle)) {
                reset();                                                //执行重置方法
            }
        }
    }
    void reset() {                                                      //重置方法
        isOver = false;                                                 //将是否结束的标志置为否
        BAT.GetComponent<BatContral>().resetBAT();                      //调用BatContral脚本中的重置方法
        this.gameObject.GetComponent<BarrierMove>().resetBarrier();     //调用BarrierMove脚本中的重置方法
    }
}
