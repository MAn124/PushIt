using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner instance;

    public static CoroutineRunner Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject runner = new GameObject("CoroutineRunner");
                DontDestroyOnLoad(runner); 
                instance = runner.AddComponent<CoroutineRunner>();
            }
            return instance;
        }
    }
}
