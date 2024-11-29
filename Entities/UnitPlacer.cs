using System.Collections.Generic;
using Scripts.Systems.GridGeneration;
using UnityEngine;

namespace Scripts.Systems.GridPlacement
{
    internal class UnitPlacer
    {
        private readonly PlacingUnitsOnMapSettings _settings;
        private Vector3 _currentPosition;
        private GenerationInfoCallback _generationInfoCallback;

        private readonly List<Vector3> _movableItemsPositions = new();
        private SearchConditions _searchConditions;

        internal UnitPlacer(PlacingUnitsOnMapSettings settings) {
            _settings = settings;
        }

        internal virtual List<Vector3> PlaceDeskOnMap(in int deskCount, GenerationInfoCallback generationInfoCallback) {
            _generationInfoCallback = generationInfoCallback;

            _searchConditions = () => IsConditionsFromSettingAllows();
            SetPositions(deskCount, _searchConditions);

            if (_movableItemsPositions.Count < deskCount) UseSimplifyPlacedConditions(deskCount);

            return _movableItemsPositions;
        }

        private void UseSimplifyPlacedConditions(in int deskCount) {
            _searchConditions = () => true;
            var count = deskCount - _movableItemsPositions.Count;
            SetPositions(count, _searchConditions);
        }

        private void SetPositions(in int placesCount, SearchConditions checkConditions) {
            for (var i = 0; i < placesCount; i++) {
                foreach (var item in _generationInfoCallback.MapInfo) {
                    _currentPosition = item.Key;
                    if (IsDefaultConditionsAllows(item) && checkConditions()) {
                        _movableItemsPositions.Add(_currentPosition);
                        break;
                    }
                }
            }
        }

        protected virtual bool IsConditionsFromSettingAllows() {
            if (_currentPosition.x < _settings.HeroSpawnBorder) {
                foreach (var placedItem in _movableItemsPositions) {
                    foreach (var dir in _generationInfoCallback.Directions) {
                        for (var interval = 1; interval <= _settings.Density; interval++)
                            if (_currentPosition == placedItem + dir.Value * interval)
                                return false;
                    }
                }

                return true;
            }

            return false;
        }

        private bool IsDefaultConditionsAllows(KeyValuePair<Vector3, IGridCellData> item) {
            return item.Value.MoveAbility != 0 && !_movableItemsPositions.Contains(_currentPosition);
        }

        private delegate bool SearchConditions();
    }
}