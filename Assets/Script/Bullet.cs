using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;               // 총알 속도

    private Transform target;                   // 타겟
    private int attackDamage = 0;               // 공격력을 담을 매개변수

    private void Start()
    {

    }

    public void Init(int damage, Transform target)      // 공격력과 타겟 초기화 ( 앞으로 요청한 값을 받는 곳)
    {
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

    private void OnTriggerEnter2D(Collider2D collision)         // 총알 트리거 감지시
    {
        var enemy = collision.GetComponent<Enemy>();            // Enemy 스크립트 컴포넌트 불러오기

        if (target.Equals(collision.transform))                 // 충돌 감지한게 타겟과 같다면
        {
            enemy.Damage(attackDamage);                         // enemy의 Damage함수를 불러 damage함수에서 받는 매개변수에 attackDamage대입
            gameObject.SetActive(false);                        // 충돌이 감지 되었으니 총알 오브젝트 비활성화
        }

    }
}
