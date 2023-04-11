using UnityEngine;
using UnityEngine.UI;
using SuperScrollView;

public class ChatMgr : MonoBehaviour
{
    public LoopListView2 mLoopListView;
    Button mScrollToButton;
    InputField mScrollToInput;
    Button mBackButton;
    Button mAppendMsgButton;

    // Use this for initialization
    void Start()
    {
        mLoopListView.InitListView(ChatMsgDataMgr.Get.TotalItemCount, OnGetItemByIndex);
        // mScrollToButton = GameObject.Find("ButtonPanel/buttonGroup2/ScrollToButton").GetComponent<Button>();
        // mScrollToButton.onClick.AddListener(OnJumpBtnClicked);
        // mScrollToInput = GameObject.Find("ButtonPanel/buttonGroup2/ScrollToInputField").GetComponent<InputField>();
        // mBackButton = GameObject.Find("ButtonPanel/BackButton").GetComponent<Button>();
        // mBackButton.onClick.AddListener(OnBackBtnClicked);
        // mAppendMsgButton = GameObject.Find("ButtonPanel/buttonGroup1/AppendButton").GetComponent<Button>();
        // mAppendMsgButton.onClick.AddListener(OnAppendMsgBtnClicked);
    }

    void OnBackBtnClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    void OnAppendMsgBtnClicked()
    {
        ChatMsgDataMgr.Get.AppendOneMsg();
        mLoopListView.SetListItemCount(ChatMsgDataMgr.Get.TotalItemCount, false);
        mLoopListView.MovePanelToItemIndex(ChatMsgDataMgr.Get.TotalItemCount-1, 0);
    }

    void OnJumpBtnClicked()
    {
        int itemIndex = 0;
        if (int.TryParse(mScrollToInput.text, out itemIndex) == false)
        {
            return;
        }
        if (itemIndex < 0)
        {
            return;
        }
        mLoopListView.MovePanelToItemIndex(itemIndex, 0);
    }

    LoopListViewItem2 OnGetItemByIndex(LoopListView2 listView, int index)
    {
        if (index < 0 || index >= ChatMsgDataMgr.Get.TotalItemCount)
        {
            return null;
        }

        ChatMsg itemData = ChatMsgDataMgr.Get.GetChatMsgByIndex(index);
        if (itemData == null)
        {
            return null;
        }
        LoopListViewItem2 item = null;
        if (itemData.mUserId == 0)
        {
            item = listView.NewListViewItem("ItemPrefab1");
        }
        else
        {
            item = listView.NewListViewItem("ItemPrefab2");
        }
        ChatListItem itemScript = item.GetComponent<ChatListItem>();
        if (item.IsInitHandlerCalled == false)
        {
            item.IsInitHandlerCalled = true;
            itemScript.Init();
        }
        itemScript.SetItemData(itemData,index);
        return item;
    }
}
