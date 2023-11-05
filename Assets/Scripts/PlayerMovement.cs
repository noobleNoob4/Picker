using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CalculateBallAmount currentballNumber;
    [SerializeField] private PlatformTypes scriptableObject1;
    [SerializeField] private PlatformTypes scriptableObject2;
    [SerializeField] private PlatformTypes scriptableObject3;
    #region Self Variables
    public bool _isReadyToMove;
    private bool speedBoost_;
    public static bool isGameStarted;
    public  static float xRange;





    #endregion
    #region Serialized Variables

    [SerializeField] private GameObject tapTapPanel;
    [SerializeField] public float speed = 10;
    [SerializeField] private float leftRightSpeed = 4;
    [SerializeField] public int maxSpeed = 100;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] public GameObject tapToPlayText;


    #endregion

    #region GameOverandWin
    [SerializeField] public GameObject gameOverpanel;

    #endregion

    private void Start()
    {
        tapTapPanel.SetActive(false);
        Time.timeScale = 1;
        gameOverpanel.SetActive(false);
        speedBoost_ = false;
        _isReadyToMove = true;
        isGameStarted = false;
        
    }


    void FixedUpdate()
    {
        
        PlayerMove();
        StartCoroutine(SpeedBoost());
        if(SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(tapToPlayText);
        }
        if(!isGameStarted)
        {
            return;
        }
    }
    private void PlayerMove()
    {
        if (!isGameStarted)
        {
            return;
        }
        _isReadyToMove = true;
        xRange = 4.7f;
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        rigidbody.velocity = new Vector3(_joystick.Horizontal * leftRightSpeed, rigidbody.velocity.y,speed);
      
     }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("stop1"))
        {
            Debug.Log("Countdown started");
            Invoke("GameOverCountDown", 4f);
            StartCoroutine(DelayforPlayerMovement());
        }
        if (other.CompareTag("stop2"))
        {
            Debug.Log("Countdown started");
            Invoke("GameOverCountDownTwo", 4f);
            StartCoroutine(DelayforPlayerMovement());
        }
        if (other.CompareTag("stop3"))
        {
            Debug.Log("Countdown started");
            Invoke("GameOverCountDownThree", 4f);
            StartCoroutine(DelayforPlayerMovement());
        }
      




    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag ==  "speedBoost")
        {
            speedBoost_ = true;

        }
        if (collision.gameObject.tag == "speedDecreaser")
        {
            

            speed = 5;

        }

    }


    IEnumerator DelayforPlayerMovement() 
    {
        speed = 0;
        yield return new WaitForSeconds(5f);
       _isReadyToMove = true;
       speed = 10;

    }
   
    IEnumerator SpeedBoost()
    {

       if (speedBoost_ == true)
       {
            tapTapPanel.SetActive(true);
            if (SwipeManager.tap)
            {
                yield return new WaitForSeconds(0.3f);

                Debug.Log("SpeedUp");
                speed += 10;
                if (speed >= 100)
                {
                    
                    speed = maxSpeed;
                }



            }
        }



    }
    private void GameOverCountDown()
    {
        if(scriptableObject1.isTrue == false)
        {
            if (currentballNumber.ballNumber < scriptableObject1.howManyBall)
            {
                Time.timeScale = 0;
                gameOverpanel.SetActive(true);
            }
        }
    }
    private void GameOverCountDownTwo()
    {
        if (scriptableObject2.isTrue == false)
        {
            if (currentballNumber.ballNumber < scriptableObject2.howManyBall)
            {
                Time.timeScale = 0;
                gameOverpanel.SetActive(true);
            }
        }
    }
    private void GameOverCountDownThree()
    {
        if (scriptableObject3.isTrue == false)
        {
            if (currentballNumber.ballNumber < scriptableObject3.howManyBall)
            {
                Time.timeScale = 0;
                gameOverpanel.SetActive(true);
            }
        }
    }


}
