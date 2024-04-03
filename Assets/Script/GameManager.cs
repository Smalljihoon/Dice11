using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // instance��� ������ static���� ������ �Ͽ� �ٸ� ������Ʈ ���� ��ũ��Ʈ������ instance�� �ҷ��� �� �ְ� �մϴ� 
    public static GameManager instance = null;                          // ���ӸŴ��� �̱���
    
    public int score { get; set; }
    public int sp { get; set; }

    private void Awake()
    {
        if (instance == null)                                           // instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this;                                            // ���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject);                              // OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else                                                            // 
        {
            if (instance != this)                                       // instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject);                               // �� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    public void Init()
    {
        score = 0;
        sp = 0;
    }
    private void Update()
    {
        
    }
}
