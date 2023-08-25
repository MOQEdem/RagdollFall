using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyPartCostBook", menuName = "ScriptableObjects/BodyPartCostBook")]
public class BodyPartCostBook : ScriptableObject
{
    [SerializeField] private BodyPartCost[] _costs;

    public int GetBodyPartCost(CharacterBodyPart part)
    {
        foreach (BodyPartCost cost in _costs)
            if (part.Type == cost.Type)
                return cost.Cost;

        return 0;
    }
}

[Serializable]
public class BodyPartCost
{
    [SerializeField] private BodyPartType _type;
    [SerializeField] private int _cost;

    public BodyPartType Type => _type;
    public int Cost => _cost;
}
