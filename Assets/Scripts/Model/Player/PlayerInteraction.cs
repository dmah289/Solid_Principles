using Interface;
using Model.NPC;
using UnityEngine;

namespace Model.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public void TriggerInteractedObject(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<NPC.NPC>(out var npc))
            {
                npc.Interact();
            }
        }

        public void ExitInteractedObject(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<NPC.NPC>(out var npc))
            {
                npc.ExitInteraction();
            }
        }

        public void SlashObject(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<EnemyController>(out var npc))
            {
                npc.GetHit();
            }
        }
    }
}