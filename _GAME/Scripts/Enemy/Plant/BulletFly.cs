using UnityEngine;

public class BulletFly : NewMonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Vector3 _direction;

    protected virtual void Update()
    {
        transform.parent.Translate(_direction * _speed * Time.deltaTime);
    }
}
