using UnityEngine;

public class Jelly : MonoBehaviour
{
    float currentTime = 0;
    float speedX;
    float speedY;
    bool isWalking = false;
    bool isLineOut = false;
    public int id;
    public int level;
    public float exp = 0;

    public Transform topLeft;
    public Transform bottomRight;
    public Vector3[] pointList;
    Vector3 nextPoint;
    Vector3 moveDir;

    Animator anim;
    SpriteRenderer spriter;
    Collider2D collJelly;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        collJelly = GetComponent<Collider2D>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (!isWalking && currentTime >= Random.Range(1.9f, 4.9f)) {
            StartWalking();
        }
        else if (isWalking && currentTime >= Random.Range(2.9f, 4.9f)) {
            StopWalking();
        }

        CheckLineOut();
        FlipJelly();
        AutoGetExp();
        levelUp();
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

    void OnMouseDown()
    {
        anim.SetTrigger("doTouch");
        GetJelatine();
        StopWalking();
    }

    void GetJelatine()
    {
        GameManager.instance.jelatine += (id + 1) * level;
        Mathf.Min(GameManager.instance.jelatine, 999999999);

        if (level < 3) {
            exp++;
        }
    }

    void AutoGetExp()
    {
        if (level < 3) {
            exp += 1 * Time.deltaTime;
        }
    }

    void levelUp()
    {
        int maxExp = level * 50;

        if (exp >= maxExp) {
            level++;
            GameManager.instance.ChangeAc(anim, level);
        }
    }
}
