using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    List<Bullet> bullets = new List<Bullet>();

    //공격력
    [SerializeField]
    protected int damage;
    //다이스 레벨
    public float level = 1;

    //공격속도
    //속성
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
        // 공격딜레이마다 총알 생성및 총알 타겟 지정 

        // 공격 딜레이 = 코루틴으로 해결 (2성 3성 ... 눈금이 높아질수록...)

        // 다이스 생성할 때  인스턴티에이트 해서 따로 저장

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
