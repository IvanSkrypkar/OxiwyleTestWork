using UnityEngine;

public class GameScoreController : MonoBehaviour
{
    [SerializeField] UIController _uiController;
    public int _killsCount;
    public int _collisionsCount;

private void Awake()
    {
        LoadData();
    }

    public void UpdateKillsCount()
    {
        _killsCount++;
        _uiController.UpdateScoreUI();
        SaveData();
    }
    public void UpdateCollisionsCount()
    {
        _collisionsCount++;
        _uiController.UpdateScoreUI();
        SaveData();
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("KillsCount", _killsCount);
        PlayerPrefs.SetInt("CollisionsCount", _collisionsCount);
    }

    void LoadData()
    {  
        _killsCount = PlayerPrefs.GetInt("KillsCount", 0);
        _collisionsCount = PlayerPrefs.GetInt("CollisionsCount", 0);

        _uiController.UpdateScoreUI();
    }

    public void ClearScoreData()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
    }
}
