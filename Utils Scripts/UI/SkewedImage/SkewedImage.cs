using UnityEngine;
using UnityEngine.UI;

namespace Playgig.UI.SkewedImage
{
    public class SkewedImage : Image
    {
        [Range(0, 180)] public float SkewXValue;
        [Range(0, 180)] public float SkewYValue;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            base.OnPopulateMesh(vh);

            var rect = rectTransform.rect;

            var height = rect.height;
            var width = rect.width;

            var xSkew = height * Mathf.Tan(Mathf.Deg2Rad * SkewXValue);
            var ySkew = width * Mathf.Tan(Mathf.Deg2Rad * SkewYValue);

            var newY = rect.yMin;
            var newX = rect.xMin;
            var vertex = new UIVertex();

            for (var i = 0; i < vh.currentVertCount; i++)
            {
                vh.PopulateUIVertex(ref vertex, i);

                var lerpedXValue = Mathf.Lerp(0, xSkew, (vertex.position.y - newY) / height);
                var lerpedYValue = Mathf.Lerp(0, ySkew, (vertex.position.x - newX) / width);

                vertex.position += new Vector3(lerpedXValue, lerpedYValue, 0);

                vh.SetUIVertex(vertex, i);

            }
        }
    }
}