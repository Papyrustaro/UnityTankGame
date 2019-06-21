using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouseCursor : MonoBehaviour
{
    private Vector3 pos;
    private bool useController = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetJoystickNames()[0] != "") //ゲームパッドが接続されているか
        {
            useController = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (useController)
        {
            var h = Input.GetAxis("CannonHorizontal");
            var v = Input.GetAxis("CannonVertical");
            if (v * v + h * h > 0f) //倒していないときに上を向かないように
            {
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("CannonHorizontal"), Input.GetAxis("CannonVertical")) * 180 / Mathf.PI, 0);
            }
        }
        else
        {
            pos = Camera.main.WorldToScreenPoint(transform.position);
            var direction = Input.mousePosition - pos;
            var angle = GetAim(Vector3.zero, direction);
            transform.SetLocalEulerAnglesY(-angle + 90);
        }
    }
    public float GetAim(Vector2 from, Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
    public Vector2 SnapAngle(Vector2 vector, float angleSize)
    {
        var angle = Mathf.Atan2(vector.y, vector.x);
        var index = Mathf.RoundToInt(angle / angleSize);
        var snappedAngle = index * angleSize;
        var magnitude = vector.magnitude;
        return new Vector2(Mathf.Cos(snappedAngle) * magnitude, Mathf.Sin(snappedAngle) * magnitude);
    }
}
