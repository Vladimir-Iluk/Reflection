class TraficLight
{
    private string color;
    private TraficLight (string color)
    {
        this.color = color;
    }
    private void ChangeColor()
    {
        if (color == "Red")
        {
            color = "Green";
        }
        else if (color == "Green")
        {
            color = "Yellow";
        } else if (color == "Yellow")
        {
            color = "Red";
        }
    }
    private string GetColor()
    {
        return color;
    }
}