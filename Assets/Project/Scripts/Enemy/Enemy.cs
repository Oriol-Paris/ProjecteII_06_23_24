using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Enemy(int maxHealth, Movement movement, Attack attack)
        : base(maxHealth, movement, attack) {}
}

