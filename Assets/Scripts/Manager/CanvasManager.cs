using System;
using Model.NPC;
using UnityEngine;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

namespace Manager
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private GameObject infoPanel;
        [SerializeField] private Text infoText;
        [SerializeField] private RectTransform screamPanel;
        [SerializeField] private GameObject mobileInput;

        private async void OnEnable()
        {
            NPC[] npcs = GameManager.Instance.listNpcs;
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].OnInteractNpc += ShowInfo;
                npcs[i].OnExitInteractionNpc += HideInfo;
                if (npcs[i] is EnemyController enemy)
                {
                    while(enemy.Interacted == null)
                        await Task.Yield();
                    enemy.Interacted.OnGetInteracted += Scream;
                    enemy.Interacted.OnExitInteraction += StopScreaming;
                }
            }
        }

        private void Start()
        {
            mobileInput.SetActive(GameManager.Instance.typeInput == TypeInput.Mobile);
        }

        private void OnDisable()
        {
            NPC[] npcs = GameManager.Instance.listNpcs;
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].OnInteractNpc -= ShowInfo;
                npcs[i].OnExitInteractionNpc -= HideInfo;
                if (npcs[i] is EnemyController enemy)
                {
                    enemy.Interacted.OnGetInteracted -= Scream;
                    enemy.Interacted.OnExitInteraction -= StopScreaming;
                }
            }
        }

        public void ShowInfo(NPC npc)
        {
            infoText.text = npc.name;
            infoPanel.SetActive(true);
        }

        public void HideInfo()
        {
            infoPanel.SetActive(false);
        }

        public void Scream(GameObject gameObj)
        {
            screamPanel.position = RectTransformUtility.WorldToScreenPoint(Camera.main, gameObj.transform.position + new Vector3(0, 1, 0));
            screamPanel.gameObject.SetActive(true);
        }

        public void StopScreaming()
        {
            screamPanel.gameObject.SetActive(false);
        }
    }
}