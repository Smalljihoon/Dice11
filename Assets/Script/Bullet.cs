using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    private Transform target;
    private int attackDamage = 0;       //���ݷ��� ���� �Ű�����

    Vector2 originPos;                          // ������ ���� ��ġ ( ����)
    float time;

    private void Start()
    {
    }

    public void Init(int damage, Transform target)
    {
        // Ÿ���� �̱��� 
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        if (target.Equals(collision.transform))
        {
            enemy.Damage(attackDamage);
            gameObject.SetActive(false);
        }

    }

    //private IEnumerator DamageMark()
    //{
    //    // ������ �ؽ�Ʈ ������ ������Ʈ ������
    //    // ������Ʈ ������, ������y, alpha ����

    //    for (float i = 1.0f;i<=0.0f; i -= 0.1f)
    //    {
    //        color.a = (float)i;
    //        damage_text.color = color;
    //    }

    //    yield return null;
    //}

}
