using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class Testing : MonoBehaviour
{

    Grid grid;
    // Start is called before the first frame update
    private void Start()
    {
        grid = new Grid(20, 20, 2f, new Vector3(0, 0));
        grid.SetValue(0, 0, 1);
        grid.SetValue(1, 0, 2);
        grid.SetValue(2, 0, 3);
        grid.SetValue(3, 0, 4);
        grid.SetValue(4, 0, 5);
        grid.SetValue(5, 0, 6);
        grid.SetValue(6, 0, 7);
        grid.SetValue(7, 0, 8);
        grid.SetValue(8, 0, 9);

    }

    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            Vector3 worldPosition = UtilsClass.GetMouseWorldPosition();
            grid.SetValue(worldPosition, 10);
        }
    }
}
