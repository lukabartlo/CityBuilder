using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject pendingObject;

    public float gridSize;
    private bool gridOn = true;
    [SerializeField] private Toggle gridToggle; 
    
    private Vector3 pos;
    
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if (pendingObject != null)
        {
            if (gridOn)
            {
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                    );
            }
            
            else
            {
                pendingObject.transform.position = pos;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }
        }
    }
    
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void PlaceObject()
    {
        pendingObject = null;
    }
    
    public void SelectObject(int index)
    {
        pendingObject = Instantiate(objects[index], pos, Quaternion.identity);
    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn)
        {
            gridOn = true;
        }
        else
        {
            gridOn = false;
        }
    }

    private float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
