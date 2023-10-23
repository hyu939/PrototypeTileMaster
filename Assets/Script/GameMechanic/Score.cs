using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiScore;
    [SerializeField] private TextMeshProUGUI uiCombo;
    private int score = 0;
    private int combo = 1;

    private float doublePointsDuration = 5f;
    private float doublePointsTimer = 0f;
    private bool isDoublePointsActive = false;

    private void Update()
    {
        if (isDoublePointsActive)
        {
            doublePointsTimer -= Time.deltaTime;

            if (doublePointsTimer <= 0f)
            {
                combo = 1;
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
        

        if (isDoublePointsActive)
        {
            score = score + combo;
        }
        else
            score++;
    }

    public void ActivateDoublePoints()
    {
        combo++;
        isDoublePointsActive = true;
        doublePointsTimer = doublePointsDuration;
        uiCombo.text = "X"+ combo.ToString();
    }
}
