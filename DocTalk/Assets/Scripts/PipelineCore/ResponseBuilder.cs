
namespace PipelineCore
{
    public class ResponseBuilder
    {
        private ResponseMessage response;

        public ResponseBuilder(ResponseMessage response)
        {
            this.response = response;
        }

        public Response BuildResponse()
        {
            return response.BuildResponse();
        }

    }

}