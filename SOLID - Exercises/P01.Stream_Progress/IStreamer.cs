namespace P01.Stream_Progress
{
    public interface IStreamer
    {
        int Length { get; }

        int BytesSent { get; }
    }
}