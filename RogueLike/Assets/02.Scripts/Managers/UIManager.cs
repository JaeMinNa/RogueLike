using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // ���� �� UI ����

    // ȭ�鿡 ǥ�õǴ� UI�� �ʱ�ȭ, ����, ���� ���� ó��

    // ����� �Է¿� ���� �̺�Ʈ ó�� ���

    public bool GameIsPaused = false;
    public GameObject PuaseMenuPanel;  

    private void Awake()
    {        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PuaseMenuPanel == null) return;

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        UIClose(PuaseMenuPanel);
        Time.timeScale = 1f;
        Debug.Log("���� �簳");
        GameIsPaused = false;
    }

    private void Pause()
    {
        UIOpen(PuaseMenuPanel);
        Time.timeScale = 0f;
        Debug.Log("���� ����");
        GameIsPaused = true;
    }

    private void UIOpen(GameObject wantToOpenUI)
    {
        wantToOpenUI.SetActive(true);
    }

    private void UIClose(GameObject wantToCloaseUI)
    {
        wantToCloaseUI.SetActive(false);
    }
}
