using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Objects")]
    public Button settingsButton;
    public Button replayButton;
    public Button backButton;
    public Button skipButton;
    public Button nextStageButton;
    public GameObject settingPanel;

    [Tooltip("UI Slot Group")] public List<GameObject> slotGroup;
    
    public SkinData currData;

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        settingsButton?.onClick.AddListener(PauseLevel);
        backButton?.onClick.AddListener(PauseLevel);
        skipButton?.onClick.AddListener(() => GameManager.Instance.LoadNextLevel(sceneName));
        nextStageButton?.onClick.AddListener(() => GameManager.Instance.LoadNextLevel(sceneName));
        replayButton?.onClick.AddListener(() => GameManager.Instance.LoadLevel(sceneName));
        if (slotGroup[0] == null)
        {
            Transform slot = GameObject.Find("Canvas").transform.GetChild(0);
            for (int i = 0; i < 12; i++)
            {
                slotGroup[i] = slot.GetChild(i).gameObject;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseLevel();
        }
    }

    private void PauseLevel()
    {
        settingPanel?.SetActive(!GameManager.Instance.IsPause);
        GameManager.Instance.IsPause = !GameManager.Instance.IsPause;
    }
    
    /// <summary>
    /// Load level's information through level data
    /// </summary>
    /// <param name="invList">inventory list</param>
    public void UpdateInventories(List<Inventory> invList)
    {
        for (int i = 0; i < invList.Count; i++)
        {
            if (slotGroup[i].transform.GetChild(1).TryGetComponent(out Image image))
            {
                image.gameObject.SetActive(true);
                switch (invList[i].Type)
                {
                    case InventoryType.Square:
                        image.sprite = currData.Square;
                        break;
                    case InventoryType.Triangle:
                        image.sprite = currData.Triangle;
                        break;
                    case InventoryType.Heater:
                        image.sprite = currData.Heater;
                        break;
                }
            }
            if (slotGroup[i].transform.GetChild(2).TryGetComponent(out Text text))
            {
                text.gameObject.SetActive(true);
                text.text = invList[i].InventoryNum.ToString();
            }
            slotGroup[i].SetActive(true);
        }
    }
}