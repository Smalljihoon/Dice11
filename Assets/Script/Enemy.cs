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
    [SerializeField] float speed;                           // 적 이동속도
    [SerializeField] float distance;                        // ray 거리
    [SerializeField] private TMP_Text hp_text;              // 적 체력
    int hp = 0;                                             // 초기화한 체력변수
    int life = 3;                                           // 플레이어 체력(하트 3목숨)

    //private Rigidbody2D rigid;
    //private RaycastHit2D hit;
    //private BoxCollider2D boxCollider;

    private Vector3[] directions = new Vector3[3];          // 몬스터가 방향을 바꿔야할 포인트 벡터배열
    private int count = 0;                                  // 배열값에 넣어줄 카운트 매개변수
    private int enemyID = 0;
    

    private void Start()
    {
        //rigid = GetComponent<Rigidbody2D>();
        directions[0] = transform.up;
        directions[1] = transform.right;
        directions[2] = transform.up * -1;  // down
    }

    public void Init(int hp, int enemyID)        // hp 초기화 함수
    {
        this.enemyID = enemyID;
        this.hp = hp;
        hp_text.text = hp.ToString();
    }

    private void FixedUpdate()
    {
        var pos = transform.position;

        Debug.DrawRay(pos, directions[count], new Color(1, 0, 0));

        var hit = Physics2D.Raycast(pos, directions[count], distance, LayerMask.GetMask("Wall"));

        if (hit.collider != null)
        {
            count++;
            //Debug.Log(hit.collider.name);
            //  transform.localEulerAngles = new Vector3(0, 0, rotationZ);
            //Debug.Log(rotationZ);
            //Debug.Log(enemy.transform.rotation.eulerAngles);
        }
    }

    void Update()
    {
        transform.Translate(directions[count] * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hole")
        {
            //Debug.Log("충돌");
            Destroy(this.gameObject);
            life--;
            SpawnManager.instance.LifeDown();
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
        hp_text.text = hp.ToString();

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
