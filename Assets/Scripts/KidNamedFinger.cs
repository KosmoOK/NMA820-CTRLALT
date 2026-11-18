using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CircleCollider2D))]
public class KidNamedFinger : MonoBehaviour
{
    [SerializeField] private GameMaster gameMaster;
    public bool isSquishing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.anyKey.wasPressedThisFrame)
        {
            isSquishing = true;
        }
        else
        {
            isSquishing = false;
        }

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
        Debug.Log("Beeboop!");
        if(collision.gameObject.TryGetComponent<Ant>(out Ant ant) && ant.transform.position.y < transform.position.y)
        {
            ant.Squish();
        }
    }

}
