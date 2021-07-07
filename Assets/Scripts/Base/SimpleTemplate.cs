using UnityEngine;


public abstract class SingleTemplate<T> : MonoBehaviour where T : SingleTemplate<T>
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
       
                _instance = FindObjectOfType<T>();

                if (FindObjectsOfType<T>().Length > 1)
                {
                    
                    return _instance;
                }

       
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