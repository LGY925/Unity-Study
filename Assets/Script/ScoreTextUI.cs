using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
    [SerializeField] TMP_Text textUI;

    private void OnEnable()
    {
        SetScore(Manager.Game.Score);
        Manager.Game.OnScoreChange += SetScore;
    }
    private void OnDisable()
    {
        Manager.Game.OnScoreChange -= SetScore;
    }
    private void SetScore(int score)
    {
        textUI.text = score.ToString();
    }
}
