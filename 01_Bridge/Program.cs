using System;

namespace _01_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // 白色實作
            Color white = new White();
            // 圓形實作
            Shape square = new Circle();
            // 圓形實作中 載入 白色實作
            square.SetColor(white);
            // 畫出 白色圓形
            square.Draw();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 形狀介面
    /// 傳入 Color 實作
    /// </summary>
    public abstract class Shape
    {
        public Color color;
        public void SetColor(Color color)
        {
            this.color = color;
        }
        public abstract void Draw();
    }

    /// <summary>
    /// 圓形 繼承 Shape
    /// 實作中呼叫 color 方法
    /// </summary>
    public class Circle : Shape
    {
        public override void Draw()
        {
            color.Paint("圓形");
        }
    }

    /// <summary>
    /// 長方形 繼承 Shape
    /// 實作中呼叫 color 方法
    /// </summary>
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            color.Paint("長方形");
        }
    }

    public interface Color
    {
        void Paint(string shape);
    }

    public class White : Color
    {
        public void Paint(string shape)
        {
            Console.WriteLine("白色的" + shape);
        }
    }

    public class Gray : Color
    {
        public void Paint(string shape)
        {
            Console.WriteLine("灰色的" + shape);
        }
    }
}
