using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFix : MonoBehaviour
{
    public Color Highlighted;
    public Color NormalColor;
    private Image Button;
    public Type ButtonType;
    public bool isholding;
    public MoveMent player;
    public int button2;
    private void Start()
    {
        Button = gameObject.GetComponent<Image>();
        
    }
    public void Update()
    {
        if(button2 == 1)
        {
            player.IsMoving1 = isholding;
        }
        if (button2 == 2)
        {
            player.IsMoving = isholding;
        }

        if (isholding)
        {
            Button.color = Highlighted;
            if (ButtonType == Type.Forward)
            {
                MoveMent.moveforward();
            }
            if (ButtonType == Type.Backward)
            {
                MoveMent.moveBack();
            }
            if (ButtonType == Type.Left)
            {
                MoveMent.moveLeft();
            }
            if (ButtonType == Type.Right)
            {
                MoveMent.moveRight();
            }
            if (ButtonType == Type.Jump)
            {
                MoveMent.Jump();
            }
        }
        else
        {
            Button.color = NormalColor;
        }

    }
    public void Buttonhold(bool Select)
    {
        isholding = Select;
        return;
    }

    public enum Type
    {
        Forward,
        Backward,
        Left,
        Right,
        Jump
    }

}
