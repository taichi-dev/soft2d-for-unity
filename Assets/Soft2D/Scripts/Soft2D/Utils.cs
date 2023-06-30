using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using Taichi.Soft2D.Generated;
using UnityEditor;
using UnityEngine.Tilemaps;

namespace Taichi.Soft2D.Plugin
{
    /// <summary>
    /// Structure specifying parameters of a newly created S2Kinematics
    /// </summary>
    public struct KinematicsInfo
    {
        public Vector2 center;
        public float rotation;
        public Vector2 linearVelocity;
        public float angularVelocity;
        public S2Mobility mobility;
    }

    /// <summary>
    /// Types of Soft2D shape
    /// </summary>
    public enum ShapeType
    {
        Box,
        Circle,
        Ellipse,
        Capsule,
        Polygon,
    }

    /// <summary>
    /// Types of Soft2D material
    /// </summary>
    public enum MaterialType
    {
        Fluid,
        Elastic,
        Sand,
        Snow,
    }


    public enum CollisionType
    {
        Separate, // Particles will leave the collider after colliding with the collider.
        Slip,     // Particles will slide along the edge after colliding with the collider.
        Sticky,   // Particles will stick to the collider after collision.
    }

    public static class Utils
    {
        [Tooltip("Soft2D path in gameObject")] private const string menuPath = "GameObject/Soft2D for Unity";
        [Tooltip("Soft2D collider prefabs' path")] private const string colliderPath = menuPath + "/Collider";
        [Tooltip("Convert MaterialType to S2MaterialType")]public static readonly Dictionary<MaterialType, S2MaterialType> MaterialTypeDictionary;
        [Tooltip("Convert CollisionType to S2CollisionType")] public static readonly Dictionary<CollisionType, S2CollisionType> CollisionTypeDictionary;

        static Utils()
        {
            // Create MaterialTypeDictionary 
            MaterialTypeDictionary = new Dictionary<MaterialType, S2MaterialType>()
            {
                { MaterialType.Fluid ,S2MaterialType.S2_MATERIAL_TYPE_FLUID},
                { MaterialType.Elastic ,S2MaterialType.S2_MATERIAL_TYPE_ELASTIC},
                { MaterialType.Sand ,S2MaterialType.S2_MATERIAL_TYPE_SAND},
                { MaterialType.Snow ,S2MaterialType.S2_MATERIAL_TYPE_SNOW},
            };
            
            // Create CollisionTypeDictionary
            CollisionTypeDictionary = new Dictionary<CollisionType, S2CollisionType>()
            {
                { CollisionType.Sticky ,S2CollisionType.S2_COLLISION_TYPE_STICKY},
                { CollisionType.Slip ,S2CollisionType.S2_COLLISION_TYPE_SLIP},
                { CollisionType.Separate ,S2CollisionType.S2_COLLISION_TYPE_SEPARATE},
            };
        }

        /// <summary>
        /// Combine particle's color RGB and logical tag together and insert them into a uint variable.
        /// Variable's high 4 bits are particle's logical tag, low 24 bits are particle's color RGB.
        /// </summary>
        /// <param name="color">particle's color</param>
        /// <param name="tag">particle's logical tag</param>
        /// <returns>tagBuffer with color RGB and logical tag</returns>
        public static uint CreateTag(Color32 color, uint tag)
        {
            uint output = tag << 24 | (uint)color.r << 16 | ((uint)color.g << 8) | (uint)color.b;
            return output;
        }

