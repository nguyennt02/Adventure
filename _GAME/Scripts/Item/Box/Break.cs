using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Break : NewMonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected Vector2 _forceDirection = Vector2.right;
    [SerializeField] protected float _force = 20;
    [SerializeField] protected float _timeLife;
    protected Vector3 _location;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (_rb) return;
        LogWarning("LoadRigidbody");
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        AddForce();
        Invoke(nameof(Desactive), _timeLife);
    }

    protected virtual void Start()
    {
        _location = transform.localPosition;
    }
    protected virtual void AddForce()
    {
        _rb.AddForce(_force * _forceDirection.normalized * 10);
    }
    protected virtual void Desactive()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnDisable()
    {
        transform.localPosition = _location;
    }
}
