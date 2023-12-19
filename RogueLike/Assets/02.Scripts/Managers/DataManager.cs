using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // ���� �����͸� �ε��ϰ� �����ϴ� ����

    // �÷��̾� ����, ������ ������, ���� ���� ���� �����͸� ����

    // �������� ���� �� ������Ʈ�� �ʿ��� ��� �̺�Ʈ �ý����� Ȱ��(����)


    #region Player Global Variable
    // baseStats.AttackSO (attackSpeed, power, range, target)
    [SerializeField] public CharacterStats PlayerBaseStats { get; private set; }

    // CharacterStats.PlayerCurrentStats (maxHealth, maxStamina, speed, invincibilityTime)
    public CharacterStats PlayerCurrentStats { get; private set; }
    #endregion

    private void Start()
    {
        // if (PlayerBaseStats == null) PlayerBaseStats = Resources.Load("Prefabs/DefaultAttackData", typeof(ScriptableObject)) as CharacterStats;
    }

    #region Player Data
    public void InitializePlayerData()
    {
        AttackSO attackSO = null;
        if (PlayerBaseStats != null)
            attackSO = Instantiate(PlayerBaseStats.attackSO);

        PlayerCurrentStats = new CharacterStats { attackSO = attackSO };
        PlayerCurrentStats.maxHealth = PlayerBaseStats.maxHealth;
        PlayerCurrentStats.speed = PlayerBaseStats.speed;
        PlayerCurrentStats.maxStamina = PlayerBaseStats.maxStamina;
        PlayerCurrentStats.invincibilityTime = PlayerBaseStats.invincibilityTime;
    }

    // 1�� ��� (AttackSO�� ��°�� �Ѱ��༭ ��ü)
    public void UpdatePlayerAttackSOData(AttackSO attackSO)
    {
        CharacterStats PlayerChangeStats = new CharacterStats { attackSO = attackSO };

        PlayerCurrentStats.attackSO.attackSpeed += PlayerChangeStats.attackSO.attackSpeed;
        PlayerCurrentStats.attackSO.power += PlayerChangeStats.attackSO.power;
        PlayerCurrentStats.attackSO.range += PlayerChangeStats.attackSO.range;
    }

    // 2�� ��� (�� ���� �޾Ƽ� ��ü)
    public void UpdatePlayerAttckSOData(float atkSpeed, float power, float range)
    {
        PlayerCurrentStats.attackSO.attackSpeed += atkSpeed;
        PlayerCurrentStats.attackSO.power += power;
        PlayerCurrentStats.attackSO.range += range;
    }

    public void UpdatePlayerStatsData(int health, int speed)
    {
        PlayerCurrentStats.maxHealth += health;
        PlayerCurrentStats.speed += speed;
    }
    #endregion

    #region Monster Data

    #endregion

    #region Item Data

    #endregion
}
