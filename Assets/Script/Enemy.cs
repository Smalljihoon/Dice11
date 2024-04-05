using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//데미지 표시는 여기서
public class Enemy : MonoBehaviour
{
    //public enum TYPE
    //{
    //    NORMAL,
    //    CRITICAL,
    //}

    [SerializeField] float speed;                           // 적 이동속도
    [SerializeField] float distance;                        // ray 거리
    [SerializeField] TMP_Text hp_text;                      // 적 체력
    [SerializeField] TMP_Text damage_text;                  // 데미지 텍스트
    [SerializeField] float holdingTime;

    int hp = 0;                                             // 초기화한 체력변수
    int life = 3;                                           // 플레이어 체력(하트 3목숨)

    private Vector3[] directions = new Vector3[3];          // 몬스터가 방향을 바꿔야할 포인트 벡터배열
    private int count = 0;                                  // 배열값에 넣어줄 카운트 매개변수
    private int enemyID = 0;
    //public int remainDamage;

    private void Start()
    {
        damage_text = GetComponent<TMP_Text>();
        directions[0] = transform.up;
        directions[1] = transform.right;
        directions[2] = transform.up * -1;  // down
    }

    public void Init(int hp, int enemyID)        // hp, enemy순서 번호ID 초기화 함수
    {
        this.enemyID = enemyID;
        this.hp = hp;
        hp_text.text = hp.ToString();
        
    }

    private void FixedUpdate()
    {
        var pos = transform.position;           // pos = enemy 포지션

        Debug.DrawRay(pos, directions[count], new Color(1, 0, 0));      // ray그리기 ( pos에서 directions[]방향으로 & 색상

        var hit = Physics2D.Raycast(pos, directions[count], distance, LayerMask.GetMask("Wall"));

        if (hit.collider != null)
        {
            count++;
            //Debug.Log(hit.collider.name);
        }
    }

    void Update()   // enemy 이동 directions[] 방향값으로 
    {
        transform.Translate(directions[count] * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col) // trigger 감지
    {
        if (col.tag == "Hole")      // 충돌한게 Hole이면
        {
            //Debug.Log("충돌");
            Destroy(this.gameObject);   // enemy 파괴
            life--;                     // 생명 -1
            SpawnManager.instance.LifeDown();   // spawnmanager에서 관리하는 lifedown함수 싱글톤 불러오기
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
        hp_text.text = hp.ToString();
        damage_text.text = damage.ToString();

        if (hp<= 0)
        {
            Destroy(this.gameObject);
            if(SpawnManager.instance.enemyCount-1 == enemyID)
            {
                SpawnManager.instance.isClear = true;
            }
            //죽음
        }
    }

}
