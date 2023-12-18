using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectItem : MonoBehaviour
{
    public EffectItemData EffectData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            UseItem();
        }
    }

    public void UseItem()
    {
        // �÷��̾� ü��, ���׹̳� ���� �ڵ�
        Debug.Log("�÷��̾� Hp " + EffectData.Hp + " ȸ��");
        Debug.Log("�÷��̾� Stamina " + EffectData.Stamina + " ȸ��");

        Destroy(gameObject);
    }
}
