using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // ���� �����͸� �ε��ϰ� �����ϴ� ����

    // �÷��̾� ����, ������ ������, ���� ���� ���� �����͸� ����

    // �������� ���� �� ������Ʈ�� �ʿ��� ��� �̺�Ʈ �ý����� Ȱ��(����)

    public CharacterStats playerStats;

    #region Player Data
    public void UpdatePlayerData(CharacterStats stats)
    {
        // �÷��̾� ���� ������Ʈ ���� �ۼ� (�� �Ķ���� �߰� �ʿ�)
        playerStats = stats;
    }
    #endregion

    #region Monster Data

    #endregion

    #region Item Data

    #endregion
}
