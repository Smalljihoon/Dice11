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
    private int attackDamage = 0;       //공격력을 담을 매개변수

    Vector2 originPos;                          // 데미지 생성 위치 ( 월드)
    float time;

    private void Start()
    {
    }

    public void Init(int damage, Transform target)
    {
        // 타겟은 싱글톤 
        // 공격력 초기화 
        attackDamage = damage;
        this.target = target;

    }

    void Update()
    {
        // enable 하기전 총알 파괴 애니메이션
        // 타겟이 총알이 날아가는 도중에 파괴될시 바로 파괴 에니매이션 재생 
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }
        //타겟 방향으로 이동 
        transform.Translate((target.position - transform.position).normalized * speed * Time.deltaTime);
        // 에너미랑 부딪힐시 파괴 에니매이션 재생후 데미지 
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
    //    // 데미지 텍스트 프리팹 컴포넌트 들고오기
    //    // 컴포넌트 스케일, 포지션y, alpha 조절

    //    for (float i = 1.0f;i<=0.0f; i -= 0.1f)
    //    {
    //        color.a = (float)i;
    //        damage_text.color = color;
    //    }

    //    yield return null;
    //}

}
