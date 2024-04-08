using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public enum TYPE
    //{
    //    NORMAL,
    //    CRITICAL,
    //}

    [SerializeField] float speed;                           // �� �̵��ӵ�
    [SerializeField] float distance;                        // ray �Ÿ�
    [SerializeField] TMP_Text hp_text;                      // �� ü��
    public GameObject dmgTextPrefab;                        // ������ ������
    public Transform dmgPos;                                // ������ ������ ��ġ

    int hp = 0;                                             // �ʱ�ȭ�� ü�º���
    int life = 3;                                           // �÷��̾� ü��(��Ʈ 3���)

    private Vector3[] directions = new Vector3[3];          // ���Ͱ� ������ �ٲ���� ����Ʈ ���͹迭
    private int count = 0;                                  // �迭���� �־��� ī��Ʈ �Ű�����
    private int enemyID = 0;

    private void Start()
    {
        directions[0] = transform.up;
        directions[1] = transform.right;
        directions[2] = transform.up * -1;  // down
    }

    public void Init(int hp, int enemyID)           // hp, enemy���� ��ȣID �ʱ�ȭ �Լ�
    {
        this.enemyID = enemyID;
        this.hp = hp;
    }

    private void FixedUpdate()
    {
        var pos = transform.position;                                   // pos = enemy ������

        Debug.DrawRay(pos, directions[count], new Color(1, 0, 0));      // ray�׸��� ( pos���� directions[]�������� & ����

        var hit = Physics2D.Raycast(pos, directions[count], distance, LayerMask.GetMask("Wall"));

        if (hit.collider != null)
            count++;
    }

    void Update()   // enemy �̵� directions[] ���Ⱚ���� 
    {
        transform.Translate(directions[count] * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col)            // trigger ����
    {
        if (col.tag == "Hole")                              // �浹�Ѱ� Hole�̸�
        {
            Destroy(this.gameObject);                       // enemy �ı�
            life--;                                         // ���� -1
            SpawnManager.instance.LifeDown();               // spawnmanager���� �����ϴ� lifedown�Լ� �̱��� �ҷ�����
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
        hp_text.text = hp.ToString();

        GameObject dmgText = Instantiate(dmgTextPrefab);
        dmgText.GetComponent<DamageText>().damage = damage;
        dmgText.transform.position = dmgPos.position;

        if (hp<= 0)
        {
            Destroy(this.gameObject);
            if(SpawnManager.instance.enemyCount-1 == enemyID)
            {
                SpawnManager.instance.isClear = true;
            }
            //����
        }
    }

}
