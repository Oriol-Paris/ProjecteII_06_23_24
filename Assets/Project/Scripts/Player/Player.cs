using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Player(int maxHealth, Movement movement, Attack attack)
        : base(maxHealth, movement, attack) { }
}
