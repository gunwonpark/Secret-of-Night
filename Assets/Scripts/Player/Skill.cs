using UnityEngine;

[System.Serializable]
public class Skill
{
    [SerializeField] private int _id;
    [SerializeField] private bool _isActive;

    public int ID => _id;
    public bool IsActive => _isActive;
    public Skill(int id, bool isActive = false)
    {
        _id = id;
        _isActive = isActive;
    }

    public void Active()
    {
        _isActive = true;
    }
}
