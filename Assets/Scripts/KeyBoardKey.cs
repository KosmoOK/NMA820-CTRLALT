using UnityEngine;
using UnityEngine.InputSystem;

public class KeyBoardKey : MonoBehaviour
{
    public KeyCode key;
    public int row;
    public GameMaster gm; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && !gm.finger.isSquishing)
        {
            StartCoroutine(gm.finger.SquishCoroutine(transform.position, row));
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
