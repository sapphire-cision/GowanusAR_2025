using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;

public enum FMRenderType { Unlit, Lambert, UnlitFX, LambertFX, UnlitBrush }
public enum FMBrushType { brush_Circle, brush_Pencil, brush_Watercolor, brush_PaintStoke, brush_Customised }

[ExecuteInEditMode]
public class FMPCHelper : MonoBehaviour
{
    [SerializeField] private FMRenderType renderType = FMRenderType.Unlit;
    [SerializeField] private FMBrushType brushType = FMBrushType.brush_Circle;

    private Material mat;
    private bool hasBlendShape = false;

    public FMRenderType RenderType { get { return renderType; } set { renderType = value; } }
    public FMBrushType BrushType { get { return brushType; } set { brushType = value; } }
    public bool HasBlendShape { get { return hasBlendShape; } }

    #region Shader Specs
    [SerializeField] private Color mainColor = new Color(1, 1, 1, 1);

    [Range(0.000001f, 100f)]
    [SerializeField] private float pointSize = 0.04f;
    [SerializeField] private bool applyDistance = true;

    [Range(0f, 1f)]
    [SerializeField] private float blend = 0f;

    public Color MainColor { get { return mainColor; } set { mainColor = value; } }
    public float PointSize { get { return pointSize; } set { pointSize = value; } }
    public bool ApplyDistance { get { return applyDistance; } set { applyDistance = value; } }
    public float Blend { get { return blend; } set { blend = value; } }
    #endregion

    #region DataFX
    [SerializeField] private Vector3 windDirection = Vector3.zero;

    [Range(0f, 10)]
    [SerializeField] private float windPower = 1f;

    [Range(0, 90)]
    [SerializeField] private float angThreshold = 60f;

    [Range(0.001f, 10f)]
    [SerializeField] private float duration = 1f;

    public Vector3 WindDirection { get { return windDirection; } set { windDirection = value; } }
    public float WindPower { get { return windPower; } set { windPower = value; } }
    public float AngThreshold { get { return angThreshold; } set { angThreshold = value; } }
    public float Duration { get { return duration; } set { duration = value; } }
    #endregion

    #region MeshFX
    private Mesh PMesh;
    private Mesh CMesh;
    private float CSize;

    private Vector3[] vertices;
    private int[] triangles;
    private Color[] colors;
    private Vector2[] uvs;

    private Texture2D targetBrushTexture;
    [SerializeField] private Texture2D customisedBrushTexture;

