using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameScoreController _gameScoreController;
    [SerializeField] Text _killsCountText, _collisionsCountText;
    [SerializeField] GameObject _pausePanel;

    public void UpdateScoreUI()
    {
        _killsCountText.text = _gameScoreController._killsCount.ToString();
        _collisionsCountText.text = _gameScoreController._collisionsCount.ToString();
        //Test unity hub on main branch
    }

    public void PauseButton()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }
    public void ClearScoreData()
    {
        _gameScoreController.ClearScoreData();
        UpdateScoreUI();
    }
}
