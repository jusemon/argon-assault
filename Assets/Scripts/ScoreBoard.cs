using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int score;

    private TMP_Text textMesh;

    private void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        textMesh.SetText("00000000");
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        textMesh.SetText(score.ToString("00000000"));
    }
}
