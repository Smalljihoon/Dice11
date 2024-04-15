using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    List<Bullet> bullets = new List<Bullet>();

    //���ݷ�
    [SerializeField]
    protected int damage;
    //���̽� ����
    public float level = 1;

    //���ݼӵ�
    //�Ӽ�
    protected float rateTime = 1f;       // 

    private void Start()
    {
        for (int i = 0; i < level; ++i)
        {
            var bulletGO = Instantiate(bullet, transform);
            bulletGO.SetActive(false);
            var bulletItem = bulletGO.GetComponent<Bullet>();
            bulletGO.transform.localPosition = Vector3.zero;

            bullets.Add(bulletItem);
        }
    }

    public virtual void Skill()
    {

    }
    private void OnDestroy()
    {
        StopAllCoroutines();

        foreach (var bulletGO in bullets)
        {
            Destroy(bulletGO.gameObject);
        }

        bullets.Clear();
    }
    protected virtual void Update()
    {
        rateTime -= Time.deltaTime;
        if (rateTime <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)
            {
                StopAllCoroutines();
                StartCoroutine(Shot());

                rateTime = 1f;
            }
        }
        // ���ݵ����̸��� �Ѿ� ������ �Ѿ� Ÿ�� ���� 

        // ���� ������ = �ڷ�ƾ���� �ذ� (2�� 3�� ... ������ ����������...)

        // ���̽� ������ ��  �ν���Ƽ����Ʈ �ؼ� ���� ����

    }

    IEnumerator Shot()
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
