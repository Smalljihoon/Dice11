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
    Iron,
    Fire,
}

public class Dice : MonoBehaviour
{
    [SerializeField] GameObject bullet;                              // �Ѿ� ������Ʈ

    protected List<Bullet> bullets = new List<Bullet>();              // bullets ����Ʈ

    [SerializeField]
    protected int damage;                                         // ���ݷ�
    public int level = 0;                                        // in���� ��ȭ ��ġ �ִ� (7��������)
    //���ݼӵ�
    protected float rateTime = 1f;                                  // �߻� �ֱ�
    public Dice_category category;
    public int  eyes = 1;                                         // ���̽� ���� ����

    protected virtual void Start()
    {
        for (int i = 0; i < eyes; ++i)                                                          // ���̽� ���� ������ŭ for�� ���ư�
        {
            GameObject bulletGO = Instantiate(bullet, transform);        // bullet�� dice�� ��ġ���� ������ ���� bulletGameObject�� �ϰڴ�           
            bulletGO.SetActive(false);                                                       // bulletGO�� ������ �ʰ� �� ( �߻� ���̱⶧�� )
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();         // bulletGO�� �޸� Bullet ��ũ��Ʈ�� �ҷ����°� bulletItem�̶�� ����
            bulletGO.transform.localPosition = Vector3.zero;                // BulletGO�� ������������ ���������� (0,0,0)����

            bullets.Add(bulletItem);                                                        // ����Ʈ bullets�� bulletItem�� �߰�
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

    public void SetDiceEye()
    {
        int child_count = this.transform.childCount;
        for(int i = 0; i< child_count; ++i)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }

        if(this.eyes == 2)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if(this.eyes == 3)
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if(this.eyes == 4)
        {
            this.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (this.eyes == 5)
        {
            this.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (this.eyes == 6)
        {
            this.transform.GetChild(5).gameObject.SetActive(true);
        }
        else if (this.eyes == 7)
        {
            this.transform.GetChild(6).gameObject.SetActive(true);
        }
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

        float delay = 0.8f / eyes;

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
