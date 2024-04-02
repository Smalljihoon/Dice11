using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    private Transform target;
    //공격력
    private int attackDaamage = 0;

    public void Init(int damage, Transform target)
    {
        // 타겟은 싱글톤 
        // 공격력 초기화 
        attackDaamage = damage;
        this.target = target;
    }

    void Update()
    {
        // 타겟이 총알이 날아가는 도중에 파괴될시 바로 파괴 에니매이션 재생 
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }
        //타겟 방향으로 이동 
        transform.Translate((target.position - transform.position).normalized * speed * Time.deltaTime);
        // 에너미랑 부딫힐시 파괴 에니매이션 재생후 데미지 



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
