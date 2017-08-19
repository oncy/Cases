using UnityEngine;
using System.Collections;

public class BatContral : MonoBehaviour {

    AudioSource source;         //音频源
    public GUIStyle myStyle;    //自定义GUIStyle
    public AudioClip fly;       //跳跃音频
    public AudioClip point;     //通过音频
    public AudioClip die;       //死亡音频
    public Vector2 force;       //对蝙蝠施加的力
    public Vector3 initPos;     //初始化位置
    public int score;           //玩家成绩
    Rigidbody2D body;           //2D刚体对象
    public bool isOver = false; //判断游戏是否结束
    public Texture2D reStart;   //重新开始游戏贴图

    // Use this for initialization
    void Start() {
        force = new Vector2(0, 450);
        body = gameObject.GetComponent<Rigidbody2D>();          //添加2D刚体
        source = this.gameObject.GetComponent<AudioSource>();   //获取音频源
        initPos = gameObject.transform.position;                //记录游戏对象初始化的位置
        score = 0;                                              //玩家成绩置零
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) {
            source.PlayOneShot(fly);                            //播放音效
            body.AddForce(force);                               //对游戏对象施加一个向上的力
        }
    }

    void OnTriggerEnter2D(Collider2D other) {                   //碰撞检测
        if (other.gameObject.tag.CompareTo("Point") == 0) {
            Debug.Log("加分");
            source.PlayOneShot(point);                          //播放通过音效
            score++;                                            //成绩加一
        }
        if (other.gameObject.tag.CompareTo("Wall") == 0) {
            Debug.Log("撞墙");
            source.PlayOneShot(die);                            //播放失败音效
            Time.timeScale = 0;                                 //游戏暂停
            isOver = true;                                      //结束标志置为true
        }
    }

    public void resetBAT() {                        //重新开始方法        
        //重新开始
        isOver = false;                             //是否结束游戏置为否
        this.transform.position = initPos;          //恢复位置
        Time.timeScale = 1;                         //结束暂停游戏
        score = 0;                                  //成绩置零
    }
}
