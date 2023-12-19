using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class TileGrid : MonoBehaviour
{
    private float _cellSize;
    private int _height;
    private int _width;
    private TileCell[,] fieldCell;

   [Header("Field Property")]
   [SerializeField] private int _fieldSize;
   [SerializeField] private float _space;
    [SerializeField] private int _initialCount;

   [SerializeField] private GameObject cellPrefab;

   [SerializeField] private Color[] color;
   [SerializeField] private RectTransform rt;
   
    private void Start()
    {
        rt.sizeDelta = new Vector2(Screen.width, Screen.width);
        fieldCell = new TileCell[_fieldSize,_fieldSize];
        GenerateField();
    }
    private void GenerateField()
    {
        _width = Screen.width;
        _height = _width;
        _cellSize = (_width - _space * 5) / 4;
        float startX = -(_width / 2) + (_cellSize / 2) + _space;
        float startY = (_width / 2) - (_cellSize / 2) - _space;

        for (int x = 0; x < _fieldSize; x++)
        {
            for (int y = 0; y < _fieldSize; y++)
            {
                var cell = Instantiate(cellPrefab, transform, false);
                cell.GetComponent<RectTransform>().sizeDelta = new Vector2(_cellSize, _cellSize);
                var position = new Vector2(startX + (x * (_cellSize + _space)), startY - (y * (_cellSize + _space)));
                cell.transform.localPosition = position;
                
                
                fieldCell[x, y] = cell.GetComponent<TileCell>();
                fieldCell[x, y].DefaultColor(color[y]);
                fieldCell[x, y].SetValue(x, y, 0);
            }
           
        }
        for (int i = 0; i < _initialCount;i++)
        {
            GenerateRandomCell();
        }
    }
    //public void GenerateBoard()
    //{
    //    if (fieldCell == null) CreateField();

    //    for (int x = 0; x < _fieldSize; x++)
    //    {
    //        for (int y = 0; y < _fieldSize; y++)
    //        {
    //            fieldCell[x, y].SetValue(x, y, 0);
    //        }
    //    }
    //}
    private void GenerateRandomCell()
    {
        var emptyCells = new List<TileCell>();
        for (int x = 0; x < _fieldSize; x++)
        {
            for (int y = 0; y < _fieldSize; y++)
            {
                if (fieldCell[x, y].IsEmpty)
                    emptyCells.Add(fieldCell[x, y]);
            }
        }

        if (emptyCells.Count == 0)
            throw new System.Exception("Not empty");

        int value = Random.Range(0,10) == 0 ? 2 : 1;

        var cell = emptyCells[Random.Range(0, emptyCells.Count)];
        cell.SetValue(cell.X,cell.Y, value);  
    }

}
