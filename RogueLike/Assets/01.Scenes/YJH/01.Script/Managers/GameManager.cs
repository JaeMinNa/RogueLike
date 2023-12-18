using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    #region Global Variable
    [HideInInspector]
    public DataManager DataManager { get; private set; }
    [HideInInspector]
    public StageManager StageManager { get; private set; }
    [HideInInspector]
    public AudioManager AudioManager { get; private set; }
    [HideInInspector]
    public UIManager UiManager { get; private set; }
    #endregion

    #region Data Variable
    // Player Data
    // Monster, Item ���
    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        InitializSetting();
    }

    #region Initialize
    private void InitializSetting()
    {
        InitializeManager();
        InitializeData();
        InitializeStage();
        InitializeUI();
        InitializeAudio();
    }
    private void InitializeManager()
    {
        DataManager = GetComponentInChildren<DataManager>();
        StageManager = GetComponentInChildren<StageManager>();
        AudioManager = GetComponentInChildren<AudioManager>();
        UiManager = GetComponentInChildren<UIManager>();
    }

    private void InitializeData()
    {
        // ������ �ʱ�ȭ
    }

    private void InitializeStage()
    {
        // �������� �ʱ�ȭ
    }

    private void InitializeUI()
    {
        // UI �ʱ�ȭ
    }

    private void InitializeAudio()
    {
        // ����� �ʱ�ȭ
        AudioManager.InitalizeAudios();
    }
    #endregion

    #region Data
    public void PlayerDataUpdate()
    {
        DataManager.UpdatePlayerData(); // �Ķ���� PlayerData �ʿ�
    }
    #endregion

    #region Stage

    #endregion

    #region UI

    #endregion

    #region Audio
    public void PlayBackGroundMusic(string musicName)
    {

    }

    public void PlayerSoundEffects(string soundName)
    {

    }
    #endregion
}
