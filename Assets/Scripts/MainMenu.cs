using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public GameObject settingsPanel;
    public GameObject inventoryPanel;
    public GameObject profilePanel;
    public GameObject multiPanel;

    public void Start()
    {
        // Скрываем панели при запуске главного меню
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);

        if (profilePanel != null)
            profilePanel.SetActive(false);

        if (multiPanel != null)
            multiPanel.SetActive(false);
    }

    public void StartMultiplayerGame()
    {
        if (!PhotonNetwork.IsConnected)
        {
            // Если не подключены к серверу Photon, подключаемся
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            // Если уже подключены, загружаем сцену с сетевой игрой
            LoadMultiplayerGameScene();
        }
    }

    public void StartSinglePlayerGame()
    {
        // Загружаем сцену с одиночной игрой (замените "SinglePlayerGameScene" на название вашей сцены с одиночной игрой)
        SceneManager.LoadScene("SinglePlayerGame");
    }

    private void LoadMultiplayerGameScene()
    {
        // Загрузка сцены с сетевой игрой (замените "MultiplayerGameScene" на название вашей сцены с сетевой игрой)
        SceneManager.LoadScene("MultiplayerGameScene");
    }

    public void OpenSettingsPanel()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void OpenInventoryPanel()
    {
        if (inventoryPanel != null)
            inventoryPanel.SetActive(true);
    }

    public void CloseInventoryPanel()
    {
        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);
    }

    public void OpenProfilePanel()
    {
        if (profilePanel != null)
            profilePanel.SetActive(true);
    }

    public void CloseProfilePanel()
    {
        if (profilePanel != null)
            profilePanel.SetActive(false);
    }
    public void OpenMultiPanel()
    {
        if (multiPanel != null)
            multiPanel.SetActive(true);
    }

    public void CloseMultiPanel()
    {
        if (multiPanel != null)
            multiPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
