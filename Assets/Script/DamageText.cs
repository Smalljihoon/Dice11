using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] float movePosition;          // �ؽ�Ʈ �̵� ��ǥ ��ġ
    [SerializeField] float alphaSpeed;             // ���� ��ȯ�ӵ�
    [SerializeField] float destroyTime;           // �ؽ�Ʈ �ı����� �ɸ��� �ð�

    TextMeshPro text;   // ������ ��ġ
    Color alpha;
    public int damage;          // Enemy���� ���� ������ �޾ƿ�

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
        transform.localPosition = new Vector3(0, Mathf.Lerp(0, movePosition, time), 0); // Lerp ( ó����ġ, ��ǥ��ġ, �ӵ�?)
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
