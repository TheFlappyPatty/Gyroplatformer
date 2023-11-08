using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private void Start()
    {
        Button = gameObject.GetComponent<Image>();
        
    }
    public void Update()
    {
        if (isholding)
        {
            player.IsMoving = true;
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
            player.IsMoving = false;
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
