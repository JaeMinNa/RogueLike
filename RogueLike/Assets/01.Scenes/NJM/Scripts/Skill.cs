using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillItemData SkillData;

    private void Start()
    {
        // �÷��̾� ���׹̳� ����
        Debug.Log("���׹̳� " + SkillData.Stamina + " ����");
    }

    private void Update()
    {
        transform.position += new Vector3(1, 0, 0) * SkillData.SkillSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ������ ������
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("�� Hp " + SkillData.Atk + " ����");
            Instantiate(SkillData.SkillEffect, gameObject.transform.position + SkillData.SkillEffectPosition, Quaternion.identity);
        }
        else if(collision.tag == "Obstacle")
        {
            Destroy(gameObject);
            Instantiate(SkillData.SkillMissEffect, gameObject.transform.position + SkillData.SkillEffectPosition, Quaternion.identity);
        }

    }

}
