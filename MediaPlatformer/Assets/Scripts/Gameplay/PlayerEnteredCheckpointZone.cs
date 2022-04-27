using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player enters a trigger with a CheckpointZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredCheckpointZone"></typeparam>
    public class PlayerEnteredCheckpointZone : Simulation.Event<PlayerEnteredCheckpointZone>
    {
        public CheckpointZone cpzone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.spawnPoint.position = cpzone.transform.position;
        }
    }
}
