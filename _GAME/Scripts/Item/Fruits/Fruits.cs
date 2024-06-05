using UnityEngine;

[CreateAssetMenu(fileName ="Fruits", menuName ="SO/Fruits", order = 2)]
public class Fruits : ScriptableObject
{
    public FRUITS fruits;
    public Sprite spFruit;
}
public enum FRUITS
{
    APPLE,
    BANANAS,
    CHERRIES,
    KIWI,
    MELON,
    ORANGE,
    PINEAPPLE,
    STRAWBERRY
}