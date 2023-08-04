using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Test.TestDotween
{
    public class TestDowteen : MonoBehaviour
    {
        public Transform ts1;
        public Transform ts2;
        private bool ok = true;

        public void Update()
        {
        }

        public void OnMouseOver()
        {
            if (ok)
            {
                ok = false;
                Debug.Log("====OnMouseOver====ts1=" + ts1.transform + " ts2=" + ts2.transform);
                // 朝向
                ts1.DOLookAt(ts2.position, 2);
                // 移动到目标点
                ts1.DOMove(ts2.position, 5);
            }
        }
    }
}