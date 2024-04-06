using UnityEngine;
using GameAnalyticsSDK;
using UnityEngine.SceneManagement;

public class GAInitialization : MonoBehaviour
{
    private void Start()
    {
        GameAnalytics.Initialize();
        SceneManager.LoadScene(1);
    }
}
