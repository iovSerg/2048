using System.Collections;
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

    [SerializeField] private Color color;
    [SerializeField] private Image background;
    [SerializeField] private Image sprite;
    [SerializeField] TextMeshProUGUI points;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void DefaultColor(Color color)
    {
        this.color = color;
        background.color = color;
    }
    public void SetValue(int x, int y, int value)
    {
        this.X = x;
        this.Y = y; 
        this.Value = value;
        UpdateCell();
    }
    [ContextMenu("Image Rotate")]
    public void TestUpdateCell() 
    {
        animator.SetTrigger("Switch");
        StartCoroutine(SwitchSpriteCell());
    }
    private IEnumerator SwitchSpriteCell()
    {
        yield return new WaitForSeconds(1f);
        points.text = IsEmpty ? string.Empty : Points.ToString();
        if (Value != 0)
        {
            background.color = TileBoard.Instance.tileStates[2].backgroundColor;
            sprite.sprite = TileBoard.Instance.tileStates[2].sprite;
            sprite.color = Color.white;
            yield return new WaitForSeconds(1.5f);
            sprite.rectTransform.rotation = Quaternion.identity;
        }
        else
        {
            background.color = color;
            sprite.color = color;

        }
    }
    public void UpdateCell()
    {
        points.text = IsEmpty ? string.Empty : Points.ToString();
        if (Value != 0)
        {
            background.color = TileBoard.Instance.tileStates[Value].backgroundColor;
            sprite.sprite = TileBoard.Instance.tileStates[Value].sprite;
            sprite.color = Color.white;
        }
        else
        {
            background.color = color;
            sprite.color = color;

        }
    }
}
