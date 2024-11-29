using System;
using UnityEngine;

namespace Scripts.Systems.GridPlacement
{
    [Serializable]
    internal class Config
    {
        [field: SerializeField] internal protected PlacingUnitsOnMapSettings PlacingUnitsOnMapSettings { get; protected set; }
    }
}