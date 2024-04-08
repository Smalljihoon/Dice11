using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;               // �Ѿ� �ӵ�

    private Transform target;                   // Ÿ��
    private int attackDamage = 0;               // ���ݷ��� ���� �Ű�����

    private void Start()
    {

    }

    public void Init(int damage, Transform target)      // ���ݷ°� Ÿ�� �ʱ�ȭ ( ������ ��û�� ���� �޴� ��)
    {
        // ���ݷ� �ʱ�ȭ 
        attackDamage = damage;
        this.target = target;

    }

    void Update()
    {
        // enable �ϱ��� �Ѿ� �ı� �ִϸ��̼�
        // Ÿ���� �Ѿ��� ���ư��� ���߿� �ı��ɽ� �ٷ� �ı� ���ϸ��̼� ��� 
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        //Ÿ�� �������� �̵� 
        transform.Translate((target.position - transform.position).normalized * speed * Time.deltaTime);
        // ���ʹ̶� �ε����� �ı� ���ϸ��̼� ����� ������ 
    }

    private void OnTriggerEnter2D(Collider2D collision)         // �Ѿ� Ʈ���� ������
    {
        var enemy = collision.GetComponent<Enemy>();            // Enemy ��ũ��Ʈ ������Ʈ �ҷ�����

        if (target.Equals(collision.transform))                 // �浹 �����Ѱ� Ÿ�ٰ� ���ٸ�
        {
            enemy.Damage(attackDamage);                         // enemy�� Damage�Լ��� �ҷ� damage�Լ����� �޴� �Ű������� attackDamage����
            gameObject.SetActive(false);                        // �浹�� ���� �Ǿ����� �Ѿ� ������Ʈ ��Ȱ��ȭ
        }

    }
}
