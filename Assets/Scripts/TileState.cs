using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu( fileName = "Tile", menuName = "2048")]
public class TileState : ScriptableObject
{
    public Color backgroundColor;
    public Image image;
    public Sprite sprite;
    public TextMeshPro text;
    public int Number;
}
