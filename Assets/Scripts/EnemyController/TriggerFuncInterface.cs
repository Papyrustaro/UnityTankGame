using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TriggerFuncInterface
{
    void BodyEnter(Collider other);
    void BodyExit(Collider other);
    void BodyStay(Collider other);
    void NearEnter(Collider other);
    void NearExit(Collider other);
    void NearStay(Collider other);
}
