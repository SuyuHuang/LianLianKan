using UnityEngine;

/// <summary>
/// 脚本的单例模板基类
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingleTemplate<T> : MonoBehaviour where T : SingleTemplate<T>
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //从场景中找T脚本的对象
                _instance = FindObjectOfType<T>();

                if (FindObjectsOfType<T>().Length > 1)
                {
                    
                    return _instance;
                }

                //场景中找不到的情况
                if (_instance == null)
                {
                    string instanceName = typeof(T).Name;
                    GameObject instanceGO = GameObject.Find(instanceName);

                    if (instanceGO == null)
                    {
                        instanceGO = new GameObject(instanceName);
                        DontDestroyOnLoad(instanceGO);
                        _instance = instanceGO.AddComponent<T>();
                        DontDestroyOnLoad(_instance);
                    }
                    else
                    {
                        //场景中已存在同名游戏物体时就打印提示
                        Debug.LogError("场景中已存在单例脚本所挂载的游戏物体:" + instanceGO.name);
                    }
                }
            }

            return _instance;
        }
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}