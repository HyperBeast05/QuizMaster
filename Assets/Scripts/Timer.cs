using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Image _timeImage;
    public  float _imageTimer = 0f;
    public  float _maxTime;
    private Quiz _quiz;

   
    private void Awake()
    {
        _quiz = FindObjectOfType<Quiz>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _imageTimer = Mathf.Max(_imageTimer -= Time.deltaTime, 0);

        _timeImage.fillAmount = _imageTimer / _maxTime;
        if (_imageTimer <= 0)
        {
            _quiz.NextQuestion();
        }
    }
}
