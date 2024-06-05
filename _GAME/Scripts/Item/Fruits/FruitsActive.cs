using UnityEngine;

public class FruitsActive : NewMonoBehaviour
{
    [SerializeField] protected FRUITS _fruit;
    [SerializeField] protected float _time = 3f;
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag(TagConst.PLAYER_TAG)) return;
        Desactive();
    }

    protected virtual void Desactive()
    {
        GameObject collected = CollectedPooling.instance.GetPoolingObject();
        collected.transform.position = transform.parent.position;
        collected.SetActive(true);

        MissionsFruitsManager.instance.PickUpFruit(_fruit);
        AudioManager.instance.PlaySFX("BonusPoint");

        transform.parent.gameObject.SetActive(false);
    }

    protected virtual void Active()
    {
        transform.parent.gameObject.SetActive(true);
    }
    protected virtual void OnDisable()
    {
        Invoke(nameof(Active), _time);
    }
}
