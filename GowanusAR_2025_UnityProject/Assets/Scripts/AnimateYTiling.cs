using UnityEngine;

public class AnimateYTiling : MonoBehaviour
{
    public Renderer targetRenderer;
    public float speed = 1f; // How fast to animate Y tiling
    public float minTilingY = 1f;
    public float maxTilingY = 2f;

    private Material _mat;
    private Vector2 _originalTiling;

    void Start()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();

        // Clone the material so we don't edit the shared one
        _mat = targetRenderer.material;
        _originalTiling = _mat.mainTextureScale;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        float newY = Mathf.Lerp(minTilingY, maxTilingY, t);
        _mat.mainTextureScale = new Vector2(_originalTiling.x, newY);
    }
}
