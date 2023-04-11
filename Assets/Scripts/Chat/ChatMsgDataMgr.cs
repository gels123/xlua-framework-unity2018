using System.Collections.Generic;
using UnityEngine;

public enum ChatMsgTypeEnum
{
    Str = 0,
    Picture = 1,
    Count = 2,
}

public class ChatUserInfo
{
    public int mUserId;
    public string mName;
    public string mHeadIcon;
}

public class ChatMsg
{
    public int mUserId;
    public ChatMsgTypeEnum mChatMsgType;
    public string mSrtMsg;
    public string mPicMsgSpriteName;
}

public class ChatMsgDataMgr : MonoBehaviour
{
    // Use this as singleton
    static ChatMsgDataMgr instance = null;
    
    Dictionary<int, ChatUserInfo> mUserInfoDict = new Dictionary<int, ChatUserInfo>();
    List<ChatMsg> mChatMsgList = new List<ChatMsg>();
    
    static string[] mChatDemoStrList = 
    {
        "Short Msg.",
        "Support ListView and GridView.",
        "Support Infinity Vertical and Horizontal ScrollView.",
        "Support items in different sizes such as widths or heights. Support items with unknown size at init time.",
        "Support changing item count and item size at runtime. Support looping items such as spinners. Support item padding.",
        "Use only one C# script to help the UGUI ScrollRect to support any count items with high performance.\nUse only one C# script to help the UGUI ScrollRect to support any count items with high performance.\nUse only one C# script to help the UGUI ScrollRect to support any count items with high performance.",
    };

    public static ChatMsgDataMgr Get
    {
        get
        {
            if (instance == null)
            {
                instance = Object.FindObjectOfType<ChatMsgDataMgr>();
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = null;
        Init();
    }
    
    public void Init()
    {
        mUserInfoDict.Clear();
        mChatMsgList.Clear();
        InitChatData();
    }
    
    void InitChatData()
    {
        ChatUserInfo tInfo = new ChatUserInfo();
        tInfo.mHeadIcon = ChatResMgr.Get.GetRandomSpriteName();
        tInfo.mUserId = 0;
        tInfo.mName = "Jaci";
        mUserInfoDict.Add(tInfo.mUserId, tInfo);

        tInfo = new ChatUserInfo();
        tInfo.mHeadIcon = ChatResMgr.Get.GetRandomSpriteName();
        tInfo.mUserId = 1;
        tInfo.mName = "Toci";
        mUserInfoDict.Add(tInfo.mUserId, tInfo);
        
        int count = mChatDemoStrList.Length;
        for (int i = 0; i < 100; ++i)
        {
            ChatMsg tMsg = new ChatMsg();
            tMsg.mChatMsgType = (ChatMsgTypeEnum)(Random.Range(0, 99) % 2); ;
            tMsg.mUserId = Random.Range(0, 99) % 2;
            tMsg.mSrtMsg = mChatDemoStrList[Random.Range(0, 99) % count];
            tMsg.mPicMsgSpriteName = ChatResMgr.Get.GetRandomSpriteName();
            mChatMsgList.Add(tMsg);
        }
    }

    public ChatUserInfo GetUserInfo(int userId)
    {
        ChatUserInfo ret = null;
        if(mUserInfoDict.TryGetValue(userId, out ret))
        {
            return ret;
        }
        return null;
    }

    public ChatMsg GetChatMsgByIndex(int index)
    {
        if (index < 0 || index >= mChatMsgList.Count)
        {
            return null;
        }
        return mChatMsgList[index];
    }

    public int TotalItemCount
    {
        get
        {
            return mChatMsgList.Count;
        }
    }

    public void AppendOneMsg()
    {
        int count = mChatDemoStrList.Length;
        ChatMsg tMsg = new ChatMsg();
        tMsg.mChatMsgType = (ChatMsgTypeEnum)(Random.Range(0, 99) % 2); ;
        tMsg.mUserId = Random.Range(0, 99) % 2;
        tMsg.mSrtMsg = mChatDemoStrList[Random.Range(0, 99) % count];
        tMsg.mPicMsgSpriteName = ChatResMgr.Get.GetRandomSpriteName();
        mChatMsgList.Add(tMsg);
    }
}
