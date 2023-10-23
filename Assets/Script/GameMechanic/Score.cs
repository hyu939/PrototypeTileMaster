using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiScore;
    [SerializeField] private TextMeshProUGUI uiCombo;
    private int score = 0;
    private int combo = 1;

    private float doublePointsDuration = 7f;
    private float doublePointsTimer = 0f;
    private bool isDoublePointsActive = false;

    private void Update()
    {
        if (isDoublePointsActive)
        {
            doublePointsTimer -= Time.deltaTime;

            if (doublePointsTimer <= 0f)
            {
                combo = 0;
                isDoublePointsActive = false;
                uiCombo.text = "";
            }
        }
    }
    public void ScorePlus()
    {
        IncreaseScore();
        ActivateDoublePoints();
        uiScore.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;

        if (isDoublePointsActive)
        {
            score = score + combo;
        }
    }

    public void ActivateDoublePoints()
    {
        combo++;
        isDoublePointsActive = true;
        doublePointsTimer = doublePointsDuration;
        uiCombo.text = "X"+ combo.ToString();
    }
}
