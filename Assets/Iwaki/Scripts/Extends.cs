using UnityEngine;

public static class Extends
{
    public static Transform[] GetChildren(this Transform parent)
    {
        var children = new Transform[parent.childCount];

        for (int i = 0; i < parent.childCount; i++)
        {
            children[i] = parent.GetChild(i);
        }

        return children;
    }

    public static Vector3 RandomPosInCollider(this Collider2D collider)
    {
        if (collider as BoxCollider2D)
        {
            var box = (BoxCollider2D)collider;

            var bounds = box.bounds;

            Vector3 min = bounds.min;
            Vector3 max = bounds.max;

            var x = Random.Range(min.x, max.x);
            var y = Random.Range(min.y, max.y);

            var pos = new Vector3(x, y);
            return pos;
        }

        if (collider as CircleCollider2D)
        {
            var circle = (CircleCollider2D)collider;

            Vector3 offset = (Vector3)circle.offset + circle.transform.position;
            var radius = circle.radius;

            var pos = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(Random.Range(0, radius), 0) + offset;

            return pos;
        }

        return Vector3.zero;
    }

    public static T GetRandomElementOfTwo<T>(this T[] array, float weight = 0.5f)
    {
        if (Random.Range(0f, 1f) < weight)
        {
            return array[0];
        }
        else
        {
            return array[1];
        }
    }

    public static T GetRandomElement<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];

    }
}
