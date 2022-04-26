using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "STATSET_newStatSet", menuName = "Stats/STAT SET")]
public class StatSet : ScriptableObject
{
    //private Dictionary<StatType, Stat> StatsByType;

    [Header("Add/Remove Stats")]
    public List<Stat> Stats = new List<Stat>();

    public void OnEnable()
    {
        //StatsByType = new Dictionary<StatType, Stat>();

        //foreach (Stat stat in Stats)
        //{
        //    //StatsByType.Add(stat.Type, stat);
        //}
    }

    public bool Contains(Stat stat)
    {
        return Stats.Contains(stat);
    }

    public Stat Get(Stat stat)
    {
        if (Contains(stat))
            return stat;
        return null;
    }
}
