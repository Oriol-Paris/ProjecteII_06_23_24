using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GetPlayerPos 
{
    Vector2 GetPlayerPos(PlayerMovement playerMovement)
    {
        return playerMovement.GetPlayerPos();
    }
}
