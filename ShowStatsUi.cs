using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowStatsUi : MonoBehaviour
{
    [SerializeField] private GameObject[] panelsHp;
    [SerializeField] private GameObject target;
    private float hp;
    private float maxHp;
    void Update()
    {
        maxHp = target.GetComponent<Stats>().maxHp;
        hp = target.GetComponent<Stats>().hp;
        for (int i=0; i < panelsHp.Length; i++)
        {
            panelsHp[i].GetComponent<Image>().fillAmount = hp/maxHp;
        }
    }
}
