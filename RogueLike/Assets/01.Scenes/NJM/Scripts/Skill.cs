using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillItemData SkillData;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // �÷��̾� ���׹̳� ����
        Debug.Log("���׹̳� " + SkillData.Stamina + " ����");
    }

    private void Update()
    {
        
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

    public void SkillShoot(Vector2 direction)
    {
        if (direction.x < 0)
        {
            if (_spriteRenderer.flipX == true) _spriteRenderer.flipX = false;
            else _spriteRenderer.flipX = true;
        }

        _rigidbody.velocity = direction * SkillData.SkillSpeed;
    }
}
