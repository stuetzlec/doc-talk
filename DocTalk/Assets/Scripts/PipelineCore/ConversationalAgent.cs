namespace PipelineCore
{
    public class ConversationalAgent
    {
        private ConversationalModel model;

        public ConversationalAgent(CoversationalModel model) {
            this.model = model
        }

        public CreateResponse(ResponseMessage response)
        {
            return model.CreateResponse(response);
        }
    }
}