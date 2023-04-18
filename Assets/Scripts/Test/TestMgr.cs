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
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("==TestMgr Start==");
        btn.onClick.AddListener(onBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Left mouse down update is mouse on ui= " + EventSystem.current.IsPointerOverGameObject());
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo) && !EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("rayhit===" + hitInfo.collider.gameObject.name);
                // GameObject go = Instantiate(ui, parent.transform); //创建ui预制体
                // Destroy(go); //销毁ui预制体
            }
        }
    }

    private void OnDestroy()
    {
        
    }

    private void onBtnClick()
    {
        Debug.Log("onBtnClick " + btn.name + " txt = " + btn.transform.Find("Text").gameObject.GetComponent<Text>().text);
    }
}
