using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Quiz : MonoBehaviour
{
    [SerializeField] List<QuizDetails> _quizDetails;
    [SerializeField] TextMeshProUGUI _questionText;

    [SerializeField] private Sprite _defaultSprite, _correctAnswerSprite;
    [SerializeField] private Slider _progressBar;
    Timer _timer;
    ScoreKeeper _scoreKeeper;

    int num = 0;
    int answerIndex = 0;
    int randomQuestion;

    public int Num { get => num;set => num = value; }
    public  bool IsQuizComplete { get; set; } = false;
    public bool CanShowEndCanvas { get; set; } = false;

    private void Awake()
    {
        _timer = FindObjectOfType<Timer>(); 
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {
        _progressBar.maxValue = _quizDetails.Count;
        _progressBar.value = 0;
        ShowQuizQuestion(Num);
    }

    private void Update()
    {

    }

    private void ShowQuizQuestion(int Num)
    {
        if (Num < _quizDetails.Count)
        {
            _questionText.text = (Num + 1) + ". " + _quizDetails[Num]._questionSO.Question;

            for (int j = 0; j < _quizDetails[Num]._answers.Length; j++)
            {
                TextMeshProUGUI answer = _quizDetails[Num]._answers[j].GetComponentInChildren<TextMeshProUGUI>();
                answer.text = _quizDetails[Num]._questionSO.Answers[j];
            }
        }
        _progressBar.value ++;
        _scoreKeeper.GetQuestionSeen();
    }

    public void NextQuestion()
    {      
        _timer._timeImage.fillAmount = 1f;
        _timer._imageTimer = _timer._maxTime = 10f;
        for (int i = 0; i < _quizDetails[Num]._answers.Length; i++)
            _quizDetails[Num]._answers[i].image.sprite = _defaultSprite;

        ButtonState(true);

        Num++;
        if (Num >= _quizDetails.Count)
        {
            CanShowEndCanvas = true;
            Num = 0;
        }
        ShowQuizQuestion(Num);
        if (_progressBar.value == _progressBar.maxValue) IsQuizComplete = true;

    }
    public void OnAnswerSelected(int index)
    {
       
        _timer._timeImage.fillAmount = 1f;        
        _timer._imageTimer = _timer._maxTime = 3f;

        answerIndex = index;
        if (answerIndex == _quizDetails[Num]._questionSO.CorrectAnswerIndex)
        {
            _scoreKeeper.GetCorrectAnswer();
            _questionText.text = $"Correct Answer!";
            Image buttonImage = _quizDetails[Num]._answers[answerIndex].GetComponent<Image>();
            buttonImage.sprite = _correctAnswerSprite;
            ButtonState(false);
            
        }
        else
        {
            int correctAnswer = _quizDetails[Num]._questionSO.CorrectAnswerIndex;
            TextMeshProUGUI correctAnswerText = _quizDetails[Num]._answers[correctAnswer].GetComponentInChildren<TextMeshProUGUI>();
            _questionText.text = $"Sorry! Correct Answer is \n {correctAnswerText.text}";
            Image buttonImage = _quizDetails[Num]._answers[correctAnswer].GetComponent<Image>();
            buttonImage.sprite = _correctAnswerSprite;
            ButtonState(false);
        }
        _scoreKeeper.CaluclateScore();
       
    }
    private void ButtonState(bool state)
    {
        for (int i = 0; i < _quizDetails[Num]._answers.Length; i++)
        {
            _quizDetails[Num]._answers[i].interactable = state;
        }
    }
}

[System.Serializable]
public struct QuizDetails
{
    public QuestionsSO _questionSO;
    public Button[] _answers;
}