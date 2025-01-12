using Unity.VisualScripting;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    float currentTime = 0;
    public float speedX;
    public float speedY;
    bool isWalking = false;
    public bool isLineOut = false;

    public Transform topLeft;
    public Transform bottomRight;
    public Vector3[] pointList;
    Vector3 nextPoint;
    public Vector3 moveDir;

    Animator anim;
    SpriteRenderer spriter;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (!isWalking && currentTime >= Random.Range(2, 5)) {
            StartWalking();
        }
        else if (isWalking && currentTime >= Random.Range(2, 5)) {
            StopWalking();
        }

        CheckLineOut();
        FlipJelly();
    }

    void FixedUpdate()
    {
        if (isWalking) {
            if (isLineOut) {
                moveDir = (nextPoint - transform.position).normalized;
            }
            else {
                moveDir = new Vector3(speedX, speedY, speedY);
            }

            transform.Translate(moveDir * Time.fixedDeltaTime);
        }    
    }

    void CheckLineOut()
    {
        if (transform.position.x < topLeft.position.x ||
            transform.position.x > bottomRight.position.x ||
            transform.position.y > topLeft.position.y ||
            transform.position.y < bottomRight.position.y) {
                isLineOut = true;
            }
    }

    void StartWalking()
    {
        anim.SetBool("isWalk", true);        
        speedX = Random.Range(-0.8f, 0.8f);
        speedY = Random.Range(-0.8f, 0.8f);
        nextPoint = pointList[Random.Range(0, pointList.Length)];

        isWalking = true;
        currentTime = 0;
    }

    void StopWalking()
    {
        anim.SetBool("isWalk", false);
        isWalking = false;
        isLineOut = false;
        currentTime = 0;
    }

    void FlipJelly()
    {
        if (!isLineOut) {
            spriter.flipX = speedX < 0;
        }
        else if (isLineOut) {
            spriter.flipX = nextPoint.x - transform.position.x < 0;
        }
    }
}
