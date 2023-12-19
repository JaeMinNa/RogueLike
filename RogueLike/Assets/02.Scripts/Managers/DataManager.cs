using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    // ���� �����͸� �ε��ϰ� �����ϴ� ����

    // �÷��̾� ����, ������ ������, ���� ���� ���� �����͸� ����

    // �������� ���� �� ������Ʈ�� �ʿ��� ��� �̺�Ʈ �ý����� Ȱ��(����)


    #region Player Global Variable
    private GameObject player;

    public GameObject Player
    {
        get { return player; }
        set { player = value; }
    }

    // baseStats.AttackSO (attackSpeed, power, range, target)
    [SerializeField] private CharacterStats PlayerBaseStats;

    // CharacterStats.PlayerCurrentStats (maxHealth, maxStamina, speed, invincibilityTime)
    public CharacterStats PlayerCurrentStats { get; private set; }
    #endregion

    private void Start()
    {
        // if (PlayerBaseStats == null) PlayerBaseStats.attackSO = Resources.Load("Prefabs/DefaultAttackData", typeof(ScriptableObject)) as AttackSO;
    }

    #region Player Data
    public void InitializePlayerData()
    {
        AttackSO attackSO = null;
        if (PlayerBaseStats != null)
            attackSO = Instantiate(PlayerBaseStats.attackSO);

        PlayerCurrentStats = new CharacterStats { attackSO = attackSO };
        PlayerCurrentStats.maxHealth = PlayerBaseStats.maxHealth;
        PlayerCurrentStats.currentHealth = PlayerBaseStats.currentHealth;
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
        PlayerCurrentStats.currentHealth += health;
        PlayerCurrentStats.speed += speed;
    }
    public void ChangeHealth(float value)
    {
        PlayerCurrentStats.currentHealth = Mathf.Clamp(PlayerCurrentStats.currentHealth - (int)value, 0, PlayerCurrentStats.maxHealth);
        Debug.Log("�������� �Ծ����ϴ� " + PlayerCurrentStats.currentHealth);
        Debug.Log("����ü��  " + PlayerCurrentStats.currentHealth);
    }
    #endregion

    #region Monster Data

    #endregion

    #region Item Data

    #endregion
}
