/*
 *  工具类
 */
using UnityEngine;

public class Utils {
    /*
     *  世界坐标转屏幕坐标
     *  @pos    世界坐标
     */
    public static Vector2 WorldToScreen(Vector3 pos)
    {
        return Camera.main.WorldToScreenPoint(pos);
    }
    
    /*
     *  屏幕坐标转世界坐标
     *  @pos        屏幕坐标
     *  @z          距离摄像机Z平面的距离
     */
    public static Vector2 ScreenToWorld(Vector2 pos, float z)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, z));
    }
    
    // RectTransformUtility.WorldToScreenPoint
    // RectTransformUtility.ScreenPointToWorldPointInRectangle
    // RectTransformUtility.ScreenPointToLocalPointInRectangle
    // 上面三个坐标转换的方法使用 Camera 的地方
    // 当 Canvas renderMode 为 RenderMode.ScreenSpaceCamera、RenderMode.WorldSpace 时 传递参数 canvas.worldCamera
    // 当 Canvas renderMode 为 RenderMode.ScreenSpaceOverlay 时 传递参数 null
    
    /*
     *  UGUI坐标转屏幕坐标
     *  @uiCamera    UGUI摄像机
     *  @pos         UGUI坐标
     */
    public static Vector2 UIToScreen(Camera uiCamera, Vector3 pos)
    {
        return RectTransformUtility.WorldToScreenPoint(uiCamera, pos);
    }

    /*
     *  屏幕坐标转UGUI坐标
     *  @uiCamera    UGUI摄像机：当Canvas renderMode为RenderMode.ScreenSpaceCamera、RenderMode.WorldSpace 时cam不能空, 为RenderMode.ScreenSpaceOverlay时cam可为空
     *  @rt          传target.GetComponent<RectTransform>(), 或target.parent.GetComponent<RectTransform>()
     *  @pos         屏幕坐标
     *  @ret         返回值  用法：target.transform.position = ret; //target为需要使用的 UI RectTransform
     */
    public static Vector3 ScreenToUI(Camera uiCamera, RectTransform rt, Vector2 pos)
    {
        Vector3 ret;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, pos, uiCamera, out ret);
        return ret;
    }
    
    /*
     *  屏幕坐标转UGUI RectTransform的anchoredPosition
     *  @uiCamera    UGUI摄像机
     *  @rt          传target.parent.GetComponent<RectTransform>()
     *  @pos         屏幕坐标
     *  @ret         返回值  用法：target.anchoredPosition = ret; //target为需要使用的 UI RectTransform
     */
    public static Vector2 ScreenToUILocal(Camera uiCamera, RectTransform parentrt, Vector2 pos)
    {
        Vector2 ret;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentrt, pos, uiCamera, out ret);
        return ret;
    }
    
    public static Vector2 WorldToUI(Vector3 pos, Transform ts)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);
        Vector2 ret;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)ts, screenPos, null, out ret);
        return ret;
    }
    
    /*
     * 将世界坐标转换为UGUI坐标 注: 这种算法, cavas不能用填充, 只能用居中
     */
    // static public Vector2 WorldToUgui(Vector3 pos)
    // {
    //     Vector2 screenPoint = Camera.main.WorldToScreenPoint(pos); //世界坐标转屏幕坐标
    //     Vector2 screenSize = new Vector2(Screen.width, Screen.height);
    //     screenPoint -= screenSize / 2;//屏幕坐标变换为以屏幕中心为原点
    //     Vector2 rectTrans = transform.GetComponent<RectTransform>();
    //     Vector2 anchorPos = screenPoint / screenSize * rectTrans.sizeDelta; //缩放得到UGUI坐标
    //     return anchorPos;
    // }
}