using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Button inventorybt;
    [SerializeField] Button battlebt;
    [SerializeField] Button exitbt;
    [SerializeField] GameObject invenpanel;

    private void Start()
    {
        inventorybt.onClick.AddListener(Inven);
    }

    public void Update()
    {

    }

    public void Inven()
    {
        invenpanel.SetActive(true);

    }


}
