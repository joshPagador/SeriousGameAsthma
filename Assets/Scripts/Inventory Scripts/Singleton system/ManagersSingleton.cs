using UnityEngine;


//use this as a base class for all of our Managers that are of type MonoBehaviour
public abstract class ManagersSingleton<T> : MonoBehaviourSingleton where T : MonoBehaviour
{

    // private instance of this Manager

    private static T _instance;

    [SerializeField]
    private bool _persistent = false;

    public static T Instance
    {
        get
        {
            if (Quitting)
            {
                Debug.LogWarning($"[{nameof(MonoBehaviourSingleton)}<{typeof(T)}>] Instance will not be returned because the application is quitting.");
                return null;
            }

            if (_instance != null)
                return _instance;

            //The first time we check the entire scene to find the GameObject; next iterations we return the instance we already found without iterating the scene
            T[] instances = FindObjectsOfType<T>();
            int count = instances.Length;
            if (count > 0)
            {
                if (count == 1)
                    return _instance = instances[0];
                for (int i = 1; i < instances.Length; i++)
                    Destroy(instances[i].gameObject);
                return _instance = instances[0];
            }
            return _instance = new GameObject($"({nameof(MonoBehaviourSingleton)}){typeof(T)}").AddComponent<T>();

        }
    }


    private void Awake()
    {
        T[] instances = FindObjectsOfType<T>();
        int count = instances.Length;
        if (count > 1)
        {
            for (int i = 1; i < instances.Length; i++)
                Destroy(instances[i].gameObject);
            return;
        }

        if (_persistent)
        {
            if (gameObject.transform.parent != null)
                DontDestroyOnLoad(gameObject.transform.parent.gameObject);
            else
                DontDestroyOnLoad(gameObject);
        }
        OnAwake();
    }

    //Override this function from the subclasses the implement an Awake Unity Callback
    protected virtual void OnAwake() { }
}