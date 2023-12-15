using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask target;
    public LayerMask map;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(target.value == (target.value | (1 << collision.gameObject.layer)))
        {
            //�÷��̾� ����� ����
            DestroyProjectile();
        }

        if(map.value == (map.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        //fxȿ�� �ֱ�
        Destroy(gameObject);
    }
}
