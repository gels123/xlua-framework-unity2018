using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Test.TestDotween
{
    public class TestDowteen : MonoBehaviour
    {
        public Transform ts1;
        public Transform ts2;
        public Text txt;
        public Image img1;
        public Image img2;
        public Camera cam;
        private bool ok = true;
        public void OnMouseOver()
        {
            if (ok)
            {
                ok = false;
                // Debug.Log("====OnMouseOver====ts1=" + ts1.transform + " ts2=" + ts2.transform);
                // // 朝向
                // ts1.DOLookAt(ts2.position, 2);
                // // 移动到目标点
                // ts1.DOMove(ts2.position, 5);
                // // 震动/抖动效果
                // ts1.DOShakeRotation(5);
                // // 动画生成文字
                // txt.DOText("Hello World!", 2);
                // // 颜色渐变
                // txt.DOColor(Color.red, 5);
                // // 渐隐
                // Tweener tweener = txt.DOFade(0.5f, 8);
                // tweener.onComplete = () =>
                // {
                //     GameObject.Destroy(txt);
                // };
                // // img2移动到3d物体处, 然后飘飞
                // Vector2 v = Utils.WorldToScreen(ts1.position);
                // img2.transform.position = v;
                // img2.transform.DOMove(img1.transform.position, 2);
            }
        }
        public void OnTweenerEnd()
        {
            Debug.Log("==OnTweenerEnd==");

            Animation anim = GetComponent<Animation>();
            anim.Play();
            anim.CrossFade("xxxx");
        }
    }
}