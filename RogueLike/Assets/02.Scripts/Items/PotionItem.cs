using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MonoBehaviour
{
    public PotionItemData PotionData;
    [SerializeField] private SkillItemDataList _skillItemDataList;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            UseItem();
        }
    }

    public void UseItem()
    {
        switch(PotionData.potionType)
        {
            case PotionType.Hp:
                HpItem();
                break;

            case PotionType.Power:
                PowerItem();
                break;

            case PotionType.Speed:
                SpeedItem();
                break;

            case PotionType.AttackSpeed:
                AttackSpeedItem();
                break;

            default:
                break;
        }
    }

    public void HpItem()
    {
        // �÷��̾� ü�� ���� �ڵ� TODO   
        Debug.Log("�÷��̾� Hp " + PotionData.Hp + " ȸ��");

        Destroy(gameObject);
    }

    public void PowerItem()
    {
        _spriteRenderer.color = new Color(255, 255, 255, 0);
        _circleCollider.enabled = false;

        // �÷��̾� �⺻ ���� x 2 �ڵ� TODO


        // ��ų ���� x 2 �ڵ�
        foreach (SkillItemData skill in _skillItemDataList.skillDataList)
        {
            skill.Atk *= 2;
        }

        StartCoroutine(RestorePower());
    }

    IEnumerator RestorePower()
    {
        yield return new WaitForSeconds(5f);
        
        // �⺻ ���� ���� TODO

        // ��ų ����
        foreach (SkillItemData skill in _skillItemDataList.skillDataList)
        {
            skill.Atk /= 2;
        }

        Destroy(gameObject);
    }

    public void SpeedItem()
    { 
        // �÷��̾� �ӵ� x 2 �ڵ� TODO
    }

    public void AttackSpeedItem()
    {
        _spriteRenderer.color = new Color(255, 255, 255, 0);
        _circleCollider.enabled = false;

        // �÷��̾� �⺻ ���ݼӵ� x 2 �ڵ� TODO

        // ��ų ���ݼӵ� x 2 �ڵ�
        foreach (SkillItemData skill in _skillItemDataList.skillDataList)
        {
            skill.CoolTime /= 2;
        }

        StartCoroutine(RestoreAttackSpeed());

    }

    IEnumerator RestoreAttackSpeed()
    {
        yield return new WaitForSeconds(5f);

        // �⺻ ���� �ӵ� ���� TODO

        // ��ų �ӵ� ����
        foreach (SkillItemData skill in _skillItemDataList.skillDataList)
        {
            skill.CoolTime *= 2;
        }

        Destroy(gameObject);
    }
}
