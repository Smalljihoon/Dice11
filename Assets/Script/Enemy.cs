using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//������ ǥ�ô� ���⼭
public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;                           // �� �̵��ӵ�
    [SerializeField] float distance;                        // ray �Ÿ�
    [SerializeField] TMP_Text hp_text;              // �� ü��
    
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

    public void Init(int hp, int enemyID)        // hp �ʱ�ȭ �Լ�
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
            //Debug.Log("�浹");
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
            //����
        }
    }

}
