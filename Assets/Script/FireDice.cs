using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDice : Dice
{
    protected override void Start()
    {
        base.Start();

        category = Dice_category.Fire;
    }
    //public override void Skill()
    //{

    //}

    //protected override IEnumerator Shot()
    //{
    //    while (true)
    //    {
    //        List<GameObject> list = new List<GameObject>();

    //        foreach (var bullet in bullets)
    //        {
    //            if (!bullet.gameObject.activeSelf)
    //            {
    //                list.Add(bullet.gameObject);
    //            }
    //        }
    //        yield return null;

    //        if (list.Count == bullets.Count)
    //        {
    //            break;
    //        }
    //    }

    //    float delay = 0.8f / eyes;

    //    foreach (var bullet in bullets)
    //    {
    //        if (SpawnManager.instance.currentTarget == null)
    //            continue;

    //        bullet.gameObject.SetActive(true);

    //        bullet.transform.localPosition = Vector3.zero;

    //        bullet.Init(damage, SpawnManager.instance.currentTarget.transform);

    //        yield return new WaitForSeconds(delay);
    //    }
    //}
}
