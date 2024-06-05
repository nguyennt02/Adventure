using UnityEngine;

[CreateAssetMenu(fileName = "Enemys", menuName = "SO/Enemys", order = 3)]
public class Enemys : ScriptableObject
{
    public ENEMYS enemy;
    public Sprite spEnemy;
}
public enum ENEMYS
{
    BEE,
    PLANT,
    MUSHROOM,
    BULE_BIRD,
    CHICKEN,
    CHAMELEON,
    RADISH,
    RINO,
    TRUNK
}