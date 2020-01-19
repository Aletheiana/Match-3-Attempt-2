using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Color32 Clear;
    public static Color32 White;
    public static Color32 T1;
    public static Color32 T2;
    public static Color32 T3;
    public static Color32 T4;
    public static Color32 T5;
    public static Color32 T6;

    public Token TokenPrefab;

    public static Token TokenDragged;
    public static Cell CellClicked;
    public static bool Click;

    public static bool Match;

    // Start is called before the first frame update
    void Start()
    {
        Clear = new Color32(255, 255, 255, 0);
        White = new Color32(255, 255, 255, 255);
        T1 = new Color32(255, 0, 0, 255);
        T2 = new Color32(0, 255, 0, 255);
        T3 = new Color32(0, 0, 255, 255);
        T4 = new Color32(255, 255, 0, 255);
        T5 = new Color32(255, 0, 255, 255);
        T6 = new Color32(0, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
