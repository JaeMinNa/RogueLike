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
            Debug.Log("�� Hp " + SkillData.Atk + " ����");
        }
    }


}
