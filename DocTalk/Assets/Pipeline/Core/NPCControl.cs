namespace PipelineCore
{
    /// <summary>
    /// Represents a control interface for non-player characters (NPCs) in a pipeline.
    /// </summary>
    public interface NPCControl
    {
        /// <summary>
        /// Performs a response action based on the provided response message.
        /// </summary>
        /// <param name="responseMessage">The response message to be processed.</param>
        void PerformResponse(ResponseMessage responseMessage);
    }
}