        public static void Assert(string warningText)
        {
            Debug.LogError(warningText);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        #region Generate kinematics & material & shape

        /// <summary>
        /// Create a S2Kinematics with specified parameters.
        /// </summary>
        /// <param name="createInfo">Input KinematicsInfo</param>
        /// <returns>Output S2Kinematics</returns>
        public static S2Kinematics CreateKinematics(KinematicsInfo createInfo)
        {
            var kinematics = new S2Kinematics
            {
                center = new S2Vec2(createInfo.center.x,createInfo.center.y),
                rotation = createInfo.rotation,
                linear_velocity = new S2Vec2(createInfo.linearVelocity.x, createInfo.linearVelocity.y),
                angular_velocity = createInfo.angularVelocity,
                mobility = createInfo.mobility,
            };
            return kinematics;
        }

        /// <summary>
        /// Create a S2BoxShape with specified parameters.
        /// </summary>
        /// <param name="halfExtentX">Half length of width </param>
        /// <param name="halfExtentY">Half length of height </param>
        /// <returns>Output S2BoxShape</returns>
        public static S2Shape CreateBoxShape(float halfExtentX, float halfExtentY)
        {
            var shape = new S2Shape
            {
                type = S2ShapeType.S2_SHAPE_TYPE_BOX,
                shape_union = new S2ShapeUnion
                {
                    box = new S2BoxShape { half_extent = new S2Vec2 { x = halfExtentX, y = halfExtentY } }
                },
            };
            return shape;
        }

        /// <summary>
        /// Create a S2CircleShape with specified parameters.
        /// </summary>
        /// <param name="radius">Circle's radius</param>
        /// <returns>Output S2CircleShape</returns>
        public static S2Shape CreateCircleShape(float radius)
        {
            var shape = new S2Shape
            {
                type = S2ShapeType.S2_SHAPE_TYPE_CIRCLE,
                shape_union = new S2ShapeUnion
                {
                    circle = new S2CircleShape { radius = radius }
                },
            };
            return shape;
        }

        /// <summary>
        /// Create a S2CapsuleShape with specified parameters.
        /// </summary>
        /// <param name="halfRectLength"> Half length of central rectangle</param>
        /// <param name="capRadius"> Radius of caps on the two sides</param>
        /// <returns>Output S2CapsuleShape</returns>
        public static S2Shape CreateCapsuleShape(float halfRectLength, float capRadius)
        {
            var shape = new S2Shape
            {
                type = S2ShapeType.S2_SHAPE_TYPE_CAPSULE,
                shape_union = new S2ShapeUnion
                {
                    capsule = new S2CapsuleShape
                        { rect_half_length = halfRectLength, cap_radius = capRadius }
                },
            };
            return shape;
        }

        /// <summary>
        /// Create a S2EllipseShape with specified parameters.
        /// </summary>
        /// <param name="radiusX">Ellipse's radius along the X axis</param>
        /// <param name="radiusY">Ellipse's radius along the Y axis</param>
        /// <returns>Output S2EllipseShape</returns>
        public static S2Shape CreateEllipseShape(float radiusX, float radiusY)
        {
            var shape = new S2Shape
            {
                type = S2ShapeType.S2_SHAPE_TYPE_ELLIPSE,
                shape_union = new S2ShapeUnion
                {
                    ellipse = new S2EllipseShape { radius_x = radiusX, radius_y = radiusY }
                },
            };
            return shape;
        }

        /// <summary>
        /// Create a S2PolygonShape with specified parameters.
        /// </summary>
        /// <param name="points"> The local positions of the polygon's vertices </param>
        /// <param name="ptr"> IntPtr of the vertex array. This pointer should be freed manually. </param>
        /// <returns>Output S2PolygonShape</returns>
        public static S2Shape CreatePolygonShape(List<Vector2> points,out IntPtr ptr)
        {
            if (points.Count == 0)
            {
                Debug.LogError("The quantity of points should above 0!");
                ptr = IntPtr.Zero;
                return new S2Shape();
            }
            var shape = new S2Shape
            {
                type = S2ShapeType.S2_SHAPE_TYPE_POLYGON,
                shape_union = new S2ShapeUnion(),
            };
            float[] vertices = new float[points.Count * 2];
            for (int i = 0; i < points.Count; i++)
            {
                vertices[i * 2] = points[i].x;
                vertices[i * 2 + 1] = points[i].y;
            }
            ptr = Marshal.AllocHGlobal(vertices.Length * sizeof(float));
            Marshal.Copy(vertices,0,ptr,vertices.Length);
            shape.shape_union.polygon = new S2PolygonShape { vertex_num = (uint)vertices.Length/2, vertices = ptr };
            return shape;
        }

        /// <summary>
        /// Create a MeshBody with a specified 2DSprite's mesh.
        /// </summary>
        /// <param name="material">MeshBody's S2Material</param>
        /// <param name="kinematics">MeshBody's S2Kinematics</param>
        /// <param name="sprite">MeshBody's Mesh Sprite</param>
        /// <param name="tagBuffer">MeshBody's tagBuffer</param>
        /// <param name="scale">MeshBody's mesh scale</param>
        /// <returns>Output MeshBody Handle</returns>
        public static Soft2D.Body CreateMeshBody(S2Material material, S2Kinematics kinematics, Sprite sprite, uint tagBuffer,float scale=0.1f)
        {
            ushort[] triangles = sprite.triangles;
            Vector2[] vertices = sprite.vertices;

            float[] vertices_data_2 = new float[vertices.Length * 2];
            int[] indices = new int[triangles.Length];

            for (int i = 0; i < vertices.Length; ++i)
            {
                vertices_data_2[i * 2] = vertices[i].x * scale;
                vertices_data_2[i * 2 + 1] = vertices[i].y * scale;
            }
            for (int i = 0; i < triangles.Length; ++i)
            {
                indices[i] = triangles[i];
            }

            Soft2D.Body body = Soft2D.World.CreateMeshBody(material, kinematics, vertices_data_2.Length / 2,
                vertices_data_2, indices.Length, indices, tagBuffer);
            return body;
        }

        /// <summary>
        /// Create a MeshBody with specified parameters.
        /// </summary>
        /// <param name="material">MeshBody's S2Material</param>
        /// <param name="kinematics">MeshBody's S2Kinematics</param>
        /// <param name="vertArray">Mesh's vertices array</param>
        /// <param name="triArray">Mesh's triangles array</param>
        /// <param name="tagBuffer">MeshBody's tagBuffer</param>
        /// <param name="scale">MeshBody's mesh scale</param>
        /// <returns>Output MeshBody Handle</returns>
        public static Soft2D.Body CreateMeshBody(S2Material material, S2Kinematics kinematics, Vector2[] vertArray, int[] triArray, uint tagBuffer,float scale=0.1f)
        {
            int[] triangles = triArray;
            Vector2[] vertices = vertArray;

            float[] vertices_data_2 = new float[vertices.Length * 2];
            int[] indices = new int[triangles.Length];

            for (int i = 0; i < vertices.Length; ++i)
            {
                vertices_data_2[i * 2] = vertices[i].x * scale;
                vertices_data_2[i * 2 + 1] = vertices[i].y * scale;
            }
            for (int i = 0; i < triangles.Length; ++i)
            {
                indices[i] = (int)triangles[i];
            }

            Soft2D.Body body = Soft2D.World.CreateMeshBody(material, kinematics, vertices_data_2.Length / 2,
                vertices_data_2, indices.Length, indices, tagBuffer);
            return body;
        }

        #endregion

#if UNITY_EDITOR

        // Functions below are used to create Soft2D GameObjects in Hierarchy window
        #region Create Soft2D Prefabs

        [MenuItem(menuPath + "/Body/Body", false)]
        private static void CreateBodyPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Body.prefab";
            var source = new GameObject("Body");
            EBody body = source.AddComponent<EBody>();
            body.density = 1000;
            body.youngsModulus = 0.3f;
            body.poissonsRatio = 0.2f;
            body.particleTag = 1;
            body.uniformColor = new Color(0, 129 / 255f, 201 / 255f, 200 / 255f);
            body.halfWidth = 0.1f;
            body.halfHeight = 0.1f;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        [MenuItem(menuPath + "/Body/Custom Body", false)]
        private static void CreateCustomBodyPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/CustomBody.prefab";
            var source = new GameObject("CustomBody");
            ECustomBody customBody = source.AddComponent<ECustomBody>();
            customBody.density = 1000;
            customBody.youngsModulus = 0.3f;
            customBody.poissonsRatio = 0.2f;
            customBody.particleTag = 1;
            customBody.uniformColor = new Color32(0, 129, 201, 200);
            customBody.particlesPosition.Add(new Vector2(0, 0));
            customBody.particlesPosition.Add(new Vector2(0, 0.05f));
            customBody.particlesPosition.Add(new Vector2(0.05f, 0.05f));
            customBody.particlesPosition.Add(new Vector2(0.05f, 0));
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        [MenuItem(menuPath + "/Body/Mesh Body", false)]
        private static void CreateMeshBodyPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/MeshBody.prefab";
            var source = new GameObject("MeshBody");
            EMeshBody meshBody = source.AddComponent<EMeshBody>();
            meshBody.density = 1000;
            meshBody.youngsModulus = 0.9f;
            meshBody.poissonsRatio = 0.2f;
            meshBody.particleTag = 1;
            meshBody.uniformColor = new Color32(0, 129, 201, 200);
            meshBody.meshScale = 1;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        [MenuItem(menuPath + "/Emitter", false)]
        private static void CreateEmitterPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Emitter.prefab";
            var source = new GameObject("Emitter");
            EEmitter eEmitter = source.AddComponent<EEmitter>();
            eEmitter.emitOnAwake = true;
            eEmitter.linearVelocity = new Vector2(0, -7);
            eEmitter.lifetime = 100;
            eEmitter.frequency = 2;
            eEmitter.density = 1000;
            eEmitter.youngsModulus = 0.3f;
            eEmitter.poissonsRatio = 0.2f;
            eEmitter.particleTag = 1;
            eEmitter.uniformColor = new Color(0, 129 / 255f, 201 / 255f, 200 / 255f);
            eEmitter.halfWidth = 0.1f;
            eEmitter.halfHeight = 0.1f;
            eEmitter.shapeType = ShapeType.Circle;
            eEmitter.radius = 0.02f;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }


