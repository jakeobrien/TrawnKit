using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrawnButtonHelper
{

    public static bool IsStickButton(TrawnButton button)
    {
        if (button == TrawnButton.Left ||
            button == TrawnButton.Right ||
            button == TrawnButton.Up ||
            button == TrawnButton.Down)
        {
            return true;
        }
        return false;
    }


    public static bool IsActionButton(TrawnButton button)
    {
        if (button == TrawnButton.Blue ||
            button == TrawnButton.Purple ||
            button == TrawnButton.Green)
        {
            return true;
        }
        return false;
    }


}
