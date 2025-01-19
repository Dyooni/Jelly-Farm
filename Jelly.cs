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
    public float pickTime = 0;

    Vector3 nextPoint;
    Vector3 moveDir;

    public Animator anim;
    public SpriteRenderer spriter;
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

        for (int i = 0; i < GameManager.instance.jellyLevel.Count; i++) {

            int n = GameManager.instance.jellyName.IndexOf(int.Parse(this.gameObject.name));
            GameManager.instance.jellyLevel[n] = level;
            GameManager.instance.jellyExp[n] = Mathf.RoundToInt(exp);
        }

        CheckLineOut();
        FlipJelly();
        AutoGetExp();
        levelUp();

        // StartCoroutine(AutoMoney());
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

    void LastUpdate()
    {
        if (GameManager.instance.jellyList.Count > 0) {
            int n = GameManager.instance.jellyName.IndexOf(int.Parse(this.gameObject.name));
            GameManager.instance.jellyLevel.Insert(n, level);
        }
    }

    void CheckLineOut()
    {
        if (transform.position.x < GameManager.instance.topLeft.position.x ||
            transform.position.x > GameManager.instance.bottomRight.position.x ||
            transform.position.y > GameManager.instance.topLeft.position.y ||
            transform.position.y < GameManager.instance.bottomRight.position.y) {
                isLineOut = true;
            }
    }

    void StartWalking()
    {
        anim.SetBool("isWalk", true);        
        speedX = Random.Range(-0.8f, 0.8f);
        speedY = Random.Range(-0.8f, 0.8f);
        nextPoint = GameManager.instance.pointList[Random.Range(0, GameManager.instance.pointList.Length)];

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

    void Pick()
    {
        transform.position = GameManager.instance.clickSreen.GetMousePoint();
    }

    void GetJelatine()
    {
        GameManager.instance.soundManager.PlaySfx(8);

        GameManager.instance.saveData.jelatine += (id + 1) * level * GameManager.instance.saveData.clickLevel;
        Mathf.Min(GameManager.instance.saveData.jelatine, 99999999);

        if (level < 3) {
            exp++;
        }
    }

    void AutoGetExp()
    {
        if (level < 3) {
            exp += 1 * Time.deltaTime;
        }

        GameManager.instance.saveData.jelatine += (id + 1) * 0.5f * Time.deltaTime;
    }

    void levelUp()
    {
        int maxExp = level * 50;

        if (exp >= maxExp) {
            level++;
            GameManager.instance.ChangeAc(anim, level);
            GameManager.instance.soundManager.PlaySfx(4);
        }
    }

    void OnMouseDown()
    {
        if (GameManager.instance.jellyGroup.isLive) {
            anim.SetTrigger("doTouch");
            GetJelatine();
            StopWalking();
            pickTime = 0;
        }
    }

    void OnMouseDrag()
    {
        if (GameManager.instance.jellyGroup.isLive) {
            pickTime += Time.deltaTime;

            if (pickTime > 0.5f) {
                Pick();
            }
        }
    }
    
    void OnMouseUp()
    {
        if (GameManager.instance.btnSell.isSell) {
            // GameManager.instance.btnSell.GetGold();
            Destroy(gameObject);
            GameManager.instance.soundManager.PlaySfx(7);
        }
        if (isLineOut) {
            transform.position = nextPoint;
        }
    }

    void OnDestroy()
    {
        GameManager.instance.saveData.gold += GameManager.instance.jellyGoldList[id] * level;
        Mathf.Min(GameManager.instance.saveData.gold, 99999999);

        // GameManager.instance.jellyList[int.Parse(this.gameObject.name)] = null;
        // GameManager.instance.jellyId[int.Parse(this.gameObject.name)] = 0;
        // GameManager.instance.jellyLevel[int.Parse(this.gameObject.name)] = 0;
        // GameManager.instance.jellyExp[int.Parse(this.gameObject.name)] = 0;
        
        int n = GameManager.instance.jellyName.IndexOf(int.Parse(this.gameObject.name));

        GameManager.instance.jellyList.RemoveAt(n);
        GameManager.instance.jellyId.RemoveAt(n);
        GameManager.instance.jellyLevel.RemoveAt(n);
        GameManager.instance.jellyExp.RemoveAt(n);
        GameManager.instance.jellyName.RemoveAt(n);
    }

    // IEnumerator AutoMoney()
    // {
    //     while(true) {
    //         foreach (var jelly in GameManager.instance.jellyList) {
    //             GetJelatine();
    //         }
    //         yield return new WaitForSeconds(3);
    //     }
    // }
}
