using UnityEngine;

[CreateAssetMenu(menuName ="Questions",fileName ="New Question")]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] private string question;
    [SerializeField] private string[] _answers;
    [SerializeField] private int _correctAnswerIndex;

    public string Question
    {
        get => question;
        private set => question = value;
    }

    public string[] Answers
    {
        get => _answers;
        private set => _answers = value;
    }

    public int CorrectAnswerIndex { get => _correctAnswerIndex;private set=> _correctAnswerIndex = value; }
}
