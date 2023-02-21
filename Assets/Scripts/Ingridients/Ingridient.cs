using UnityEngine;

[CreateAssetMenu(fileName = "new ingridient", menuName = "Ingridient/Create new ingridient", order = 51)]
public class Ingridient : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _id;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public int Id => _id;
    public Sprite Icon => _icon;
}
