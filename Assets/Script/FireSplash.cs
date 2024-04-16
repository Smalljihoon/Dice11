using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpl : MonoBehaviour
{
    public List<Enemy> list = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (collision.tag == "Enemy")
        {
            list.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (collision.tag == "Enemy")
        {
            list.Add(enemy);
        }
    }
}
