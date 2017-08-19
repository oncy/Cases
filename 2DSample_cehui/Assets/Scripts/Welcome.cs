using UnityEngine;
using System.Collections;

public class Welcome : MonoBehaviour {

    public Texture2D title;                     //游戏标题贴图
    public Texture2D begin;                     //开始按钮贴图
    public GUIStyle myStyle;                    //自定义GUIStyle

    // Use this for initialization
    void Start() { }

    // Update is called once per framev
    void Update() { }

    void OnGUI() {
        // 标题 
        float t_width = Screen.width * 0.6f;    //标题的宽度为屏幕的0.6倍
        float t_heigh = Screen.height * 0.7f;   //标题的高度为屏幕的0.7倍
        GUI.DrawTexture(new Rect(               //绘制纹理
            Screen.width * 0.5f - t_width / 2,
            Screen.height * 0.4f - t_heigh / 2,
            t_width, t_heigh), title);

        // 开始游戏按钮
        float b_width = Screen.width * 0.4f;    //标题的宽度为屏幕的0.4倍
        float b_heigh = Screen.height * 0.2f;   //标题的宽度为屏幕的0.2倍

        if (GUI.Button(new Rect(                //绘制按钮，判断点击事件
            Screen.width * 0.5f - b_width / 2,
            Screen.height * 0.7f - b_heigh / 2,
            b_width, b_heigh), begin, myStyle)) {
            Debug.Log("开始游戏");
            Application.LoadLevel("BatGame");   //加载BatGame场景
        }
    }
}
