using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;

//데미지 표시는 여기서
public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float distance;

    [SerializeField] private TMP_Text hp_text;
    int hp = 0;

    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;
    //private RaycastHit2D hit;

    private Vector3[] directions = new Vector3[3];
    private int count = 0;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        directions[0] = transform.up;
        directions[1] = transform.right;
        directions[2] = transform.up * -1;
    }

    public void Init(int hp)
    {
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
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
        hp_text.text = hp.ToString();

        if (hp<= 0)
        {
            Destroy(this.gameObject);
            //죽음
        }
    }

}
