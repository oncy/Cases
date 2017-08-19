/*
 * 该脚本用于制作换帧动画 
 * 2014-11-07
 */
using UnityEngine;
using System.Collections;

public class BatAnimator : MonoBehaviour {

    public Sprite[] Sprites;                        //存放精灵
    public float framespPerSec;                     //每秒帧速率
    private SpriteRenderer spriterenderer;

    // Use this for initialization
    void Start() {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        int index = (int) (Time.time * framespPerSec);
        index = index % Sprites.Length;
        spriterenderer.sprite = Sprites[index];
    }
}
