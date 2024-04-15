using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float movePosition;          // �ؽ�Ʈ �̵�����
    public float alphaSpeed;             // ���� ��ȯ�ӵ�
    public float destroyTime;
    TextMeshPro text;
    Color alpha;
    public int damage;

    float time = 0;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        alpha = text.color;
        Invoke("DestroyObject", destroyTime);
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.localPosition = new Vector3(0, Mathf.Lerp(0, movePosition, time), 0);
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
