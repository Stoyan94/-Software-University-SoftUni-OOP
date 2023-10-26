namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {   
            File music = new Music("12", "22", 10, 20);
            File picture = new Picture("10", 10, 10);

            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(picture);
            StreamProgressInfo streamProgressInfo2 = new StreamProgressInfo(music);

            streamProgressInfo.CalculateCurrentPercent();
            streamProgressInfo2.CalculateCurrentPercent();
        }
    }
}
