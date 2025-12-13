using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button grid2x2;
    public Button grid2x3;
    public Button grid4x4;
    public Button grid5x6;

    private int gridX = 0;
    private int gridY = 0;

    public GameObject homeUI;
    public GameObject gameUI;


    void Start()
    {
        grid2x2.onClick.AddListener(() => Update2X2GridLayout());
        grid2x3.onClick.AddListener(() => Update2X3GridLayout());
        grid4x4.onClick.AddListener(() => Update4X4GridLayout());
        grid5x6.onClick.AddListener(() => Update5X6GridLayout());
    }

    void Update2X2GridLayout()
    {
        gridX = 2;
        gridY = 2;
        SwitchToGameUI();
        GameManager.Instance.OnGameStarted.Invoke(gridX, gridY);
    }

    void Update2X3GridLayout()
    {
        gridX = 2;
        gridY = 3;
        SwitchToGameUI();
        GameManager.Instance.OnGameStarted.Invoke(gridX, gridY);
    }
    void Update4X4GridLayout()
    {
        gridX = 4;
        gridY = 4;
        SwitchToGameUI();
        GameManager.Instance.OnGameStarted.Invoke(gridX, gridY);
    }
    void Update5X6GridLayout()
    {
        gridX = 5;
        gridY = 6;
        SwitchToGameUI();
        GameManager.Instance.OnGameStarted.Invoke(gridX, gridY);
    }

    protected void SwitchToGameUI()
    {
        gameUI.SetActive(true);
        homeUI.SetActive(false);
    }
    protected void SwitchToHomeUI()
    {
        homeUI.SetActive(true);
        gameUI.SetActive(false);
    }
}
