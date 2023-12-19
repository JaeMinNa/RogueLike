using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // ���� �����͸� �ε��ϰ� �����ϴ� ����

    // �÷��̾� ����, ������ ������, ���� ���� ���� �����͸� ����

    // �������� ���� �� ������Ʈ�� �ʿ��� ��� �̺�Ʈ �ý����� Ȱ��(����)

    public CharacterStats playerStats;
    private GameObject player;

    public GameObject Player
    {
        get { return player; }
        set { player = value; }
    }

    #region Player Data
    public void UpdatePlayerData(CharacterStats stats)
    {
        // �÷��̾� ���� ������Ʈ ���� �ۼ� (�� �Ķ���� �߰� �ʿ�)
        playerStats = stats;
    }

    public void ChangeHealth(float value)
    {
        playerStats.currentHealth = Mathf.Clamp(playerStats.currentHealth - (int)value, 0, playerStats.maxHealth);
        Debug.Log("�������� �Ծ����ϴ� " + playerStats.currentHealth);
        Debug.Log("����ü��  " + playerStats.currentHealth);
    }
    #endregion

    #region Monster Data

    #endregion

    #region Item Data

    #endregion
}
