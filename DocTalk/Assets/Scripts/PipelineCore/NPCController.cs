namespace PipelineCore
{
    /// <summary>
    /// Represents a controller for a character in a pipeline.
    /// </summary>
    public class CharacterController
    {
        private CharacterControl control;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterController"/> class.
        /// </summary>
        /// <param name="control">The character control used by the controller.</param>
        public CharacterController(CharacterControl control)
        {
            this.control = control;
        }

        /// <summary>
        /// Performs a response action based on the provided response message.
        /// </summary>
        /// <param name="response">The response message to be processed.</param>
        public void PerformResponse(ResponseMessage response)
        {
            control.PerformResponse(response);
        }
    }
}
