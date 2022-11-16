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

    public GameObject UI_Src;//������
    public GameObject UI_Sli;//������
    public LayerMask ground;//����ͼ��
    public Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xulitiao = GetComponent<Scrollbar>();
        huadongtiao = GetComponent<Slider>();
        coll = GetComponent<Collider2D>();

        Hide(UI_Src);//Ĭ�Ͽ�ʼʱ������������
    }

    void Update()
    {
        if (coll.IsTouchingLayers(ground))//��������ͼ��
        {
            SliderMove();

            SliderStop();

            ScrollbarMaS();
        }

        ShowSli();
    }

    void Show(GameObject go)//UI��ʾ
    {
        go.GetComponent<CanvasGroup>().alpha = 1;
    }

    void Hide(GameObject go)//UI����
    {
        go.GetComponent<CanvasGroup>().alpha = 0;
    }

    void SliderMove()//�������˶�
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

    void SliderStop()//������ֹͣ�ƶ�
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            flag = false;
            shuipingValue = (float)(huadongtiao.value - 0.5) * 2.0f;

            Show(UI_Src);
        }
    }

    void ScrollbarMaS()//��������ʼ��ֹͣ�ƶ�
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

    void ShowSli()//������������
    {
        if (coll.IsTouchingLayers(ground) && rb.velocity.x == 0)//�Ӵ�������ֹͣ�˶�
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
        if (collision.tag == "Collection")//�����ཻ��
        {
            Destroy(collision.gameObject);
        } 
    }
}
