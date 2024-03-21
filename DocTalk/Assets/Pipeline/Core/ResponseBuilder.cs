
namespace PipelineCore
{
    /// <summary>
    /// Represents a builder for constructing responses.
    /// </summary>
    public class ResponseBuilder
    {
        private ResponseMessage response;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBuilder"/> class with the specified response message.
        /// </summary>
        /// <param name="response">The initial response message.</param>
        public ResponseBuilder(ResponseMessage response)
        {
            this.response = response;
        }

        /// <summary>
        /// Builds and returns the response message.
        /// </summary>
        /// <returns>The constructed response message.</returns>
        public Response BuildResponse()
        {
            return response.BuildResponse();
        }
    }
}
