using UnityEngine;
using GameAnalyticsSDK;
using UnityEngine.SceneManagement;

public class GAInitialization : MonoBehaviour
{
    private void Start()
    {
        GameAnalytics.Initialize();
        //Debug.Log("Game a")
        SceneManager.LoadScene(1);
    }
}