        [MenuItem(menuPath + "/Soft2DManager", false)]
        private static void CreateSoft2DManagerPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Soft2DManager.prefab";
            var source = new GameObject("Soft2DManager");
            Soft2DManager soft2DManager = source.AddComponent<Soft2DManager>();
            soft2DManager.instanceMaterial = AssetDatabase.LoadAssetAtPath<Material>(PathInitializer.MainPath + "/Materials/Prototype/UnlitParticleMat.mat");
            soft2DManager.worldExtent = new Vector2(1, 1);
            soft2DManager.gravity = new Vector2(0, -30f);
            soft2DManager.instanceSize = 0.01f;
            soft2DManager.enableDebuggingTools = false;
            soft2DManager.timeStep = 16e-3f / 4.0f;
            soft2DManager.colliderCol = new Color(93 / 255f, 231 / 255f, 0, 1);
            soft2DManager.triggerCol = new Color(246 / 255f, 238 / 255f, 6 / 255f, 1);
            soft2DManager.instanceMesh =
                LoadAssetFromUniqueAssetPath<Mesh>($"Library/unity default resources::Sphere");
            soft2DManager.S2Substep = 1e-4f;
            soft2DManager.S2MaxParticleNum = 90000;
            soft2DManager.S2MaxBodyNum = 10000;
            soft2DManager.S2MaxTriggerNum = 10000;
            soft2DManager.S2GridResolution = 128;
            soft2DManager.S2FineGridScale = 4;
            soft2DManager.S2NormalForceScale = 0.1f;
            soft2DManager.S2VelocityForceScale = 0.1f;
            soft2DManager.S2MeshBodyForceScale = 1e-6f;
            soft2DManager.enableWorldBoundary = true;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }


