using System;

[Serializable]
public class MissionsEnemy
{
    public Enemys enemy;
    public int maxQuantity;
    [NonSerialized] public int quantity;
}
