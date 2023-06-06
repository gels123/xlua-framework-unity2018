using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestMgr : MonoBehaviour
{
    public GameObject cub1;
    public GameObject ui;
    public GameObject parent;
    public Button btn;

    private Vector3 btnmov = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("==TestMgr Start==");
        btn.onClick.AddListener(onBtnClick);

        BoxCollider collider = cub1.GetComponent<BoxCollider>();

        EventTrigger btnet = btn.GetComponent<EventTrigger>();
        if (btnet == null)
        {
            btnet = btn.gameObject.AddComponent<EventTrigger>();
        }
        
        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerDown;
        entry1.callback = new EventTrigger.TriggerEvent();
        entry1.callback.AddListener((pointData) =>
        {
            Debug.Log("btn PointerDown ");
        });
        btnet.triggers.Add(entry1);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback = new EventTrigger.TriggerEvent();
        entry2.callback.AddListener((baseEnvent =>
        {
            Debug.Log("btn PointerUp ");
        }));
        btnet.triggers.Add(entry2);

        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.Drag;
        entry3.callback = new EventTrigger.TriggerEvent();
        entry3.callback.AddListener((baseEvent =>
        {
            btn.transform.position = Input.mousePosition;
        }));
        btnet.triggers.Add(entry3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //鼠标移动到物体上面，弹出tips
            // Debug.Log("Left mouse down update is mouse on ui= " + EventSystem.current.IsPointerOverGameObject());
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo) && !EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("rayhit===" + hitInfo.collider.gameObject.name);
                // GameObject go = Instantiate(ui, parent.transform); //创建ui预制体
                // Destroy(go); //销毁ui预制体
            }
            //按钮跟随鼠标拖动而拖动
            // if (btnmov == Vector3.zero)
            // {
            //     btnmov = btn.transform.position - Input.mousePosition;
            // }
            // btn.transform.position = btnmov + Input.mousePosition;
        } else if (Input.GetMouseButtonUp(0))
        {
            // btnmov = Vector3.zero;
        }
    }

    private void OnDestroy()
    {
        
    }

    private void onBtnClick()
    {
        Debug.Log("onBtnClick type(GameObject)= " + typeof(GameObject));
        Debug.Log("onBtnClick " + btn.name + " txt = " + btn.transform.Find("Text").gameObject.GetComponent<Text>().text);
    }
}
