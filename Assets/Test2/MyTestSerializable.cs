using System;
using UnityEngine;

namespace MyTestEditor
{
    public class MyTestAttribute : Attribute //定义特性
    {
    }
    [Serializable]
    [MyTest]
    public class MyTestPro
    {
        public int age;
        public string name;
    }
    public class MyTestSerializable : MonoBehaviour
    {
        public int id;
        public MyTestPro pro;
        public MyTestPro[] pros;
    }
}