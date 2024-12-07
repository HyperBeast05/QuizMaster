using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int CorrectAnswer { get; set; } = 0;
    public int QuestionSeen { get; set; } = 0;
    public TextMeshProUGUI ScoreKeeperText { get => _scoreKeeperText; set => _scoreKeeperText = value; }

    public int ScorePercentage { get; set; }

    [SerializeField] TextMeshProUGUI _scoreKeeperText;


    public void GetCorrectAnswer()
    {
        CorrectAnswer++;
    }
    public void GetQuestionSeen()
    {
        QuestionSeen++;
    }

    private void Update()
    {
       
    }

    public int  Score()
    {
        return Mathf.RoundToInt(CorrectAnswer / (float)QuestionSeen * 100);

    }
    public void CaluclateScore()
    {
        ScorePercentage = Mathf.RoundToInt(CorrectAnswer / (float)QuestionSeen * 100);
        _scoreKeeperText.text = $"Score: {ScorePercentage}%";
    }
  
}
