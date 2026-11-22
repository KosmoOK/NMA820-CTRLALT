using UnityEngine;
using UnityEngine.InputSystem;

public class KeyBoardKey : MonoBehaviour
{
    public KeyCode key;
    public GameMaster gm; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && gm.finger.isSquishing)
        {
            gm.finger.transform.position = transform.position;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
