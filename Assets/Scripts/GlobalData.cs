using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static int candies = 0;

    public static void AddCandy(int amount)
    {
        candies += amount;
    }
}