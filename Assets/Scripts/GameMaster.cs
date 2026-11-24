using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameMaster : MonoBehaviour
{
    // STILL DONT CARE THIS IS BAD IMPLEMENTATION I HAVE CLASS TOMORROW AND ITS 3:00AM
    public Vector3[] row1;
    public Vector3[] row2;
    public Vector3[] row3;
    public Vector3[] row4;
    public Vector3[] row5;
    public Vector3[][] vectorRows;

    public Ant ant1;

    public KidNamedFinger finger;

    [SerializeField] public KeyCode[][] keyRows; // Damn doesnt serialize gotta jump the faith here (What does that even mean bro)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // I DONT CARE THIS IS A BAD IMPLEMENTATION I JUST WANT THIS FINISHED
        KeyCode[] keyRow1 = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0, KeyCode.Minus, KeyCode.Equals};
        KeyCode[] keyRow2 = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.LeftBracket, KeyCode.RightBracket, KeyCode.Backslash};
        KeyCode[] keyRow3 = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon, KeyCode.Quote, KeyCode.Return};
        KeyCode[] keyRow4 = new KeyCode[] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.Comma, KeyCode.Period, KeyCode.Slash, KeyCode.RightShift};
        KeyCode[] keyRow5 = new KeyCode[] { KeyCode.LeftControl, KeyCode.LeftWindows, KeyCode.LeftAlt, KeyCode.Space, KeyCode.RightAlt, KeyCode.RightWindows, KeyCode.Menu};
        Debug.Log(keyRow1);

        // Ping pong ding dong
        keyRows.Append(keyRow1);
        keyRows.Append(keyRow2);
        keyRows.Append(keyRow3);
        keyRows.Append(keyRow4);
        keyRows.Append(keyRow5);  

        // Ping pong ding dong 2 NVM THIS WAS USELESS OMG
        vectorRows.Append(row1);
        vectorRows.Append(row2);
        vectorRows.Append(row3);
        vectorRows.Append(row4);
        vectorRows.Append(row5);

        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 PassKeypress(KeyCode keyPress)
    {
        int x = 0;
        int y = 0;

        for(x = 0; x < keyRows.Length; x++)
        {
            for(y = 0; y < keyRows[x].Length; y++)
            {
                if (keyRows[x][y] == keyPress)
                {
                    return vectorRows[x][y];
                }
            }
        }

        return Vector3.zero;
    }

    public IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Ant newAnt = new Ant();
        Vector3[] possiblePositions = {new Vector3(7.61999989f,1.76999998f,0), new Vector3(7.61999989f,1.00999999f,0), new Vector3(7.61999989f,0.270000011f,0), new Vector3(7.61999989f,-0.660000026f,0), new Vector3(7.61999989f,-1.57000005f,0)}; 
        
        int randNum = UnityEngine.Random.Range(0, possiblePositions.Length);
        newAnt.row = randNum;
        Vector3 pos = possiblePositions[randNum];

        Instantiate(new Ant(), pos, new Quaternion());
    } 
}
