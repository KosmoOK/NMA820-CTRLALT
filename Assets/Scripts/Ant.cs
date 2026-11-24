using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Ant : MonoBehaviour
{
    public int row = 0;
    public float stopPositionX = -5.25f;
    public float multiplier = 1f;
    public Vector2 moveRandomness = new Vector2(0.5f, 1.5f);
    public AnimationCurve squishCurve = AnimationCurve.Linear(0, 1, 1, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > stopPositionX)
        {
            transform.position += Vector3.left * Time.deltaTime * multiplier;
        }
    }

    public void Squish()
    {
        StartCoroutine(SquishCoroutine());
    }
    private IEnumerator SquishCoroutine()
    {
        multiplier = 0f; // STAP MOVING!!

        float duration = squishCurve.keys[squishCurve.length - 1].time;
        Vector3 originalScale = transform.localScale;

        for(float i = 0; i < duration; i += Time.deltaTime)
        {
            Debug.Log(squishCurve.Evaluate(i));
            transform.localScale = new Vector3(originalScale.x / squishCurve.Evaluate(i), originalScale.y * squishCurve.Evaluate(i), 1);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1f);
        
        Destroy(gameObject);
    }
}