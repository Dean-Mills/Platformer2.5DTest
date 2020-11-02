using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _collectableCount;
    private string _collectableCountDefualt = "Coins: ";
    public void UpdateCollectableCount(int num)
    {
        _collectableCount.text = _collectableCountDefualt + num.ToString();
    }
}
