using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    private Transform target;
    //���ݷ�
    private int attackDaamage = 0;

    public void Init(int damage, Transform target)
    {
        // Ÿ���� �̱��� 
        // ���ݷ� �ʱ�ȭ 
        attackDaamage = damage;
        this.target = target;
    }

    void Update()
    {
        // Ÿ���� �Ѿ��� ���ư��� ���߿� �ı��ɽ� �ٷ� �ı� ���ϸ��̼� ��� 
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }
        //Ÿ�� �������� �̵� 
        transform.Translate((target.position - transform.position).normalized * speed * Time.deltaTime);
        // ���ʹ̶� �΋H���� �ı� ���ϸ��̼� ����� ������ 



        //transform.Translate(* speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        if (target.Equals(collision.transform))
        {
            enemy.Damage(attackDaamage);
            gameObject.SetActive(false);
        }

    }

}