        [MenuItem(colliderPath + "/Box", false)]
        private static void CreateBoxColliderPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Box.prefab";
            var source = new GameObject("Box");
            source.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            var renderer = source.AddComponent<SpriteRenderer>();
            renderer.sprite =
                AssetDatabase.LoadAssetAtPath<Sprite>(PathInitializer.MainPath + "Materials/Sprites/Square.png");
            BoxCollider2D coll = source.AddComponent<BoxCollider2D>();
            coll.size = new Vector2(1f, 1f);
            Rigidbody2D rb = source.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            ECollider eCollider = source.AddComponent<ECollider>();
            eCollider.uCollider = coll;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        [MenuItem(colliderPath + "/Capsule", false)]
        private static void CreateCapsuleColliderPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Capsule.prefab";
            var source = new GameObject("Capsule");
            source.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            var renderer = source.AddComponent<SpriteRenderer>();
            renderer.sprite =
                AssetDatabase.LoadAssetAtPath<Sprite>(PathInitializer.MainPath + "Materials/Sprites/Capsule.png");
            CapsuleCollider2D coll = source.AddComponent<CapsuleCollider2D>();
            Rigidbody2D rb = source.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            ECollider eCollider = source.AddComponent<ECollider>();
            eCollider.uCollider = coll;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        [MenuItem(colliderPath + "/Circle", false)]
        private static void CreateCircleColliderPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Circle.prefab";
            var source = new GameObject("Circle");
            source.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            var renderer = source.AddComponent<SpriteRenderer>();
            renderer.sprite =
                AssetDatabase.LoadAssetAtPath<Sprite>(PathInitializer.MainPath + "Materials/Sprites/Circle.png");
            CircleCollider2D coll = source.AddComponent<CircleCollider2D>();
            Rigidbody2D rb = source.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            ECollider eCollider = source.AddComponent<ECollider>();
            eCollider.uCollider = coll;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        [MenuItem(colliderPath + "/Polygon", false)]
        private static void CreatePolygonColliderPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Polygon.prefab";
            var source = new GameObject("Polygon");
            source.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            source.AddComponent<SpriteRenderer>();
            PolygonCollider2D coll = source.AddComponent<PolygonCollider2D>();
            Rigidbody2D rb = source.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            ECollider eCollider = source.AddComponent<ECollider>();
            eCollider.uCollider = coll;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        [MenuItem(colliderPath + "/Tilemap", false)]
        private static void CreateTilemapColliderPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Grid.prefab";
            var source = new GameObject("Grid");
            var tilemap = new GameObject("Tilemap");
            tilemap.transform.SetParent(source.transform);
            source.AddComponent<Grid>();
            tilemap.AddComponent<Tilemap>();
            tilemap.AddComponent<TilemapRenderer>();
            Rigidbody2D rb=tilemap.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            TilemapCollider2D tileColl = tilemap.AddComponent<TilemapCollider2D>();
            tileColl.usedByComposite = true;
            CompositeCollider2D coll = tilemap.AddComponent<CompositeCollider2D>();
            coll.geometryType = CompositeCollider2D.GeometryType.Polygons;
            ECollider eCollider = tilemap.AddComponent<ECollider>();
            eCollider.uCollider = coll;
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        [MenuItem(menuPath + "/Trigger", false)]
        private static void CreateTriggerPrefab()
        {
            var assetPath = PathInitializer.MainPath + "Prefabs/Trigger.prefab";
            var source = new GameObject("Trigger");
            source.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            var renderer = source.AddComponent<SpriteRenderer>();
            renderer.sprite =
                AssetDatabase.LoadAssetAtPath<Sprite>(PathInitializer.MainPath + "Materials/Sprites/Square.png");
            BoxCollider2D coll=source.AddComponent<BoxCollider2D>();
            coll.isTrigger = true;
            source.AddComponent<ETrigger>();
            PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        }

        private static T LoadAssetFromUniqueAssetPath<T>(string aAssetPath) where T : UnityEngine.Object
        {
            if (aAssetPath.Contains("::"))
            {
                string[] parts = aAssetPath.Split(new string[] { "::" },System.StringSplitOptions.RemoveEmptyEntries);
                aAssetPath = parts[0];
                if (parts.Length > 1)
                {
                    string assetName = parts[1];
                    System.Type t = typeof(T);
                    var assets = AssetDatabase.LoadAllAssetsAtPath(aAssetPath)
                        .Where(i => t.IsInstanceOfType(i)).Cast<T>();
                    var obj = assets.FirstOrDefault(i => i.name == assetName);
                    if (obj == null)
                    {
                        int id;
                        if (int.TryParse(parts[1], out id))
                            obj = assets.FirstOrDefault(i => i.GetInstanceID() == id);
                    }
                    if (obj != null)
                        return obj;
                }
            }
            return AssetDatabase.LoadAssetAtPath<T>(aAssetPath);
        }
        #endregion

#endif
    }
}
