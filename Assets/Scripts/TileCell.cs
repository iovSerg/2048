using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileCell : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Value { get; private set; }
    public int Points => IsEmpty ?  0 : (int)Mathf.Pow(2,Value);
    public bool IsEmpty => Value == 0;
    public const int MaxValue = 11;

    [SerializeField] private Image image;
    [SerializeField] TextMeshProUGUI points;

    public void SetValue(int x, int y, int value)
    {
        this.X = x;
        this.Y = y; 
        this.Value = value;
        UpdateCell();
    }

    public void UpdateCell()
    {
        points.text = IsEmpty ? string.Empty : Points.ToString();
    }
}
