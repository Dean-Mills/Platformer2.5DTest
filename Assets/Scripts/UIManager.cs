using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _collectableCount;
    private string _collectableCountDefualt = "Coins: ";
    [SerializeField]
    private Text _livesCount;
    private string _livesCountDefualt = "Lives: ";
    public void UpdateCollectableCount(int num)
    {
        _collectableCount.text = _collectableCountDefualt + num.ToString();
    }

    public void UpdateLives(int num)
    {
        _livesCount.text = _livesCountDefualt + num.ToString();
    }
}
