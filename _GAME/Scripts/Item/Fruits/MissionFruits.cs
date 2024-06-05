using System;

[Serializable]
public class MissionFruits
{
    public Fruits fruits;
    public int maxQuantity;
    [NonSerialized] public int quantity;
}
