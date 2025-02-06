using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public TextMeshProUGUI ScoreBoard;
    public GameObject winText;
    public GameObject PowerUp;
    public float PowerUpSpawn = 10f;
    public Transform PowerUpSpawnPoint;
    
   

    int leftPlayerScore;
    int rightPlayerScore;
    Vector3 ballStartPos;

    const int scoreToWin = 11;

    //---------------------------------------------------------------------------
    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.linearVelocity = new Vector3(1f, 0f, 0f) * startSpeed;
        winText.SetActive(false);
        InvokeRepeating("SpawnPowerUp", PowerUpSpawn, PowerUpSpawn);
    }

    //---------------------------------------------------------------------------
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        // If the ball entered a goal area, increment the score, check for win, and reset the ball

        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            Debug.Log($"Right player scored: {rightPlayerScore}");

            if (rightPlayerScore >= scoreToWin)
                // Debug.Log("Right player wins!");
                DisplayWinner("Right Player Wins");
              
                
            else
                ResetBall(-1f);
               
                
        }
        else if (trigger == rightGoalTrigger)
        {
            leftPlayerScore++;
            Debug.Log($"Left player scored: {leftPlayerScore}");

            if (rightPlayerScore >= scoreToWin)
                // Debug.Log("Right player wins!");
                DisplayWinner("Left Player Wins");
            else
                ResetBall(1f);
                
                
        }
        UpdateScoreBoard(); 
        UpdateScoreBoardColor();
    }

    //---------------------------------------------------------------------------
    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.linearVelocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }
  void UpdateScoreBoard(){
    // ScoreBoard.text = $"Left Player: {leftPlayerScore} - Right Player: {rightPlayerScore}";
     ScoreBoard.text =  leftPlayerScore.ToString() + "-" + rightPlayerScore.ToString();
  }

  void UpdateScoreBoardColor(){
    Color randomColor = Random.ColorHSV();

    ScoreBoard.color = randomColor;
  }
  void DisplayWinner(string playerName){
    
    winText.SetActive(true);
    TextMeshProUGUI WinText = winText.GetComponent<TextMeshProUGUI>();
    WinText.text = playerName.ToString() + " Wins!";

  }
  void SpawnPowerUp(){
    Instantiate(PowerUp, PowerUpSpawnPoint.position, Quaternion.identity);

  }
}
