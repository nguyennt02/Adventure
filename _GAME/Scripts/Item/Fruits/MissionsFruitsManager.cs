using System.Collections.Generic;
using UnityEngine;

public class MissionsFruitsManager : NewMonoBehaviour
{
    private static MissionsFruitsManager _instance;
    public static MissionsFruitsManager instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("MissionsFruitsManager already exist");
        _instance = this;
    }

    [SerializeField] private List<MissionFruits> _lstMission;
    private int _index = 0;
    private bool _isComplete = false;
    private bool _iStart = false;
    public bool isComplete => _isComplete;
 
    public void StartMission() 
    {
        _iStart = true;
        UIDialogueOsv.Disable += UpdateUIMission;
    }

    public void PickUpFruit(FRUITS fruit)
    {
        if (!_iStart || _isComplete || fruit != _lstMission[_index].fruits.fruits) return;
        _lstMission[_index].quantity++;

        NextMission();
        UpdateUIMission();
    }

    private void NextMission()
    {
        if (_lstMission[_index].quantity != _lstMission[_index].maxQuantity) return;
        if (_index < _lstMission.Count-1) _index++;
        else Complete();
    }
    private void Complete()
    {
       _isComplete = true;
        UIDialogueOsv.Disable -= UpdateUIMission;
        AudioManager.instance.PlaySFX("CompleteMission");
    }
    public void UpdateUIMission()
    {
        UIMissionOsv.UpdateMission?.Invoke(
            _lstMission[_index].fruits.spFruit,
            _lstMission[_index].maxQuantity,
            _lstMission[_index].quantity,
            new Vector2(80, 80));
    }
/*    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Complete();
        }
    }*/
}
