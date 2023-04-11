using System.Collections.Generic;
using UnityEngine;

public class ChatResMgr : MonoBehaviour
{
    // Use this as singleton
    private static ChatResMgr instance = null;

    public Sprite[] spriteObjArray;

    private readonly Dictionary<string, Sprite> spriteObjDict = new Dictionary<string, Sprite>();

    public static ChatResMgr Get
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<ChatResMgr>();
            return instance;
        }
    }

    public int SpriteCount => spriteObjArray.Length;

    private void Awake()
    {
        instance = null;
        Init();
    }

    private void Init()
    {
        spriteObjDict.Clear();
        foreach (var sp in spriteObjArray) spriteObjDict[sp.name] = sp;
    }

    public Sprite GetSpriteByName(string spriteName)
    {
        Sprite ret = null;
        if (spriteObjDict.TryGetValue(spriteName, out ret)) return ret;
        return null;
    }

    public string GetRandomSpriteName()
    {
        var count = spriteObjArray.Length;
        if (count > 0)
        {
            var index = Random.Range(0, count);
            return spriteObjArray[index].name;
        }
        else
        {
            return "";
        }
    }

    public Sprite GetSpriteByIndex(int index)
    {
        if (index < 0 || index >= spriteObjArray.Length)
            return null;
        return spriteObjArray[index];
    }

    public string GetSpriteNameByIndex(int index)
    {
        if (index < 0 || index >= spriteObjArray.Length)
            return "";
        return spriteObjArray[index].name;
    }
}