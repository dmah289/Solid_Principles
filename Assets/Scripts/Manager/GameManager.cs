using Framework;
using Model.NPC;
using UnityEngine;

namespace Manager
{
    public enum TypeInput
    {
        Mobile,
        Keyboard
    }
    
    public class GameManager : Singleton<GameManager>
    {
        public NPC[] listNpcs;
        
        public TypeInput typeInput;

        protected override void Awake()
        {
            base.Awake();
            listNpcs = FindObjectsByType<NPC>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        }
    }
}