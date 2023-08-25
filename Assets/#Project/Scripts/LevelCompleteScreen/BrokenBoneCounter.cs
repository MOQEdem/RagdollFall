using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrokenBoneCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _headCounter;
    [SerializeField] private TMP_Text _chestCounter;
    [SerializeField] private TMP_Text _pelvisCounter;
    [SerializeField] private TMP_Text _armsCounter;
    [SerializeField] private TMP_Text _legsCounter;

    private const string prefix = "x";

    public void SetCounterValues(List<BodyPartType> brokenTypes)
    {
        int headCount = 0;
        int chestCount = 0;
        int pelvisCount = 0;
        int armsCount = 0;
        int legsCount = 0;

        foreach (BodyPartType type in brokenTypes)
        {
            if (type == BodyPartType.Head)
                headCount++;

            if (type == BodyPartType.Chest)
                chestCount++;

            if (type == BodyPartType.Pelvis)
                pelvisCount++;

            if (type == BodyPartType.LeftHand ||
                type == BodyPartType.RightHand ||
                type == BodyPartType.LeftShoulder ||
                type == BodyPartType.RightShoulder)
                armsCount++;

            if (type == BodyPartType.LeftFoot ||
                type == BodyPartType.RightFoot ||
                type == BodyPartType.LeftThigh ||
                type == BodyPartType.RightThigh)
                legsCount++;
        }

        armsCount = Mathf.Clamp(armsCount, 0, 2);
        legsCount = Mathf.Clamp(legsCount, 0, 2);

        _headCounter.text = prefix + headCount.ToString();
        _chestCounter.text = prefix + chestCount.ToString();
        _pelvisCounter.text = prefix + pelvisCount.ToString();
        _armsCounter.text = prefix + armsCount.ToString();
        _legsCounter.text = prefix + legsCount.ToString();

    }
}
