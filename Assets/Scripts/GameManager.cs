using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Quiz _quiz;
    [SerializeField] EndCanvas _endCanvas;
    Timer _timer;

    private void Awake()
    {
        _timer = FindObjectOfType<Timer>();
    }


    void Start()
    {
        _quiz.gameObject.SetActive(true);
        _endCanvas.gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowEndCanvas()
    {
    }
    void Update()
    {
        if (_quiz.IsQuizComplete && _quiz.CanShowEndCanvas)
        {
            _quiz.gameObject.SetActive(false);
            _endCanvas.gameObject.SetActive(true);
            _endCanvas.ShowFinalScore(); 
        }
    }



}
