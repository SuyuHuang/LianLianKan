using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : SingleTemplate<UIManager>
{
    public Button PauseButton;

    public Button RestartButton;

    public Button ReturnButton;
    public Button ExitButton;

    public Button ShopResumeButton;
    public Button ShopButton;

    public GameObject PausePanel;
    public GameObject ShopPanel;


    public GameObject OverPanel;
    public GameObject Maps;
    public GameObject Enemy;


    private void Awake()
    {
        ShopButton.onClick.AddListener(OnShopClick);
        ShopResumeButton.onClick.AddListener(OnShopResumeClick);
        PauseButton.onClick.AddListener(OnPauseClick);
        RestartButton.onClick.AddListener(OnRestartClick);
        ReturnButton.onClick.AddListener(OnReturnClick);
        ExitButton.onClick.AddListener(OnExitClick);
        
    }

    private void OnPauseClick()
    {
        PausePanel.SetActive(true);
        Maps.SetActive(false);
        GameManager.IsPause = true;
        Enemy.SetActive(false);
    }

    private void OnShopResumeClick()
    {
        ShopPanel.SetActive(false);
        Maps.SetActive(true);
        GameManager.IsPause = false;
        Enemy.SetActive(true);
    }
    private void OnShopClick()
    {
        Enemy.SetActive(false);
        ShopPanel.SetActive(true);
        Maps.SetActive(false);
        GameManager.IsPause = true;
    }
    private void OnExitClick()
    {
        PausePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    private void OnReturnClick()
    {
        PausePanel.SetActive(false);
        Maps.SetActive(true);
        GameManager.IsPause = false;
        Enemy.SetActive(true);
    }

    private void OnRestartClick()
    {
        PausePanel.SetActive(false);
        OverPanel.SetActive(false);
        GameManager.IsPause = false;
        GameManager.IsOver = false;
        Timer.Instance.SliderValue = 1.0f;
        MapManager.MapCollect.Clear();
        SceneManager.LoadScene(1);
    }

    public void ShowOverPanel()
    {
        OverPanel.SetActive(true);
        Maps.SetActive(false);
        GameManager.IsPause = true;
    }
}
