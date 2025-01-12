using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Scroll();
        Reposition();
    }

    void Scroll()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Reposition()
    {
        if (transform.position.x > 8) {
            transform.Translate(Vector2.left * 16f);
        }
    }
}
