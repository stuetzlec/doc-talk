
namespace PipelineCore
{
    /// <summary>
    /// Represents a response message with a generic value.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the response message.</typeparam>
    public interface ResponseMessage<T>
    {
        /// <summary>
        /// Builds and returns a response message.
        /// </summary>
        /// <returns>The constructed response message.</returns>
        ResponseMessage<T> BuildResponse();

        /// <summary>
        /// Gets the value contained in the response message.
        /// </summary>
        /// <returns>The value contained in the response message.</returns>
        T GetValue();
    }
}
