using Microsoft.Maui.Graphics;
using System.Collections.Generic;
using System.Numerics;

namespace BonesOfTheFallen.Services.Graphics
{
    public interface IPathF
    {
        PointF this[int index] { get; }

        RectangleF Bounds { get; }
        bool Closed { get; }
        int Count { get; }
        PointF FirstPoint { get; }
        PointF LastPoint { get; }
        int LastPointIndex { get; }
        int OperationCount { get; }
        object PlatformPath { get; set; }
        IEnumerable<PointF> Points { get; }
        int SegmentCountExcludingOpenAndClose { get; }
        IEnumerable<PathOperation> SegmentTypes { get; }
        int SubPathCount { get; }

        PathF AddArc(float x1, float y1, float x2, float y2, float startAngle, float endAngle, bool clockwise);
        PathF AddArc(PointF topLeft, PointF bottomRight, float startAngle, float endAngle, bool clockwise);
        void AppendCircle(float cx, float cy, float r);
        void AppendCircle(PointF center, float r);
        void AppendEllipse(float x, float y, float w, float h);
        void AppendEllipse(RectangleF rect);
        void AppendRectangle(float x, float y, float w, float h, bool includeLast = false);
        void AppendRectangle(RectangleF rect, bool includeLast = false);
        void AppendRoundedRectangle(float x, float y, float w, float h, float cornerRadius, bool includeLast = false);
        void AppendRoundedRectangle(float x, float y, float w, float h, float topLeftCornerRadius, float topRightCornerRadius, float bottomLeftCornerRadius, float bottomRightCornerRadius, bool includeLast = false);
        void AppendRoundedRectangle(RectangleF rect, float cornerRadius, bool includeLast = false);
        void AppendRoundedRectangle(RectangleF rect, float xCornerRadius, float yCornerRadius);
        void AppendRoundedRectangle(RectangleF rect, float topLeftCornerRadius, float topRightCornerRadius, float bottomLeftCornerRadius, float bottomRightCornerRadius, bool includeLast = false);
        void Close();
        PathF CurveTo(float c1X, float c1Y, float c2X, float c2Y, float x, float y);
        PathF CurveTo(PointF controlPoint1, PointF controlPoint2, PointF point);
        void Dispose();
        bool Equals(object obj);
        bool Equals(object obj, float epsilon);
        float GetArcAngle(int aIndex);
        bool GetArcClockwise(int aIndex);
        RectangleF GetBoundsByFlattening(float flatness = 0.001F);
        PathF GetFlattenedPath(float flatness = 0.001F, bool includeSubPaths = false);
        int GetHashCode();
        PointF[] GetPointsForSegment(int segmentIndex);
        PointF GetRotatedPoint(int pointIndex, PointF pivotPoint, float angle);
        int GetSegmentForPoint(int pointIndex);
        PathOperation GetSegmentInfo(int segmentIndex, out int pointIndex, out int arcAngleIndex, out int arcClockwiseIndex);
        int GetSegmentPointIndex(int index);
        PathOperation GetSegmentType(int aIndex);
        PathF InsertCurveTo(PointF controlPoint1, PointF controlPoint2, PointF point, int index);
        PathF InsertLineTo(PointF point, int index);
        PathF InsertQuadTo(PointF controlPoint, PointF point, int index);
        void Invalidate();
        bool IsSubPathClosed(int subPathIndex);
        PathF LineTo(float x, float y);
        PathF LineTo(PointF point);
        void Move(float x, float y);
        void MovePoint(int index, float dx, float dy);
        PathF MoveTo(float x, float y);
        PathF MoveTo(PointF point);
        void Open();
        PathF QuadTo(float cx, float cy, float x, float y);
        PathF QuadTo(PointF controlPoint, PointF point);
        void RemoveAllSegmentsAfter(int segmentIndex);
        void RemoveSegment(int segmentIndex);
        PathF Reverse();
        PathF Rotate(float angleAsDegrees, PointF pivot);
        List<PathF> Separate();
        void SetArcAngle(int aIndex, float aValue);
        void SetArcClockwise(int aIndex, bool aValue);
        void SetPoint(int index, float x, float y);
        void SetPoint(int index, PointF point);
        void Transform(Matrix3x2 transform);
    }
}