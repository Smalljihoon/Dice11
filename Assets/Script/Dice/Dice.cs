using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Dice_category
{
    None = 0,
    Growth,
    Joker,
    Snow,
    Sun,
    Iron
}

public class Dice : MonoBehaviour
{
    [SerializeField] GameObject bullet;                              // �Ѿ� ������Ʈ

   protected List<Bullet> bullets = new List<Bullet>();              // bullets ����Ʈ

    [SerializeField]
    protected int damage;                                           // ���ݷ�
    public float level = 1;                                         // ���̽� ���� ����
    //���ݼӵ�
    protected float rateTime = 1f;                                  // �߻� �ֱ�
    protected Dice_category category;
    
    private void Start()
    {
        for (int i = 0; i < level; ++i)                                  // ���̽� ���� ������ŭ for�� ���ư�
        {
            GameObject bulletGO = Instantiate(bullet, transform);        // bullet�� dice�� ��ġ���� ������ ���� bulletGameObject�� �ϰڴ�           
            bulletGO.SetActive(false);                                   // bulletGO�� ������ �ʰ� �� ( �߻� ���̱⶧�� )
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();         // bulletGO�� �޸� Bullet ��ũ��Ʈ�� �ҷ����°� bulletItem�̶�� ����
            bulletGO.transform.localPosition = Vector3.zero;             // BulletGO�� ������������ ���������� (0,0,0)����

            bullets.Add(bulletItem);                                     // ����Ʈ bullets�� bulletItem�� �߰�
        }
    }

    public virtual void Skill()
    {

    }

    private void OnDestroy()
    {
        StopAllCoroutines();                            // ��� �ڷ�ƾ ����

        foreach (var bulletGO in bullets)
        {
            Destroy(bulletGO.gameObject);               // bullets�� ��� �Ѿ� ������Ʈ Destroy
        }

        bullets.Clear();                                // bullets û��~
    }

    protected virtual void Update()
    {
        rateTime -= Time.deltaTime;                                 // �߻� �ֱ⿡ ���� �ֻ��� �߻� �ӵ��� �޶���
        if (rateTime <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)        // ���� Ÿ���� ������
            {
                StopAllCoroutines();                                // ��� �ڷ�ƾ ����
                StartCoroutine(Shot());                             // �߻� �ڷ�ƾ ����

                rateTime = 1f;                                      // ���� �߻��ֱ� 1�ʷ� �صױ⿡ �ٽ� 1�ʷ� �ʱ�ȭ
            }
        }

        
        // ���ݵ����̸��� �Ѿ� ������ �Ѿ� Ÿ�� ���� 

        // ���� ������ = �ڷ�ƾ���� �ذ� (2�� 3�� ... ������ ����������...)

        // ���̽� ������ ��  �ν���Ƽ����Ʈ �ؼ� ���� ����

    }

    protected virtual IEnumerator Shot()
    {
        while (true)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (var bullet in bullets)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    list.Add(bullet.gameObject);
                }
            }
            yield return null;

            if (list.Count == bullets.Count)
            {
                break;
            }
        }

        float delay = 0.8f / level;

        foreach (var bullet in bullets)
        {
            if (SpawnManager.instance.currentTarget == null)
                continue;

            bullet.gameObject.SetActive(true);

            bullet.transform.localPosition = Vector3.zero;

            bullet.Init(damage, SpawnManager.instance.currentTarget.transform);

            yield return new WaitForSeconds(delay);
        }
    }
}
