namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private readonly IStreamer stream;

        public StreamProgressInfo(IStreamer stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return this.stream.BytesSent * 100 / this.stream.Length;
        }
    }
}
