using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump02 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Scrollbar xulitiao;
    public Slider huadongtiao;
    public float presstime = 0f;
    public float pressForce = 1.0f;
    public bool flag = true;
    public float shuipingValue = 0f;
    public float chuizhiValue = 0f;
    public int num = 1;

    public GameObject UI_Src;//蓄力条
    public GameObject UI_Sli;//滑动条
    public LayerMask ground;//地面图层
    public Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xulitiao = GetComponent<Scrollbar>();
        huadongtiao = GetComponent<Slider>();
        coll = GetComponent<Collider2D>();

        Hide(UI_Src);//默认开始时蓄力条不出现
    }

    void Update()
    {
        if (coll.IsTouchingLayers(ground))//触碰地面图层
        {
            SliderMove();

            SliderStop();

            ScrollbarMaS();
        }

        ShowSli();
    }

    void Show(GameObject go)//UI显示
    {
        go.GetComponent<CanvasGroup>().alpha = 1;
    }

    void Hide(GameObject go)//UI隐藏
    {
        go.GetComponent<CanvasGroup>().alpha = 0;
    }

    void SliderMove()//滑动条运动
    {
        if (flag)
        {
            // huadongtiao.value=Time.time%1f;
            if (num % 2 != 0)
            {
                huadongtiao.value += Time.deltaTime;
            }
            if (huadongtiao.value >= 1 || huadongtiao.value <= 0)
            {
                num++;
            }
            if (num % 2 == 0)
            {
                huadongtiao.value -= Time.deltaTime;
            }
        }
    }

    void SliderStop()//滑动条停止移动
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            flag = false;
            shuipingValue = (float)(huadongtiao.value - 0.5) * 2.0f;

            Show(UI_Src);
        }
    }

    void ScrollbarMaS()//蓄力条开始和停止移动
    {
        if (Input.GetKey(KeyCode.W))
        {
            presstime += Time.deltaTime;
            xulitiao.size = presstime / 2f;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Hide(UI_Src);
            Hide(UI_Sli);

            chuizhiValue = xulitiao.size;
            rb.AddForce((new Vector2(shuipingValue, chuizhiValue)) * pressForce * presstime, ForceMode2D.Impulse);
            Debug.Log(shuipingValue);
            Debug.Log(chuizhiValue);
            presstime = 0f;
            flag = true;
        }
    }

    void ShowSli()//滑动条的显隐
    {
        if (coll.IsTouchingLayers(ground) && rb.velocity.x == 0)//接触地面且停止运动
        {
            Show(UI_Sli);
        }
        else
        {
            Hide(UI_Sli);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Collection")//道具类交互
        {
            Destroy(collision.gameObject);
        } 
    }
}
