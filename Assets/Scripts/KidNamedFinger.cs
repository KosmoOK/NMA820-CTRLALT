using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CircleCollider2D))]
public class KidNamedFinger : MonoBehaviour
{
    [SerializeField] private GameMaster gameMaster;
    public bool isSquishing = false;
    public AnimationCurve squishCurve = AnimationCurve.Linear(0,1,1,1);
    public float squishSpeedMult = 1f;
    public float startHeight = 20f;
    private float currentRow = -1;

    private CircleCollider2D collider; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Keyboard.current.anyKey.wasPressedThisFrame)
        // {
        //     isSquishing = true;
        // }
        // else
        // {
        //     isSquishing = false;
        // }

        // for(int x = 0; x < gameMaster.keyRows.Length; x++)
        // {
        //     for(int y = 0; y < gameMaster.keyRows[x].Length; x++)
        //     {
        //         if (Input.GetKeyDown(gameMaster.keyRows[x][y]))
        //         {
        //             transform.position = gameMaster.vectorRows[x][y];
        //         }
        //     }
        // } // What a waste of 3 hours.
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Squish(collision);
    }

    public void Squish(Collision2D collision)
    {
        Debug.Log("Beeboop!");
        if(collision.gameObject.TryGetComponent<Ant>(out Ant ant) && currentRow == ant.row) //&& ant.transform.position.y < transform.position.y NOT USED
        {
            ant.Squish();
        }
    }
    public IEnumerator SquishCoroutine(Vector3 targetLocation, int row)
    {
        if (!isSquishing)
        {
            currentRow = row;

            // Add starting height position and turn off collider
            collider.enabled = false;
            isSquishing = true;
            Debug.Log(transform.position.y + startHeight);
            transform.position = new(transform.position.x, transform.position.y + startHeight, transform.position.z);

            // Move Downwards
            for(float i = transform.position.y; i < targetLocation.y; i -= squishSpeedMult * Time.deltaTime)
            {
                // Use similar curve evaluation to SquishCoroutine
                transform.position = new(transform.position.x, i, transform.position.z);
                yield return new WaitForEndOfFrame();
            }

            // Turn on collider
            collider.enabled = true;
            transform.position = targetLocation;
            yield return new WaitForSeconds(0.5f);

            // Move Upwards
            for(float i = transform.position.y; i > targetLocation.y; i += squishSpeedMult * Time.deltaTime)
            {
                // Use similar curve evaluation to SquishCoroutine
                transform.position = new(transform.position.x, i, transform.position.z);
                yield return new WaitForEndOfFrame();
            }

            collider.enabled = false;
            isSquishing = false;
            currentRow = -1;
        }
    } 

}
