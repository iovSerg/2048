using UnityEngine;
using UnityEngine.UI;

public class TileGrid : MonoBehaviour
{
    private float size;
    private int height;
    private int width;
    private TileCell[,] tileCells;
    [Header("Space Cell")]
   [SerializeField] private float _space;
   [Header("Field Size")]
   [SerializeField] private int _fieldSize;

   [SerializeField] private GameObject cellPrefab;

   [SerializeField] private Color[] color;
   [SerializeField] private RectTransform rt;
   
    private void Start()
    {
        rt.sizeDelta = new Vector2(Screen.width, Screen.width);
        tileCells = new TileCell[_fieldSize,_fieldSize];
        CreateField();
    }
    private void CreateField()
    {
        width = Screen.width;
        height = width;
        size = (width - _space * 5) / 4;
        float startX = -(width / 2) + (size / 2) + _space;
        float startY = (width / 2) - (size / 2) - _space;

        for (int x = 0; x < _fieldSize; x++)
        {
            for (int y = 0; y < _fieldSize; y++)
            {
                var cell = Instantiate(cellPrefab, transform, false);
                cell.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
                var position = new Vector2(startX + (x * (size + _space)), startY - (y * (size + _space)));
                cell.transform.localPosition = position;
                cell.GetComponent<Image>().color = color[y];

            }
        }
    }

}
