using Interface.Animation;
using Manager;
using UnityEngine;

namespace Model.NPC
{
    public class NpcFriend : NPC
    {
        protected override AudioClip GetAudioClip()
            => AudioManager.Instance.NpcAudioClips[(int)NpcAudio.Friend];
    }
}