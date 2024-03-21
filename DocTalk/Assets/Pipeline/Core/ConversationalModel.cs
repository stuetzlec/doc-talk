namespace PipelineCore
{
    /// <summary>
    /// Represents a model for generating responses in a conversational system.
    /// </summary>
    public interface ConversationalModel
    {
        /// <summary>
        /// Generates a response based on the provided input response.
        /// </summary>
        /// <param name="response">The input response used for generating the new response.</param>
        /// <returns>The generated response.</returns>
        ResponseMessage CreateResponse(ResponseMessage response);
    }
}
