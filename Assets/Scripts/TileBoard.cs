using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour
{

    private TileGrid grid;
    public TileState[] tileStates;
    private void Awake()
    {
        grid = GetComponentInChildren<TileGrid>();
    }
    private void Start()
    {
    }
}
