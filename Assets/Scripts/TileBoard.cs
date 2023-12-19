using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
    public static TileBoard Instance;
    public TileState[] tileStates;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
}
