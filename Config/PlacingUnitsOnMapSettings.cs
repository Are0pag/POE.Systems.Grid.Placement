#if UNITY_EDITOR
using Scripts.Tools.CustomEdit;
#endif
using UnityEngine;

namespace Scripts.Systems.GridPlacement
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = nameof(PlacingUnitsOnMapSettings), menuName = DirectoryNames.GRID_SYSTEM_DATA_PATH + nameof(PlacingUnitsOnMapSettings))]
#endif
    internal class PlacingUnitsOnMapSettings : ScriptableObject
    {
        /// <summary>
        ///     Right border X coordinate on map where can spawn player heroes desk on start
        /// </summary>
        [field: Tooltip("Right border X coordinate on map where can spawn player heroes desk on start")]
        [field: Range(0f, 50f)]
        [field: SerializeField]
        internal protected float HeroSpawnBorder { get; protected set; }

        /// <summary>
        ///     The density of the placement of units on the map at the beginning of the level. This setting expresses the number
        ///     of CachedCellsOnInputTrace between units
        /// </summary>
        [field: Tooltip("The density of the placement of units on the map at the beginning of the level")]
        [field: Range(0, 10)]
        [field: SerializeField]
        internal protected int Density { get; protected set; }
    }
}