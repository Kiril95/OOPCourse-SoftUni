namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(new Circle());
            editor.DrawShape(new Rectangle());
            editor.DrawShape(new Square());
        }
    }
}
