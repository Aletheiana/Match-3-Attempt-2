using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int X;
    public int Y;
    SpriteRenderer SpriteRenderer;
    public int TokenType;
    public Token TokenContained;
    public Vector3 TokenPosition;

    public bool GameStart;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = this.GetComponent<SpriteRenderer>();
        TokenPosition = this.transform.position + new Vector3(0, 0, -1);
        TokenContained = GenerateToken(TokenPosition);
        TokenContained.HostCell = this;
        TokenType = TokenContained.Type;
        GameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart == true)
        {
            TokenColourChange(TokenContained, true, GameManager.Clear);
            GameStart = false;
        }
    }

    // When the cell is hovered over
    private void OnMouseEnter()
    {
        if(GameManager.Click == false)
        {
            SpriteRenderer.color = GameManager.Clear;
        }
        else
        {
            SpriteRenderer.color = GameManager.T1;
            CheckForMatch();
        }
    }

    // When the cell stops being hovered over
    private void OnMouseExit()
    {
        if (GameManager.Click == false)
        {
            SpriteRenderer.color = GameManager.White;
        }
        else
        {
            if(GameManager.CellClicked == this)
            {
                SpriteRenderer.color = GameManager.T6;
            }
            else
            {
                SpriteRenderer.color = GameManager.White;
            }
            Resetty();
        }
    }

    // When you click

    private void OnMouseDown()
    {
        this.TokenContained.dragging = true;
        GameManager.TokenDragged = this.TokenContained;
        GameManager.CellClicked = this;
        GameManager.Click = true;
        SpriteRenderer.color = GameManager.T2;
    }

    // When you unclick

    private void OnMouseUp()
    {
        if(GameManager.Match == false)
        {
            GameManager.CellClicked.SpriteRenderer.color = GameManager.White;
            this.TokenContained.dragging = false;
            GameManager.TokenDragged = null;
            GameManager.CellClicked = null;
            GameManager.Click = false;
        }
        else
        {
            
        }
    }

    // Generates a token in the given location & randomises its type
    public Token GenerateToken(Vector3 vector3)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        Token token;
        token = Instantiate(gameManager.TokenPrefab);
        token.Type = Random.Range(1, 7);
        token.transform.position = vector3;
        token.name = token.Type + ": " + this.name;
        return token;
    }

    public void TokenColourChange(Token token, bool MatchType, Color32 optional)
    {
        SpriteRenderer spriteRenderer = token.GetComponent<SpriteRenderer>();

        if (MatchType == true)
        {
            if(token.Type == 1)
            {
                spriteRenderer.color = GameManager.T1;
            }
            else if(token.Type == 2)
            {
                spriteRenderer.color = GameManager.T2;
            }
            else if (token.Type == 3)
            {
                spriteRenderer.color = GameManager.T3;
            }
            else if (token.Type == 4)
            {
                spriteRenderer.color = GameManager.T4;
            }
            else if (token.Type == 5)
            {
                spriteRenderer.color = GameManager.T5;
            }
            else if (token.Type == 6)
            {
                spriteRenderer.color = GameManager.T6;
            }
        }
        else
        {
            spriteRenderer.color = optional;
        }
    }

    public void CheckForMatch()
    {

    }

    public void Resetty()
    {
        
    }
    
}
