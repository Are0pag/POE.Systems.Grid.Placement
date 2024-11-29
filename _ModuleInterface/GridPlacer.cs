using System.Collections.Generic;
using Scripts.Systems.GridGeneration;
using UnityEngine;

namespace Scripts.Systems.GridPlacement
{
    public sealed class GridPlacer
    {
        private readonly UnitPlacer _unitPlacer;

        internal GridPlacer(UnitPlacer unitPlacer) {
            _unitPlacer = unitPlacer;
        }


        public List<Vector3> PlaceDeckOnGrid(in int deckCapacity, GenerationInfoCallback call) {
            return _unitPlacer.PlaceDeskOnMap(deckCapacity, call);
        }
    }
}