using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static Score _instance;
    public Text scoreText;
    private int score;
    private int completed = 0;

    public Animator animationUponGoal;

    public static Score Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    // Increment the score counter by the passed in amount
    public void IncreaseScore(int amount)
	{
        score += amount;
        scoreText.text = score.ToString();

        //animationUponGoal.SetInteger("requiredScore", score);
    }

    public void MarkComplete()
	{
        completed++;
        animationUponGoal.SetInteger("completedGames", completed);
	}
}