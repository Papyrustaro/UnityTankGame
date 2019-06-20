using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var direction = Input.mousePosition - pos;
        var angle = GetAim(Vector3.zero, direction);
        transform.SetLocalEulerAnglesY(-angle + 90);
    }
    public float GetAim(Vector2 from, Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
