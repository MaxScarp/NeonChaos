using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float launchX = 1.0f;
    [SerializeField] float launchY = 15.0f;
    [SerializeField] AudioClip[] soundtracks;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBallVector;
    bool hasStarted = false; //Segnala quando la palla è stata lanciata
    bool musicHasStarted = false; //Segnala quando la musica è partita

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2d;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        if(hasStarted && !musicHasStarted)
        {
            PlayMusic();
        }

        GetComponent<SpriteRenderer>().color = paddle.GetComponent<SpriteRenderer>().color;
    }

    /// <summary>
    /// Fa partire la musica del gioco quando la pallina viene lanciata.
    /// </summary>
    private void PlayMusic()
    {
        AudioClip clip = soundtracks[UnityEngine.Random.Range(0, soundtracks.Length)];
        myAudioSource.PlayOneShot(clip);
        musicHasStarted = true;
    }

    /// <summary>
    /// Lancia la palla quando viene premuto il tasto sinistro del mouse.
    /// </summary>
    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidBody2d.velocity = new Vector2(launchX, launchY);
            hasStarted = true;
        }
    }

    /// <summary>
    /// Tiene agganciata la palla sopra al centro del paddle.
    /// </summary>
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        myRigidBody2d.velocity += velocityTweak;
    }
}
