using System;
using System.Collections;
using Framework;
using Interface;
using UnityEngine;

namespace Model.NPC
{
    public class EnemyInteraction : MonoBehaviour, IInteracted
    {
        // Components
        private SpriteRenderer spriteRenderer;
        
        public event Action<GameObject> OnGetInteracted;
        public event Action OnExitInteraction;
        
        [SerializeField] private bool isInteracting;
        public bool IsInteracting => isInteracting;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void GetInteracted(GameObject gameObj)
        {
            OnGetInteracted?.Invoke(gameObj);
            StartCoroutine(GetHitCoroutine(gameObj));
        }

        public IEnumerator GetHitCoroutine(GameObject gameObj)
        {
            isInteracting = true;
            
            spriteRenderer.color = Color.red;
            yield return Helper.GetWait(KeySave.slashDuration);
            spriteRenderer.color = Color.white;
            
            isInteracting = false;
        }
        
        public void ExitInteraction()
        {
            OnExitInteraction?.Invoke();
        }
    }
}