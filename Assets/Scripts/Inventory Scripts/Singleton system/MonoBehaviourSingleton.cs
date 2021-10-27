using UnityEngine;

//use this class as base class for all of our ManagersSingleton that are of MonoBehaviour type
public abstract class MonoBehaviourSingleton : MonoBehaviour
{
    public static bool Quitting { get; private set; }

    //This method is a Unity Callback that informs that the game is Quitting. We need this to set the Quitting property to true to avoid uses of the Singleton when the application is already quitting
    private void OnApplicationQuit()
    {
        Quitting = true;
    }
}