    public Texture2D CustomisedBrushTexture { get { return customisedBrushTexture; } set { customisedBrushTexture = value; } }
    #endregion

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, windDirection.normalized * 10f, Color.green);
        mat = Application.isPlaying ? GetComponent<Renderer>().material : GetComponent<Renderer>().sharedMaterial;
        //CheckRenderType();
        if (mat == null) return;
        mat.color = mainColor;
        mat.SetFloat("_PointSize", pointSize);
        mat.SetFloat("_ApplyDistance", applyDistance ? 1f : 0f);

        mat.SetVector("_WindDirection", new Vector4(windDirection.x, windDirection.y, windDirection.z, angThreshold));
        mat.SetFloat("_WindPower", windPower);
        mat.SetFloat("_Duration", duration);

        bool _hasBlendShape = false;
        if (GetComponent<SkinnedMeshRenderer>() != null)
        {
            if (GetComponent<SkinnedMeshRenderer>().sharedMesh != null)
            {
                if (GetComponent<SkinnedMeshRenderer>().sharedMesh.blendShapeCount > 0) _hasBlendShape = true;
            }
        }

        hasBlendShape = _hasBlendShape;
        if (hasBlendShape)
        {
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, Blend);
            mat.SetFloat("_Blend", blend);
        }

        CheckRenderType();
    }

    public void CheckRenderType()
    {
        if (PMesh == null) PMesh = hasBlendShape ? GetComponent<SkinnedMeshRenderer>().sharedMesh : GetComponent<MeshFilter>().sharedMesh;

        string ShaderName = "FMPCD/FMPCUnlit";
        switch (renderType)
        {
            case FMRenderType.Unlit:
                ShaderName = "FMPCD/FMPCUnlit";
                break;
            case FMRenderType.Lambert:
                ShaderName = "FMPCD/FMPCLambert";
                break;
            case FMRenderType.UnlitFX:
                ShaderName = "FMPCD/FMPCUnlitFX";
                break;
            case FMRenderType.LambertFX:
                ShaderName = "FMPCD/FMPCLambertFX";
                break;
            case FMRenderType.UnlitBrush:
                ShaderName = "FMPCD/FMPCUnlitBrush";
                CheckBrush();
                break;
        }


        if (renderType == FMRenderType.UnlitBrush)
        {
            if (CMesh == null || CSize != pointSize * 2f)
            {
                if (hasBlendShape)
                {
                    CreateMeshBlend();
                }
                else
                {
                    CreateMesh();
                }
            }
            else
            {
                if (forceFacingMainCamera)
                {
                    if (!hasBlendShape) CreateMesh();
                }
            }
        }
        else
        {
            if (CMesh != null)
            {
                DestroyImmediate(CMesh);
                if (!hasBlendShape)
                {
                    GetComponent<MeshFilter>().sharedMesh = PMesh;
                }
                else
                {
                    GetComponent<SkinnedMeshRenderer>().sharedMesh = PMesh;
                }
            }
        }

        //Debug.Log(CMesh == null ? "null" : "not null");
        if (hasBlendShape) ShaderName += "Blend";
        if (mat.shader.name != ShaderName) mat.shader = Shader.Find(ShaderName);
    }

    void CheckBrush()
    {
        if (brushType == FMBrushType.brush_Customised)
        {
            mat.mainTexture = customisedBrushTexture;
            return;
        }

        if (brushType == FMBrushType.brush_Circle)
        {
            if (targetBrushTexture != null) targetBrushTexture = null;
            if (mat.HasProperty("_MainTex"))
            {
                if (mat.mainTexture != null) mat.mainTexture = Texture2D.whiteTexture;
            }
            return;
        }

        if (targetBrushTexture == null)
        {
            targetBrushTexture = Resources.Load<Texture2D>("Brushes/" + brushType.ToString());
            mat.mainTexture = targetBrushTexture;
        }
        else
        {
            if (targetBrushTexture.name != brushType.ToString())
            {
                targetBrushTexture = null;
                targetBrushTexture = Resources.Load<Texture2D>("Brushes/" + brushType.ToString());
                mat.mainTexture = targetBrushTexture;
            }
        }
    }

    void CreateMeshBlend()
    {
        if (!Application.isPlaying) return;
        if (PMesh == null) return;
        if (CMesh != null) DestroyImmediate(CMesh);
        CSize = pointSize * 2f;

        CMesh = new Mesh();
        CMesh.name = "tmp_mesh";

        Vector3[] PVertices = PMesh.vertices;
        vertices = new Vector3[PMesh.vertexCount * 3];
        triangles = new int[PMesh.vertexCount * 3];

        Color[] PColors = PMesh.colors;
        colors = new Color[PMesh.vertexCount * 3];

        uvs = new Vector2[PMesh.vertexCount * 3];

        Vector3[] PNormals = PMesh.normals;
        bool MissingNormals = PNormals.Length == 0;

        //================Blendshape data================
        Vector3[] deltaVertices = new Vector3[PMesh.vertexCount];
        Vector3[] deltaNormals = new Vector3[PMesh.vertexCount];
        Vector3[] deltaTangents = new Vector3[PMesh.vertexCount];
        PMesh.GetBlendShapeFrameVertices(0, 0, deltaVertices, deltaNormals, deltaTangents);
        Vector3[] CDeltaVertices = new Vector3[PMesh.vertexCount * 3];
        Vector3[] CDeltaNormals = new Vector3[PMesh.vertexCount * 3];
        Vector3[] CDeltaTangents = new Vector3[PMesh.vertexCount * 3];

        Vector4[] PTangents = PMesh.tangents;
        Vector4[] CTangents = new Vector4[PMesh.vertexCount * 3];
        //================Blendshape data================


        for (int i = 0; i < PVertices.Length; i += 1)
        {
            int index = i * 3;
            Vector3 pos = PVertices[i];
            Vector3 _Norm = MissingNormals ? (pos + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized : PNormals[i];

            vertices[index] = vertices[index + 1] = vertices[index + 2] = pos;
            vertices[index] += Quaternion.LookRotation(_Norm) * new Vector3(0, CSize, 0);
            vertices[index + 1] += Quaternion.LookRotation(_Norm) * new Vector3(-(CSize * Mathf.Sin(Mathf.PI / 3f)), -(CSize * Mathf.Cos(Mathf.PI / 3f)), 0);
            vertices[index + 2] += Quaternion.LookRotation(_Norm) * new Vector3((CSize * Mathf.Sin(Mathf.PI / 3f)), -(CSize * Mathf.Cos(Mathf.PI / 3f)), 0);

            triangles[index] = index;
            triangles[index + 1] = index + 1;
            triangles[index + 2] = index + 2;

            colors[index] = PColors[i];
            colors[index + 1] = PColors[i];
            colors[index + 2] = PColors[i];

            uvs[index] = uvs[index + 1] = uvs[index + 2] = new Vector2(0.5f, 0.5f);
            uvs[index] += new Vector2(0, 0.5f);
            uvs[index + 1] += new Vector2(-0.5f * (Mathf.Sin(Mathf.PI / 3f)), -0.5f * (Mathf.Cos(Mathf.PI / 3f)));
            uvs[index + 2] += new Vector2((0.5f * Mathf.Sin(Mathf.PI / 3f)), -0.5f * (Mathf.Cos(Mathf.PI / 3f)));

            //================Blendshape data================
            CDeltaVertices[index] = CDeltaVertices[index + 1] = CDeltaVertices[index + 2] = deltaVertices[i];
            CDeltaNormals[index] = CDeltaNormals[index + 1] = CDeltaNormals[index + 2] = deltaNormals[i];
            CDeltaTangents[index] = CDeltaTangents[index + 1] = CDeltaTangents[index + 2] = deltaTangents[i];

            CTangents[index] = CTangents[index + 1] = CTangents[index + 2] = PTangents[i];
            //================Blendshape data================
        }

        CMesh.indexFormat = vertices.Length > 65535 ? UnityEngine.Rendering.IndexFormat.UInt32 : UnityEngine.Rendering.IndexFormat.UInt16;

        CMesh.vertices = vertices;
        CMesh.triangles = triangles;

        CMesh.colors = colors;
        CMesh.uv = uvs;

        //================Blendshape data================
        CMesh.tangents = CTangents;
        CMesh.AddBlendShapeFrame("blend1", 1f, CDeltaVertices, CDeltaNormals, CDeltaTangents);
        //================Blendshape data================

        CMesh.UploadMeshData(true);
        GetComponent<SkinnedMeshRenderer>().sharedMesh = CMesh;
    }

    void CreateMesh()
    {
        if (!Application.isPlaying) return;
        if (PMesh == null) return;
        //if (CMesh != null) DestroyImmediate(CMesh);

        if (isCreatingMesh) return;
        
        StartCoroutine(CreateMeshCOR());
    }

    [SerializeField] private bool forceFacingMainCamera = false;
    public bool ForceFacingMainCamera { get { return forceFacingMainCamera; } set { forceFacingMainCamera = value; } }

    private bool stop = false;
    [HideInInspector]
    public int TaskThreadCount = 0;
    [HideInInspector]
    public int TaskThreadFinished = 0;

    [Header("Progress: Waiting(sec)")]
    public float TimeLeft = 0;
    [Range(0f, 1f)]
    public float progress = 0f;

    public bool isCreatingMesh = false;
    IEnumerator CreateMeshCOR()
    {
        if (isCreatingMesh) yield break;
        isCreatingMesh = true;

        CSize = pointSize * 2f;

        Vector3[] PVertices = PMesh.vertices;
        vertices = new Vector3[PMesh.vertexCount * 3];
        triangles = new int[PMesh.vertexCount * 3];

        Color[] PColors = PMesh.colors;
        colors = new Color[PMesh.vertexCount * 3];

        uvs = new Vector2[PMesh.vertexCount * 3];

        Vector3[] PNormals = PMesh.normals;
        bool MissingNormals = PNormals.Length == 0;

        Vector3 mainCamPos = Vector3.zero;
        Vector3 rootPosition = transform.position;
        Vector3 rootScale = transform.lossyScale;
        Quaternion rootRotation = transform.rotation;

        bool FacingMainCamera = forceFacingMainCamera;
        if (FacingMainCamera)
        {
            if (Camera.main != null)
            {
                mainCamPos = Camera.main.transform.position;
            }
            else
            {
                FacingMainCamera = false;
            }
        }

        while (Loom.numThreads > Loom.maxThreads - 1) yield return null;
        TaskThreadFinished = 0;
        TaskThreadCount = Loom.maxThreads - Loom.numThreads;
        int MaximumPoints = PVertices.Length;
        int step = Mathf.CeilToInt((float)MaximumPoints / (float)TaskThreadCount);

        bool existingMesh = CMesh != null;
        for (int j = 0; j < TaskThreadCount; j++)
        {
            Loom.RunAsync(() =>
            {
                int _j = j;
                int _start_num = _j * step;
                int _maximum_num = Mathf.Clamp((_j + 1) * step, 0, MaximumPoints);

                for (int i = _start_num; i < _maximum_num && !stop; i++)
                {
                    int index = i * 3;
                    Vector3 pos = PVertices[i];

                    Vector3 _Norm;
                    if (!FacingMainCamera)
                    {
                        _Norm = MissingNormals ? (pos + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized : PNormals[i];
                    }
                    else
                    {
                        Vector3 globalPosition = rootRotation * pos;
                        globalPosition.x *= rootScale.x;
                        globalPosition.y *= rootScale.y;
                        globalPosition.z *= rootScale.z;

                        //add root position
                        globalPosition += rootPosition;

                        //multiply with an opposite rotation value(inverse), in order to match local/global conversion.
                        _Norm = Quaternion.Inverse(rootRotation) * (mainCamPos - globalPosition);
                    }

                    vertices[index] = vertices[index + 1] = vertices[index + 2] = pos;
                    vertices[index] += Quaternion.LookRotation(_Norm) * new Vector3(0, CSize, 0);
                    vertices[index + 1] += Quaternion.LookRotation(_Norm) * new Vector3(-(CSize * Mathf.Sin(Mathf.PI / 3f)), -(CSize * Mathf.Cos(Mathf.PI / 3f)), 0);
                    vertices[index + 2] += Quaternion.LookRotation(_Norm) * new Vector3((CSize * Mathf.Sin(Mathf.PI / 3f)), -(CSize * Mathf.Cos(Mathf.PI / 3f)), 0);

                    if (!existingMesh)
                    {
                        triangles[index] = index;
                        triangles[index + 1] = index + 1;
                        triangles[index + 2] = index + 2;

                        colors[index] = PColors[i];
                        colors[index + 1] = PColors[i];
                        colors[index + 2] = PColors[i];

                        uvs[index] = uvs[index + 1] = uvs[index + 2] = new Vector2(0.5f, 0.5f);
                        uvs[index] += new Vector2(0, 0.5f);
                        uvs[index + 1] += new Vector2(-0.5f * (Mathf.Sin(Mathf.PI / 3f)), -0.5f * (Mathf.Cos(Mathf.PI / 3f)));
                        uvs[index + 2] += new Vector2((0.5f * Mathf.Sin(Mathf.PI / 3f)), -0.5f * (Mathf.Cos(Mathf.PI / 3f)));
                    }
                }
                Loom.QueueOnMainThread(() => { System.Threading.Interlocked.Increment(ref TaskThreadFinished); });
                System.Threading.Thread.Sleep(1);
            });
            yield return null;
        }

        float TimeStart = Time.realtimeSinceStartup;
        while (TaskThreadFinished < TaskThreadCount) yield return null;

        if (CMesh == null)
        {
            CMesh = new Mesh();
            CMesh.name = "tmp_mesh";
        }
        
        CMesh.vertices = vertices;

        if (!existingMesh)
        {
            CMesh.indexFormat = vertices.Length > 65535 ? UnityEngine.Rendering.IndexFormat.UInt32 : UnityEngine.Rendering.IndexFormat.UInt16;

            CMesh.triangles = triangles;

            CMesh.colors = colors;
            CMesh.uv = uvs;
        }

        CMesh.UploadMeshData(false);
        GetComponent<MeshFilter>().sharedMesh = CMesh;


        //Debug.LogError(Time.realtimeSinceStartup - TimeStart);
        isCreatingMesh = false;
    }

    private void Action_StopAll()
    {
        stop = false;
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        Action_StopAll();
    }

    private void OnDestroy()
    {
        Action_StopAll();
    }
}
