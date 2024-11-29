using UnityEngine;
using Zenject;

namespace Scripts.Systems.GridPlacement
{
    internal class GridPlacementInstaller : MonoInstaller
    {
        [SerializeField] private Config _config;

        public override void InstallBindings() {
            Container.Bind<UnitPlacer>().AsSingle().WithArguments(_config.PlacingUnitsOnMapSettings);
            Container.Bind<GridPlacer>().AsSingle();
        }
    }
}