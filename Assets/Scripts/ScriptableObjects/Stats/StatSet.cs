using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "STATSET_newStatSet", menuName = "Stats/STAT SET")]
public class StatSet : ScriptableObject
{
    private Dictionary<StatType, Stat> StatsByType;

    [Header("Add/Remove Stats")]
    public List<Stat> Stats = new List<Stat>();

    public void OnEnable()
    {
        StatsByType = new Dictionary<StatType, Stat>();

        foreach (Stat stat in Stats)
        {
            //StatsByType.Add(stat.Type, stat);
        }
    }

    public bool Contains(StatType statType)
    {
        return StatsByType.ContainsKey(statType);
    }

    public Stat Get(StatType statType)
    {
        if (Contains(statType))
            return StatsByType[statType];
        return null;
    }
}
