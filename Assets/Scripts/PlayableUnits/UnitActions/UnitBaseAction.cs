using UnityEngine;

namespace PlayableUnits.UnitActions
{
    public abstract class UnitBaseAction : MonoBehaviour
    {

        protected Unit unit;
        protected bool isActive;

        protected virtual void Awake()
        {
            unit = GetComponent<Unit>();
        }

    }
}