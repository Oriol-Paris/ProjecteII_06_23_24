using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soggetto : Enemy
{
    public Soggetto(int maxHealth, Movement movement, Attack attack)
        : base(maxHealth, movement, attack) { }
}
