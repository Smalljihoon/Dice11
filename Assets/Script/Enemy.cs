using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    //[SerializeField] Transform enemyTransform;
    [SerializeField] float speed;
    //[SerializeField] bool isTurn;
    [SerializeField] float distance;

    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;
    //private RaycastHit2D hit;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var pos = enemy.transform.position;

        Debug.DrawRay(pos, enemy.transform.up, new Color(1, 0, 0));

        var hit = Physics2D.Raycast(pos, Vector2.up, distance, LayerMask.GetMask("Wall"));

        if (hit.collider != null)
        {
            float rotationZ = enemy.transform.localEulerAngles.z + -90f;
            //Debug.Log(hit.collider.name);
            enemy.transform.localEulerAngles = new Vector3(0, 0, -90);
            Debug.Log(rotationZ);
            
            //Debug.Log(enemy.transform.rotation.eulerAngles);
        }

    }

    void Update()
    {

        enemy.transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    //private void OnCollisionEnter2D(Collision2D collision)

    //{

    //    if (collision.gameObject.tag == "Wall")

    //    {

    //    }

    //}
}
