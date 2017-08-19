using UnityEngine;
using System.Collections;

public class AddFore : MonoBehaviour {
    Rigidbody2D r;
	//开始结束的向量坐标
    private Vector2 start;
    private Vector2 end;
	//是否触摸小球
    private bool isPing=false;

	void Start () 
    {
        r = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
    {
        //如果有触摸点
		if (Input.touchCount != 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
				//获取触摸点信息
                Touch touch = Input.touches[i];
				//如果开始触摸
                if (touch.phase == TouchPhase.Began)
                {
					//获取触摸点位置坐标
                    start = touch.position;
					//如果触摸小球
                    if ((start - new Vector2(Camera.main.WorldToScreenPoint(this.transform.position).x, Camera.main.WorldToScreenPoint(this.transform.position).y)).sqrMagnitude < 5000f)
                    {
                        isPing = true;
                    }
                }
				//如果正在触摸并滑动小球
                if (touch.phase == TouchPhase.Moved && isPing)
                {
					//获取触摸点距离上次改变的距离变量
                    Vector2 position = touch.deltaPosition;
					//给小球施加力
                    r.AddForce(position*4);
                }
				//如果触摸完成
                if (touch.phase == TouchPhase.Ended)
                {
                    isPing =false;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
            if ((start - new Vector2(Camera.main.WorldToScreenPoint(this.transform.position).x, Camera.main.WorldToScreenPoint(this.transform.position).y)).sqrMagnitude < 5000f)
            {
                isPing = true;
            }
        }
        if (Input.GetMouseButton(0) && isPing)
        {
            end = Input.mousePosition;
            Vector2 te = end - start;
            r.AddForce(te * 4);
            start = end;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPing = false;
        }
	}
}
