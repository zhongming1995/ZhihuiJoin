using System.Collections.Generic;

public class PianoSpectrum 
{
    //1 《小星星》 2《数鸭子》 3《找朋友》
    public static List<int> LittleStarSpecturms = new List<int>
    {
        1,1,5,5,6,6,5,
        4,4,3,3,2,2,1,
        5,5,4,4,3,3,2,
        5,5,4,4,3,3,2,
        1,1,5,5,6,6,5,
        4,4,3,3,2,2,1,
    };

    public static List<int> CountDuckSpecturms = new List<int>
    {
        3,1,3,3,1,3,3,5,6,5,
        6,6,6,5,4,4,4,2,3,2,1,2,
        3,1,3,1,3,3,5,6,6,
        8,5,5,6,3,2,1,2,3,5,
        8,5,5,6,3,2,1,2,3,1,
    };

    public static List<int> FindFriendSpecturms = new List<int>
    {
        5,6,5,6,5,6,5,
        5,8,7,6,5,5,3,
        5,5,3,4,5,5,3,
        1,4,3,2,1,2,1,
    };

    public static List<List<int>> SongsList = new List<List<int>>()
    {
        LittleStarSpecturms,
        CountDuckSpecturms,
        FindFriendSpecturms,
    };

}
