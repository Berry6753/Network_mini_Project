using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerColor
{ 
    Red, Blue, Green, Pink, Orange, Yellow,
    Gray, White, Purple, Brown, Cyan, Lime
}

public class PlayerColor
{
    private static List<Color> colorList = new List<Color>()
    {
        new Color(1f,0f,0f),            //Red
        new Color(0.1f,0.1f,1f),        //Blue
        new Color(0f,0.6f,0f),          //Green
        new Color(1f,0.3f,0.6f),        //Pink
        new Color(1f,0.4f, 0f),         //Orange
        new Color(1f,0.9f,0.1f),        //Yellow
        new Color(0.7f,0.7f,0.7f),      //Gray
        new Color(1f,1f,1f),            //White
        new Color(0.6f,0f,0.6f),        //Purple
        new Color(0.7f,0.2f,0f),        //Brown
        new Color(0f,1f,1f),            //Cyan
        new Color(0.1f,1f,0.1f)         //Lime
    };

    public static Color GetColor(EPlayerColor playerColor) { return colorList[(int)playerColor]; }

    public static Color red { get { return colorList[(int)EPlayerColor.Red]; } }
    public static Color blue { get { return colorList[(int)EPlayerColor.Blue]; } }
    public static Color green { get { return colorList[(int)EPlayerColor.Green]; } }
    public static Color pink { get { return colorList[(int)EPlayerColor.Pink]; } }
    public static Color orange { get { return colorList[(int)EPlayerColor.Orange]; } }
    public static Color yellow { get { return colorList[(int)EPlayerColor.Yellow]; } }
    public static Color gray { get { return colorList[(int)EPlayerColor.Gray]; } }
    public static Color white { get { return colorList[(int)EPlayerColor.White]; } }
    public static Color purple { get { return colorList[(int)EPlayerColor.Purple]; } }
    public static Color brown { get { return colorList[(int)EPlayerColor.Brown]; } }
    public static Color cyan { get { return colorList[(int)EPlayerColor.Cyan]; } }
    public static Color lime { get { return colorList[(int)EPlayerColor.Lime]; } }
}
