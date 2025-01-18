using UnityEngine;

public class JellyShadow : MonoBehaviour
{
    float shadowY;

    Vector3 vec;

    public Jelly jelly;

    void Awake()
    {
        jelly = GetComponentInParent<Jelly>();
    }

    void Start()
    {
        switch (jelly.id) {
            case 0:
                shadowY = -0.05f;
                break;
            case 6:
                shadowY = -0.12f;
                break;
            case 3:
                shadowY = -0.14f;
                break;
            case 10:
            case 11:
                shadowY = -0.16f;
                break;
            default:
                shadowY = -0.1f;
                break;
        }

        vec = new Vector3(0, shadowY, 0);
        transform.localPosition = vec;
    }
}
