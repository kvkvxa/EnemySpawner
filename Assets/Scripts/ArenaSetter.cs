using UnityEngine;

public class ArenaSetter : MonoBehaviour
{
    private Vector3 _planeSize = new(10, 1, 10);

    public float Width => _planeSize.x;
    public float Length => _planeSize.z;

    void Start()
    {
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = Vector3.zero;
        floor.transform.localScale = new Vector3(1, 1, 1);

        AddBorders();
    }

    private void AddBorders()
    {
        float halfWidth = _planeSize.x / 2;
        float halfHeight = _planeSize.z / 2;

        CreateBorder(new Vector3(0, 0.5f, -halfHeight));
        CreateBorder(new Vector3(0, 0.5f, halfHeight)); 
        CreateBorder(new Vector3(-halfWidth, 0.5f, 0), true);
        CreateBorder(new Vector3(halfWidth, 0.5f, 0), true); 
    }

    private void CreateBorder(Vector3 position, bool vertical = false)
    {
        GameObject border = GameObject.CreatePrimitive(PrimitiveType.Cube);
        border.transform.position = position;

        if (vertical)
        {
            border.transform.localScale = new Vector3(1, 1, _planeSize.z);
        }
        else
        {
            border.transform.localScale = new Vector3(_planeSize.x, 1, 1);
        }

        border.GetComponent<Renderer>().material.color = Color.black;
    }
}