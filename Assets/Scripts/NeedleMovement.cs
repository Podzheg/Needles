using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject needleBody;

    private bool canFire;
    public bool touchedTheCircle;
    [SerializeField]
    private Rigidbody2D myBody;
    // Start is called before the first frame update
    private CircleRotation gameCircle;
    [SerializeField]
    private SOGameStats stats;
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        needleBody.SetActive(false);
        myBody = GetComponent<Rigidbody2D>();
        gameCircle = GameObject.FindObjectOfType<CircleRotation>();
    }

    private void Update()
    {
        if (canFire)
        {
            myBody.velocity = new Vector2(0, stats.needleLaunchPower);
        }
    }

    public void FireTheNeedle()
    {
        needleBody.SetActive(true);
        myBody.isKinematic = false;
        canFire = true;
    }

    public void GotToCircle()
    {
        canFire = false;
        touchedTheCircle = true;
        myBody.isKinematic = true;
        myBody.velocity = new Vector2(0, 0);
        gameObject.transform.SetParent(gameCircle.gameObject.transform);

        if (ScoreRuler.instance != null)
        {
            ScoreRuler.instance.SetScore();
        }

        switch (ScoreRuler.instance.score)
        {
            case 5:
            case 10:
            case 15:
            case 22:
            case 23:
                gameCircle.rotationSpeed = -gameCircle.rotationSpeed;
                break;
            case 7:
            case 12:
            case 21:
                gameCircle.rotationSpeed = gameCircle.rotationSpeed * 1.25f;
                break;
            case 16:
            case 18:
            case 20:
                gameCircle.rotationSpeed = stats.circleRotationSpeed;
                break;
            case 17:
            case 19:
                gameCircle.rotationSpeed = - stats.circleRotationSpeed * 1.5f;
                break;
        }
    }

    public void GotToLoosePoint()
    {
        GameRuler.instance.EndGame();
    }
}
