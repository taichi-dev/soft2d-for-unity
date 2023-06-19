using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Taichi.Soft2D.Plugin;

namespace Game
{
    [SelectionBase]
    public class GameManager : Singleton<GameManager>
    {
        [HideInInspector] public UIManager uiManager;
        private bool isPause;

        public bool IsPause
        {
            get => isPause;
            set
            {
                isPause = value;
                Soft2DManager.Instance.pause = value;
            }
        }

        [HideInInspector] public List<Inventory> inventoriesRemain;

        public int currentInvId = -1;

        public LevelData lvlData;

        protected override void Awake()
        {
            base.Awake();
            uiManager = GameObject.FindObjectOfType<UIManager>();
        }

        protected void Start()
        {
            //Load level's information through level data
            foreach (var inv in lvlData.Inventories)
            {
                inventoriesRemain.Add(inv);
            }
        }

        private void MouseDown()
        {
            if (Input.GetMouseButton(0) && !isPause)
            {
                if (currentInvId == -1 || inventoriesRemain[currentInvId].InventoryNum == 0)
                {
                    return;
                }
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (pos.x < 0.0f || pos.x > 4.0f || pos.y < 0.0f || pos.y > 2.0f) { }
                else
                {
                    pos.z = 0.0f;
                    pos.x = (int)(pos.x / 0.1f) * 0.1f + 0.05f;
                    pos.y = (int)(pos.y / 0.1f) * 0.1f + 0.05f;
                    if (inventoriesRemain[currentInvId].Type == InventoryType.Heater)
                    {
                        var inv = new Inventory
                        {
                            Type = inventoriesRemain[currentInvId].Type,
                            InventoryNum = inventoriesRemain[currentInvId].InventoryNum - 1
                        };
                        inventoriesRemain[currentInvId] = inv;
                        BodyBase[] bodies = FindObjectsOfType<BodyBase>();
                        // transform snow to fluid
                        foreach (var body in bodies)
                        {
                            uint tag = Utils.CreateTag(new Color32(0,129,201,255), body.particleTag);
                            body.SetBodyTagBuffer(tag);
                            body.SetBodyMaterialType(MaterialType.Fluid);
                        }
                    }
                    else
                    {
                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                        if (hit.collider == null)
                        {
                            // create new collider
                            var inv = new Inventory
                            {
                                Type = inventoriesRemain[currentInvId].Type,
                                InventoryNum = inventoriesRemain[currentInvId].InventoryNum - 1
                            };
                            inventoriesRemain[currentInvId] = inv;

                            GameObject go = Instantiate(Resources.Load<GameObject>($"Prefabs/Square"), pos, Quaternion.identity);
                            go.GetComponent<ECollider>()?.CreateCollider();
                        }
                    }
                }
            }
        }

        protected void Update()
        {
            MouseDown();
            uiManager.UpdateInventories(inventoriesRemain);
        }

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public void LoadNextLevel(string levelName)
        {
            string[] words = levelName.Split(' ');
            int currLevelNum = int.Parse(words[1]);
            int nextLevelNum = currLevelNum == 10 ? 1 : ++currLevelNum;
            SceneManager.LoadScene("Level " + nextLevelNum);
        }
    }
}