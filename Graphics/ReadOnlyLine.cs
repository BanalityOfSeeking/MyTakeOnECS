using BonesOfTheFallen.Services.Graphics.Interface;
using System;

namespace BonesOfTheFallen.Services.Graphics;
public record class ReadOnlyLine<T>(ReadOnlyPosition<T> Origin, ReadOnlyPosition<T> End) : IReadOnlyLine<T>
    where T : INumber<T>, new()
{
    public ReadOnlyLine(T x1, T y1, T x2, T y2) : this(new ReadOnlyPosition<T>(x1, y1), new ReadOnlyPosition<T>(x2, y2))
    {
    }
    // add two line
    public static ReadOnlyLine<T> operator +(ReadOnlyLine<T> left, ReadOnlyLine<T> right)
    {
        return new ReadOnlyLine<T>(left.Origin + right.Origin, left.End + right.End);
    }
    public static ReadOnlyLine<T> operator +(ReadOnlyLine<T> left, ReadOnlyPosition<T> right)
    {
        return new ReadOnlyLine<T>(left.Origin + right, left.End + right);
    }
    public static ReadOnlyLine<T> operator -(ReadOnlyLine<T> left, ReadOnlyLine<T> right)
    {
        return new ReadOnlyLine<T>(left.Origin - right.Origin, left.End - right.End);
    }
    public static ReadOnlyLine<T> operator -(IReadOnlyLine<T> left, ReadOnlyLine<T> right)
    {
        return (ReadOnlyLine<T>)left - right;
    }
}

public static class LineExtensions
{
    // Find the point of intersection between
    // the lines p1 --> p2 and p3 --> p4.
    private static void FindIntersection<T>(
        this ReadOnlyLine<T> left, ReadOnlyLine<T> right,
        out bool lines_intersect, out bool segments_intersect,
        out ReadOnlyPosition<T> intersection,
        out ReadOnlyPosition<T> close_p1, out ReadOnlyPosition<T> close_p2)
        where T : INumber<T>, new()
    {
        // Get the segments' parameters.
        T dx12 = left.End.X - left.Origin.X;
        T dy12 = left.End.Y - left.Origin.Y;
        T dx34 = right.End.X - right.Origin.X;
        T dy34 = right.End.Y - right.Origin.Y;

        // Solve for t1 and t2
        T denominator = (dy12 * dx34 - dx12 * dy34);

        T t1 =
            ((left.Origin.X - right.Origin.X) * dy34 + (right.Origin.Y - left.Origin.Y) * dx34)
                / denominator;

        if (float.IsInfinity(float.Parse(t1.ToString()!, System.Globalization.NumberStyles.Float, default)))
        {
            // The lines are parallel (or close enough to it).
            lines_intersect = false;
            segments_intersect = false;
            intersection = default!;
            close_p1 = default!;
            close_p2 = default!;
            return;
        }
        lines_intersect = true;

        T t2 =
            ((right.Origin.X - left.Origin.X) * dy12 + (left.Origin.Y - right.Origin.Y) * dx12)
                / -denominator;

        // Find the point of intersection.
        intersection = new ReadOnlyPosition<T>(left.Origin.X + dx12 * t1, left.Origin.Y + dy12 * t1);

        // The segments intersect if t1 and t2 are between 0 and 1.
        segments_intersect =
            ((t1 >= T.Zero) && (t1 <= T.One) &&
             (t2 >= T.Zero) && (t2 <= T.One));

        // Find the closest points on the segments.
        if (t1 < T.Zero)
        {
            t1 = T.Zero;
        }
        else if (t1 > T.One)
        {
            t1 = T.One;
        }

        if (t2 < T.Zero)
        {
            t2 = T.Zero;
        }
        else if (t2 > T.One)
        {
            t2 = T.One;
        }

        close_p1 = new ReadOnlyPosition<T>(left.Origin.X + dx12 * t1, left.Origin.Y + dy12 * t1);
        close_p2 = new ReadOnlyPosition<T>(right.Origin.X + dx34 * t2, right.Origin.Y + dy34 * t2);
    }
}