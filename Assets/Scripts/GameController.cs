using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using System;

public class GameController : MonoBehaviour
{
    public static Action<Direction> input;
    public enum Direction { Left,Right,Down,Top}

    private void Awake()
    {
        input += OnInput;
    }
    private void Start()
    {
        TileGrid.Instance.CreateField();
        TileGrid.Instance.GenerateField();
    }
    private void OnInput(Direction direction)
    {
       
    }
}
