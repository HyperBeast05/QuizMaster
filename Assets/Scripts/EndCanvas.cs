using UnityEngine;
using TMPro;
public class EndCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _playAgainText;
    ScoreKeeper _scoreKeeper;
    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
    }

    public void ShowFinalScore()
    {

        _playAgainText.text = $"Congratulations! \n You got a Final Score of {_scoreKeeper.ScorePercentage}%";
    }
   
    void Update()
    {

    }
}
