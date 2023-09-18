using UnityEngine;
using XLua;

[Hotfix]
[LuaCallCSharp]
public class AppConfig : MonoBehaviour
{
    // 是否调试模式
    public static bool IsDebug()
    {
#if UNITY_EDITOR || CLIENT_DEBUG
        return true;
#endif
        return false;
    }
    
    // 是否编辑模式
    public static bool IsEditor()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }
}
